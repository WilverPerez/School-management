import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AssignementListComponent } from './components/assignement-list/assignement-list.component';
import { StudentListComponent } from './components/student-list/student-list.component';
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
  }
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
