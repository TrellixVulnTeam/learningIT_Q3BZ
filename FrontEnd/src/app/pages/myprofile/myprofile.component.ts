import { CertificatModel } from './../utils/CertificatModel';
import { BadgeDetails } from './../utils/BadgeDetails';
import { UserBadge } from './../utils/UserBadge';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild, Renderer2, ElementRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { observable, Subscriber } from 'rxjs';
import { Observable } from 'rxjs';
import { subscribeOn } from 'rxjs/operators';
import { AuthService } from 'src/app/services/auth.service';
import { UserDetail } from 'src/app/services/UserDetails';
import { UserDetailPut } from 'src/app/services/UserDetailsPut';
import { environment } from 'src/environments/environment';
import { HomeComponent } from '../home/home.component';

const TEST = [
  {id: 1, title: 'title 1'},
  {id: 2, title: 'title 2'},
  {id: 3, title: 'title 3'},
  {id: 4, title: 'title 4'},

];

@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.css']
})
export class MyprofileComponent implements OnInit {
  test = TEST;
  level = 1;
  procent: number;
  afisare: string;
  score: number;
  FirstName: string;
  LastName: string;
  Email = localStorage.getItem('Email');
  myimage: any;
  myimage2: any;
  userId = localStorage.getItem('UserId');
  appUrl: string = environment.appUrl;
  myUser: UserDetail[] = [];
  myUser2: UserDetail[] = [];
  myUserPut: UserDetailPut = {
    Id: null,
    IdentityId: null,
    FirstName: null,
    LastName: null,
    Score: null,
    Image: null
  };

  userBadgesList: BadgeDetails[] = [];



  constructor(
    private authUser: AuthService,
    private http: HttpClient,
    private render: Renderer2,
    private elem: ElementRef
    ) { }

  ngOnInit(): void {
    this.http.get<UserDetail>(this.appUrl + 'api/User/' + this.userId).subscribe((data) => {
      if (data.image !== null){
        this.myimage2 = data.image;
      }
      else
      {
        this.myimage2 = 'https://i.ibb.co/QrrWFH8/user.png';
      }
    });
    this.http.get<UserDetail>(this.appUrl + 'api/User/' + this.userId).subscribe((data) => {
      this.myUserPut.Id = data.id;
      this.myUserPut.IdentityId = data.identityId;
      this.myUserPut.FirstName = data.firstName;
      this.myUserPut.LastName = data.lastName;
      this.myUserPut.Score = data.score;
      this.myUserPut.Image = data.image;
      this.FirstName = data.firstName;
      this.LastName = data.lastName;
      this.score = Number(data.score);
      console.log(this.score);
      this.calculareNivel();
    });

    this.http.get<BadgeDetails[]>(this.appUrl + 'api/User/Badges/' + this.userId).subscribe((data) => {
      this.userBadgesList = data;
      console.log(this.userBadgesList);
    });


  }

  // tslint:disable-next-line: typedef
  convertToBase64(file: File){
    // tslint:disable-next-line: no-shadowed-variable
    const observable = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });
    observable.subscribe((d) => {
      this.myimage = d;
    });

  }

  // tslint:disable-next-line: typedef
  onFileChanged($event: Event){
    const file = ($event.target as HTMLInputElement).files[0];
    this.convertToBase64(file);
    this.http.get<UserDetail>(this.appUrl + 'api/User/' + this.userId).subscribe((data) => {
      this.myUserPut.Id = data.id;
      this.myUserPut.IdentityId = data.identityId;
      this.myUserPut.FirstName = data.firstName;
      this.myUserPut.LastName = data.lastName;
      this.myUserPut.Score = data.score;
      this.myUserPut.Image = this.myimage;
    });
  }

  // tslint:disable-next-line: typedef
  readFile(file: File, subscriber: Subscriber<any>){
    const filereader = new FileReader();

    filereader.readAsDataURL(file);

    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    };
    filereader.onerror = (error) => {
      subscriber.error(error);
      subscriber.complete();
    };
  }


  // tslint:disable-next-line: typedef
  onSubmit1(): void{
    this.http.put(this.appUrl + 'api/User/' + this.userId, this.myUserPut).subscribe();
  }

  update(f: NgForm): void{
    if (f.value.firstName !== null){
      this.myUserPut.FirstName = f.value.firstName;
    }
    if (f.value.lastName !== null){
      this.myUserPut.LastName = f.value.lastName;
    }
    this.http.put(this.appUrl + 'api/User/' + this.userId, this.myUserPut).subscribe();
    localStorage.setItem('FirstName', this.myUserPut.FirstName);
    localStorage.setItem('LastName', this.myUserPut.LastName);
    window.location.reload();
  }

  calculareNivel(): void{
    if (this.score < 0){
      this.level = 0;
      this.procent = 100;
      this.afisare = 'Admin';
    }
    if (this.score >= 0 && this.score < 1000){
      this.level = 1;
      this.procent = this.score / 10;
      this.afisare = String(this.score) + ' / 1000 xp';
    }
    if (this.score >= 1000 && this.score < 3000){
      this.level = 2;
      this.procent = (this.score - 1000) / ((3000 - 1000) / 100);
      this.afisare = String(this.score) + ' / 3000 xp';
    }
    if (this.score >= 3000 && this.score < 10000){
      this.level = 3;
      this.procent = (this.score - 3000) / ((10000 - 3000) / 100);
      this.afisare = String(this.score) + ' / 10000 xp';
    }
    if (this.score >= 10000 && this.score < 20000){
      this.level = 4;
      this.procent = (this.score - 10000) / ((20000 - 10000) / 100);
      this.afisare = String(this.score) + ' / 20000 xp';
    }
    if (this.score >= 20000 && this.score < 50000){
      this.level = 5;
      this.procent = (this.score - 20000) / ((50000 - 20000) / 100);
      this.afisare = String(this.score) + ' / 50000 xp';
    }
  }

  certificat(id): void{
    window.open(this.appUrl + 'api/certificat/' + this.FirstName + this.LastName + '/' + id, '_blank');
  }
}
