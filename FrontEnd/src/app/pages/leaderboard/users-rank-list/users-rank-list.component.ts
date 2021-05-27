import { element } from 'protractor';
import { UserRankDetail } from './../user-rank/user-rank.component';
import { HttpClient } from '@angular/common/http';
import { UserRankDetailService } from './../user-rank-detail.service';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-users-rank-list',
  templateUrl: './users-rank-list.component.html',
  styleUrls: ['./users-rank-list.component.css']
})


export class UsersRankListComponent implements OnInit {
    // usersRankDetails: any;
    public usersRankDetails: UserRankDetail[];
    appUrl: string = environment.appUrl;

    constructor(private http: HttpClient) {
    }

    ngOnInit(): void {

      this.http.get<UserRankDetail[]>(this.appUrl + 'api/user/LeaderboardTop').subscribe((data) => {
        this.usersRankDetails = data;
        console.log(data);
      });

  }

}

// export class UsersRankListComponent implements OnInit {



//   ngOnInit(): void {
//   }

// }
