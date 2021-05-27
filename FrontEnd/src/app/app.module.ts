import { WelcomeComponent } from './pages/welcome/welcome.component';
import { EditarticleComponent } from './pages/editarticle/editarticle.component';
import { AddarticleComponent } from './pages/addarticle/addarticle.component';
import { MyprofileComponent } from './pages/myprofile/myprofile.component';
import { FooterComponent } from './elements/footer/footer.component';
import { RegisterComponent } from './pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NavbarComponent } from './elements/navbar/navbar.component';
import { LeaderboardComponent } from './pages/leaderboard/leaderboard.component';
import { ArticleComponent } from './pages/article/article.component';
import { CourseComponent } from './pages/course/course.component';
import { FormsModule } from '@angular/forms';
import { TeamComponent } from './pages/team/team.component';
import { UserRankComponent } from './pages/leaderboard/user-rank/user-rank.component';
import { HeaderRankComponent } from './pages/leaderboard/header-rank/header-rank.component';
import { UsersRankListComponent } from './pages/leaderboard/users-rank-list/users-rank-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import {NgxPaginationModule} from 'ngx-pagination';
import { ArticlesComponent } from './pages/articles/articles.component';
import { ExamComponent } from './pages/exam/exam.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    HomeComponent,
    FooterComponent,
    ArticleComponent,
    LeaderboardComponent,
    CourseComponent,
    LoginComponent,
    RegisterComponent,
    TeamComponent,
    UserRankComponent,
    HeaderRankComponent,
    UsersRankListComponent,
    ExamComponent,
    ArticlesComponent,
    MyprofileComponent,
    AddarticleComponent,
    EditarticleComponent,
    WelcomeComponent

   ],
  imports: [
    BrowserAnimationsModule,
    NgxPaginationModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    Ng2SearchPipeModule,
    ToastrModule.forRoot()
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
