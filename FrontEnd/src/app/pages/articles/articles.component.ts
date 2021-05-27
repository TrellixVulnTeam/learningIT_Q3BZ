import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.scss']
})
export class ArticlesComponent implements OnInit {
  appUrl: string = environment.appUrl;
  articles: any;
  userScore: any;
  adauga = false;
  userList = [{}];

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.http.get<any>(this.appUrl + 'api/articles').subscribe((data) => {
      this.articles = data;
    });
    this.http.get<any>(this.appUrl + 'api/user/' + localStorage.getItem('UserId')).subscribe((data) => {
      this.userScore = data.score;
    });
    this.verificare1();
  }

  onclick(clickedid): void{
    localStorage.setItem('ArticleId', clickedid);
    return clickedid;
  }

  verificare1(): boolean{
    if (this.userScore >= 10000 || this.userScore < 0){
      return true;
    }
    else{
      return false;
    }
  }

  verificare2(user): void{
    if (user === Number(localStorage.getItem('UserId')) || this.userScore < 0){
      this.router.navigate(['/edit-article']);
    }
    else {
      this.toastr.error('Access denied!');
    }

  }
}
