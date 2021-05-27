import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-rank',
  templateUrl: './user-rank.component.html',
  styleUrls: ['./../users-rank-list/users-rank-list.component.css']
})


export class UserRankComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

export class UserRankDetail {
  id: number;
  fullName: string;
  score: number;

  public constructor( id, fullName, score){
    this.id = id;
    this.fullName = fullName;
    this.score = score;
  }
}
