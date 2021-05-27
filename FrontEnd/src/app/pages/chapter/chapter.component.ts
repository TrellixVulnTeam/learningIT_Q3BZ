import { HttpClient } from '@angular/common/http';
import { stringify } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { findIndex } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ChapterDetails } from '../utils/ChapterDetails';

@Component({
  selector: 'app-chapter',
  templateUrl: './chapter.component.html',
  styleUrls: ['./chapter.component.scss']
})
export class ChapterComponent implements OnInit {
  public chapters: ChapterDetails[];
  public chapter: ChapterDetails;
  appUrl: string = environment.appUrl;
  curentId = localStorage.getItem('ChapterId');
  currentTitleCourse = localStorage.getItem('CurentTitleCourse');
  public position = 0;

  constructor(private http: HttpClient , private router: Router ,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    console.log('From NgOnit' + this.curentId);
    this.getCurrentChapter();

  }

  getCurrentChapter(): void {

    this.http.get<ChapterDetails[]>(this.appUrl + 'api/chapters/title/' + this.currentTitleCourse).subscribe((data) => {
      this.chapters = data;
      localStorage.setItem('ChapterId', String(this.chapters[0].id));
    });

    this.http.get<ChapterDetails>(this.appUrl + 'api/chapters/' + this.curentId).subscribe((data) => {
      this.chapter = data;
    });


  }

  switchId(): void{
    window.scroll(0, 0);
    if (Number(localStorage.getItem('ChapterId')) === this.chapters[this.chapters.length - 1].id) {
      this.router.navigateByUrl('/exams/' + localStorage.getItem('ExamId'));
    }

    if (Number(localStorage.getItem('ChapterId')) < this.chapters[this.chapters.length - 1].id) {
      for (let i = 0; i < this.chapters.length; i++){
        if (this.chapters[i].id === Number(localStorage.getItem('ChapterId'))) {
            localStorage.setItem('ChapterId', String(this.chapters[i + 1].id));
            break;
        }
      }
    }
    this.http.get<ChapterDetails>(this.appUrl + 'api/chapters/' + localStorage.getItem('ChapterId')).subscribe((data) => {
      this.chapter = data;
    });
  }


  switchIdBack(): void {
    window.scroll(0, 0);
    if (Number(localStorage.getItem('ChapterId')) > this.chapters[0].id) {
      for (let i = 0; i < this.chapters.length; i++){
        if (this.chapters[i].id === Number(localStorage.getItem('ChapterId'))) {
            localStorage.setItem('ChapterId', String(this.chapters[i - 1].id));
            break;
        }
      }
    }
    this.http.get<ChapterDetails>(this.appUrl + 'api/chapters/' + localStorage.getItem('ChapterId')).subscribe((data) => {
      this.chapter = data;
    });
  }

}
