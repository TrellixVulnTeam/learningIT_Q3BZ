import { Injectable } from '@angular/core';
import { NgProgressRef } from 'ngx-progressbar';

@Injectable({
  providedIn: 'root'
})
export class ProgressbarService {
  progressRef: NgProgressRef;
  defaultColor = '#007bff';
  successColor = '#13b955';
  failureColor = '#fc3939';
  currentColor: string = this.defaultColor;

  constructor() { }

  // tslint:disable-next-line: typedef
  startLoading() {
    this.currentColor = this.defaultColor;
    this.progressRef.start();
  }

  // tslint:disable-next-line: typedef
  completeLoading() {
    this.progressRef.complete();
  }

  // tslint:disable-next-line: typedef
  setSuccess() {
    this.currentColor = this.successColor;
  }

  // tslint:disable-next-line: typedef
  setFailure() {
    this.currentColor = this.failureColor;
  }

}
