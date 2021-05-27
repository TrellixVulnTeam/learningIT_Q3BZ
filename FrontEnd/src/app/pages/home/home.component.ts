import { HttpClient } from '@angular/common/http';
import { SecretService } from './../../services/secret.service';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home , courses',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  appUrl: string = environment.appUrl;
  categoryy = false;
  level = false;
  x: string;
  p = 1;
  courses: any;
  userId: any;
  filterTerm: string;
  category = [
    {t: '.NET'},
    {t: 'Azure'},
    {t: 'Dynamics 365'},
    {t: 'GitHub'},
    {t: 'Internet Explorer'},
    {t: 'Microsoft Endpoint Manager'},
    {t: 'Microsoft Graph'},
    {t: 'Office'},
    {t: 'Office 365'},
    {t: 'Power Platform'},
    {t: 'Quantum Development Kit'},
    {t: '.SQL Server'},
    {t: 'Surface'},
    {t: 'Teams'},
    {t: 'Visual Studio'},
    {t: 'Windows'}
  ];

  levels = [
    {t: 'Beginner'},
    {t: 'Intermediate'},
    {t: 'Advanced'}
  ];

  constructor(private secretService: SecretService, private http: HttpClient) {
    this.http.get<any>(this.appUrl + 'api/courses').subscribe((data) => {
      this.courses = data;
    });
    this.http.get<any>(this.appUrl + 'api/User/Email/' + localStorage.getItem('Email')).subscribe((data) => {
      localStorage.setItem('UserId', data);
    });
   }

  ngOnInit(): void { }

  // tslint:disable-next-line: typedef
  onclick(clickedtitle){
    localStorage.setItem('CourseTitle', clickedtitle);
  }

  // tslint:disable-next-line: typedef
  saveId(clickedId){
    localStorage.setItem('CourseId', clickedId);
  }

  fcategory(item): void{
    if (this.categoryy === false){
      this.http.get<any>(this.appUrl + 'api/courses/categorie/' + item).subscribe((data) => {
        this.courses = data;
      });
      this.categoryy = true;
    }
    else {
      this.http.get<any>(this.appUrl + 'api/courses').subscribe((data) => {
        this.courses = data;
      });
      this.categoryy = false;
    }
  }
  flevel(item): void {
    if (this.level === false){
      this.http.get<any>(this.appUrl + 'api/courses/level/' + item).subscribe((data) => {
        this.courses = data;
      });
      this.level = true;
    }
    else {
      this.http.get<any>(this.appUrl + 'api/courses').subscribe((data) => {
        this.courses = data;
      });
      this.level = false;
    }
  }

  sus(): void{
    window.scroll(0, 0);
  }
}
