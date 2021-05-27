import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {
  appUrl: string = environment.appUrl;
  id: string;
  title: string;
  description: string;
  userId: string;
  imageURL: string;
  firstName: string;
  lastName: string;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<any>(this.appUrl + 'api/articles/' + localStorage.getItem('ArticleId')).subscribe((data) => {
      this.id = data.id;
      this.title = data.title;
      this.description = data.description;
      this.userId = data.userId;
      this.imageURL = data.imageURL;
      this.http.get<any>(this.appUrl + 'api/user/' + this.userId).subscribe((dataa) => {
        this.firstName = dataa.firstName;
        this.lastName = dataa.lastName;
      });
    });
  }

}
