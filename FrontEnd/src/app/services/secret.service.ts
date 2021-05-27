import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SecretService {

  appUrl: string = environment.appUrl;
  constructor(private http: HttpClient) { }

  getValues(): Observable<string[]> {
    return this.http.get<string[]>(this.appUrl + 'weatherforecast', this.getHttpOptions());
  }

  getCourses(): Observable<string[]> {
    return this.http.get<string[]>(this.appUrl + 'api/courses', this.getHttpOptions());
  }

  // tslint:disable-next-line: typedef
  getHttpOptions() {
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('message'),
      }),
    };
    return httpOptions;
  }
}
