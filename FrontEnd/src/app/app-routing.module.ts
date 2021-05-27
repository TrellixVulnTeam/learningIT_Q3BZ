import { Authguard2Service as AuthGuard2} from './services/authguard2.service';
import { WelcomeComponent } from './pages/welcome/welcome.component';
import { ExamComponent } from './pages/exam/exam.component';
import { AuthguardService as AuthGuard } from './services/authguard.service';
import { EditarticleComponent } from './pages/editarticle/editarticle.component';
import { AddarticleComponent } from './pages/addarticle/addarticle.component';
import { MyprofileComponent } from './pages/myprofile/myprofile.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ArticleComponent } from './pages/article/article.component';
import { HomeComponent } from './pages/home/home.component';
import { LeaderboardComponent } from './pages/leaderboard/leaderboard.component';
import { CourseComponent } from './pages/course/course.component';
import { TeamComponent } from './pages/team/team.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { ChapterComponent } from './pages/chapter/chapter.component';
import { ArticlesComponent } from './pages/articles/articles.component';
import { CanActivate } from '@angular/router';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'welcome', component: WelcomeComponent, canActivate: [AuthGuard2]},
  { path: 'login', component: LoginComponent, canActivate: [AuthGuard2]},
  { path: 'register', component: RegisterComponent, canActivate: [AuthGuard2]},
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'article', component: ArticleComponent, canActivate: [AuthGuard]},
  { path: 'add-article', component: AddarticleComponent, canActivate: [AuthGuard] },
  { path: 'edit-article', component: EditarticleComponent, canActivate: [AuthGuard] },
  { path: 'articles', component: ArticlesComponent, canActivate: [AuthGuard] },
  { path: 'leaderboard', component: LeaderboardComponent, canActivate: [AuthGuard] },
  { path: 'course', component: CourseComponent, canActivate: [AuthGuard] },
  { path: 'chapter', component: ChapterComponent, canActivate: [AuthGuard]},
  { path: 'chapter/:id', component: ChapterComponent, canActivate: [AuthGuard] },
  { path: 'team', component: TeamComponent, canActivate: [AuthGuard]},
  { path: 'exams', component: ExamComponent, canActivate: [AuthGuard]},
  { path: 'exams/:id', component: ExamComponent, canActivate: [AuthGuard] },
  { path: 'my-profile', component: MyprofileComponent, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '/' }

];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
