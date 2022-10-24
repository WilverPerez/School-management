import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  {
    path: 'student',
    loadChildren: () => import('./modules/student/student.module').then(m => m.StudentModule)
  },
  {
    path: 'assignature',
    loadChildren: () => import('./modules/asignature/asignature.module').then(m => m.AsignatureModule)
  },
  {
    path: 'course',
    loadChildren: () => import('./modules/course/course.module').then(m => m.CourseModule)
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'score',
    loadChildren: () => import('./modules/score/score.module').then(m => m.ScoreModule)
  },
];

export const components = [
  AppComponent,
  HomeComponent
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
