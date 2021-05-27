import { UserCourse } from './../utils/UserCourse';
import { UserBadge } from './../utils/UserBadge';
import { Component, OnInit } from '@angular/core';
import { QuestionDetails } from '../utils/QuestionDetails';
import { SecretService } from 'src/app/services/secret.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserDetailPut } from 'src/app/services/UserDetailsPut';
import { UserDetail } from 'src/app/services/UserDetails';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.scss']
})
export class ExamComponent implements OnInit {

  apare = false;
  public questions: QuestionDetails[];
  appUrl: string = environment.appUrl;
  public numarRaspunsuriCorecte = 0;
  public mapAnswers = new Map();
  public model: UserBadge;
  public modeUserCourse: UserCourse;
  myUserPut: UserDetailPut = {
    Id: null,
    IdentityId: null,
    FirstName: null,
    LastName: null,
    Score: null,
    Image: null
  };
  constructor(private secretService: SecretService, private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<QuestionDetails[]>(this.appUrl + 'api/exams/questionsExam/' + localStorage.getItem('ExamId')).subscribe((data) => {
      this.questions = data;

      // tslint:disable-next-line:prefer-for-of
      for (let i = 0; i < this.questions.length; i++) {
        this.mapAnswers.set(this.questions[i].id, 1);
      }

      console.log(this.mapAnswers);
    });


    this.http.get<UserDetail>(this.appUrl + 'api/User/' + localStorage.getItem('UserId')).subscribe((data) => {
      this.myUserPut.Id = data.id;
      this.myUserPut.IdentityId = data.identityId;
      this.myUserPut.FirstName = data.firstName;
      this.myUserPut.LastName = data.lastName;
      this.myUserPut.Score = data.score;
      this.myUserPut.Image = data.image;
    });

  }

  verificaRaspunsCorect(id, raspuns): void {

    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.questions.length; i++){
      if (this.questions[i].id === id) {
          if (this.questions[i].raspunsCorect === 1 ) {
            if (raspuns === 'A' ) {
              if (this.mapAnswers.get(this.questions[i].id) === 1) {
                this.mapAnswers.set(this.questions[i].id, 0);
                break;
              }
            }
            else {
              this.mapAnswers.set(this.questions[i].id, 1);
            }
          }
          else if ( this.questions[i].raspunsCorect === 2) {
            if (raspuns === 'B' ) {
              if (this.mapAnswers.get(this.questions[i].id) === 1) {
                this.mapAnswers.set(this.questions[i].id, 0);
                break;
              }
            }
            else {
              this.mapAnswers.set(this.questions[i].id, 1);
            }
          }
          else if ( this.questions[i].raspunsCorect === 3) {
            if ( raspuns === 'C' ) {
              if (this.mapAnswers.get(this.questions[i].id) === 1) {
                this.mapAnswers.set(this.questions[i].id, 0);
                break;
              }
            } else {
              this.mapAnswers.set(this.questions[i].id, 1);
            }
          }
          else if ( this.questions[i].raspunsCorect === 4) {
            if ( raspuns === 'D' ) {
              if (this.mapAnswers.get(this.questions[i].id) === 1) {
                this.mapAnswers.set(this.questions[i].id, 0);
                break;
              }
            } else {
              this.mapAnswers.set(this.questions[i].id, 1);
            }
          }
      }
    }

    console.log(this.mapAnswers);

  }

  verificaToateRaspunsurile(): any {
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.questions.length; i++)
    {
      if (this.mapAnswers.get (this.questions[i].id) !== 0) {
        return 0;
      }
    }
    return 1;
  }

  verificaRezultat(): void {
    // tslint:disable-next-line:prefer-for-of
    if (this.verificaToateRaspunsurile() === 1) {
      // Post de salvare Badge la user
      // Redirect catre castigat badge
      this.salveazaBadgeUser();
      this.salveazaCourseUser();
      this.myUserPut.Score = this.myUserPut.Score + Number(localStorage.getItem('CourseExperience'));
      this.http.put(this.appUrl + 'api/User/' + localStorage.getItem('UserId'), this.myUserPut).subscribe();
      this.apare = true;
    }
    else {
      this.apare = false;
    }
  }

  // tslint:disable-next-line:typedef
  salveazaBadgeUser() {
    this.model = new UserBadge((Number)(localStorage.getItem('UserId')), (Number)(localStorage.getItem('BadgeId')));
    console.log(this.model);
    return  this.http.post(this.appUrl + 'api/UserBadges/' , this.model).subscribe();
  }

  // tslint:disable-next-line: typedef
  salveazaCourseUser() {
    this.modeUserCourse = new UserCourse((Number)(localStorage.getItem('UserId')), (Number)(localStorage.getItem('CourseId')));
    console.log(this.modeUserCourse);
    return  this.http.post(this.appUrl + 'api/usercourses/' , this.modeUserCourse).subscribe();
  }

}
