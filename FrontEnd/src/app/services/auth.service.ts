import { from, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  appUrl: string = environment.appUrl;
  helper = new JwtHelperService();
  FirstName: string;
  LastName: string;
  Email: string;
  Score: number;
  constructor( private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  login(model: any){ // : Observable<IUser>
    return this.http.post(this.appUrl + 'api/auth/login', model).pipe(
      map((response: any) => {
        const decodedToken = this.helper.decodeToken(response.message);
        this.Email = decodedToken.Email;
        this.FirstName = decodedToken.FirstName;
        this.LastName = decodedToken.LastName;
        this.Score = decodedToken.Score;
        localStorage.setItem('Email', decodedToken.Email);
        localStorage.setItem('FirstName', decodedToken.FirstName);
        localStorage.setItem('LastName', decodedToken.LastName);
        localStorage.setItem('Score', decodedToken.Score);
        localStorage.setItem('message', response.message);
      })
    );
  }

  public loggedIn(): boolean{
    const message = localStorage.getItem('message');
    return !this.helper.isTokenExpired(message);
  }

  public loggedOut(): boolean{
    const message = localStorage.getItem('message');
    return this.helper.isTokenExpired(message);
  }

  // tslint:disable-next-line: typedef
  logout() {
    localStorage.clear();
  }
  // tslint:disable-next-line: typedef
  register(model: any){
    return  this.http.post(this.appUrl + 'api/auth/register', model);
  }
}
