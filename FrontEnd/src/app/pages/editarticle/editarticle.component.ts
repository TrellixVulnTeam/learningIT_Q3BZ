import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-editarticle',
  templateUrl: './editarticle.component.html',
  styleUrls: ['./editarticle.component.scss']
})
export class EditarticleComponent implements OnInit {
  appUrl: string = environment.appUrl;
  article = {
    id: null,
    title: null,
    description: null,
    userId: null,
    imageURL: null,
  };

  constructor(public toastr: ToastrService, public router: Router, private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<any>(this.appUrl + 'api/articles/' + localStorage.getItem('ArticleId')).subscribe((data) => {
      this.article.id = data.id;
      this.article.title = data.title;
      this.article.description = data.description;
      this.article.userId = data.userId;
      this.article.imageURL = data.imageURL;
    });
  }

  submit(f: NgForm): void{
    if (f.value.title !== null){
      this.article.title = f.value.title;
    }
    if (f.value.description !== null){
      this.article.description = f.value.description;
    }
    if (f.value.imageURL !== null){
      this.article.imageURL = f.value.imageURL;
    }
    this.http.put(this.appUrl + 'api/articles/' + localStorage.getItem('ArticleId'), this.article).subscribe();
    this.toastr.success('Article Modified');
    this.router.navigate(['/articles']);
  }

}
