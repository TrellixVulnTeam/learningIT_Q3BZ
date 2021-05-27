import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-addarticle',
  templateUrl: './addarticle.component.html',
  styleUrls: ['./addarticle.component.css']
})
export class AddarticleComponent implements OnInit {
  appUrl: string = environment.appUrl;
  userId = Number(localStorage.getItem('UserId'));

  constructor(public toastr: ToastrService, public router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  // tslint:disable-next-line: typedef
  submit(f: NgForm) {
    this.http.post(this.appUrl + 'api/articles', f.value).subscribe();
    this.toastr.success('Article added');
    this.router.navigate(['/articles']);
  }

}
