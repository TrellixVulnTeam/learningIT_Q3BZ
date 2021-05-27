import { AlertService } from 'ngx-alerts';
import { Component, forwardRef, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { NgForm } from '@angular/forms';
import { inject } from '@angular/core/testing';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: any = {
    FirstName: null,
    LastName: null,
    Email: null,
    Password: null,
    ConfirmPassword: null
  };

  constructor(
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router

  ) {}

  // tslint:disable-next-line: typedef
  ngOnInit() {}

  // tslint:disable-next-line: typedef
  onSubmit() {
    const registerObserver = {
      next: (x) => {
        this.toastr.success('Account Created');
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 1000);
      },
      error: (err) => {
        this.toastr.error('Fail!');
      },
    };


    this.authService.register(this.model).subscribe(registerObserver);
  }

}
