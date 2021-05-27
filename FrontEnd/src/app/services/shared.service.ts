import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  appUrl: string = environment.appUrl;
  private subject = new Subject<any>();
  valoare: any;

  constructor(private http: HttpClient) { }

  sendClickEvent(): void {
    this.subject.next();
  }
  getClickEvent(): Observable<any>{
    return this.subject.asObservable();
  }
  salveza(x: any): void{
    this.http.get<any>(this.appUrl + 'api/user/' + x).subscribe((data) => {
      this.valoare = data.firstName;
      alert(this.valoare);
    });
  }

}
