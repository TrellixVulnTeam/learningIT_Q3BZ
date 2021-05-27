import { BadgeDetails } from './../utils/BadgeDetails';
import { ExamDetalis } from './../utils/ExamDetails';
import { HomeComponent } from './../home/home.component';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SecretService } from 'src/app/services/secret.service';
import { environment } from 'src/environments/environment';
import { CourseDetails } from '../utils/CourseDetails';
import { ChapterDetails } from '../utils/ChapterDetails';


@Component({
  selector: 'app-course , chapters',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit{

  public capitole: ChapterDetails[];
  public firstChapter: ChapterDetails;
  public course: CourseDetails;
  public exam: ExamDetalis;
  public badge: BadgeDetails;
  appUrl: string = environment.appUrl;
  selectedChapter = '';
  currenttitle = localStorage.getItem('CourseTitle');
  curentId = localStorage.getItem('CourseId');

  constructor(private secretService: SecretService, private http: HttpClient) { }

  ngOnInit(): void {

    this.http.get<CourseDetails>(this.appUrl + 'api/courses/' + this.curentId).subscribe((data) => {
      this.course = data;
      localStorage.setItem('CourseExperience', String(this.course.experience));
    });

    this.http.get<ExamDetalis>(this.appUrl + 'api/exams/course/' + this.curentId).subscribe((data) => {
      this.exam = data;
      localStorage.setItem('ExamId', String(this.exam.id));
      console.log(this.exam);
    });

    this.http.get<ChapterDetails[]>(this.appUrl + 'api/chapters/title/' + this.currenttitle).subscribe((data) => {
      this.capitole = data;
      this.firstChapter = data[0];
    });

    this.http.get<BadgeDetails>(this.appUrl + 'api/courses/badge/' + this.curentId).subscribe((data) => {
      this.badge = data;
      localStorage.setItem('BadgeId', String(this.badge.id));
      console.log( String(this.badge.id));
    });

    }

  saveChaperId(ChaperId): void {
    localStorage.setItem('ChapterId', ChaperId);
    localStorage.setItem('CurentTitleCourse', this.currenttitle);
  }

}



