import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssistanceComponent } from 'src/app/components/assistance/assistence.component';
import { ScoreComponent } from 'src/app/components/score/score.component';
import { AssignatureDetailComponent } from './assignature-detail/assignature-detail.component';
import { CourseComponent } from './course.component';
import { CreateCourseComponent } from './create-course/create-course.component';
import { DetailComponent } from './detail/detail.component';

const routes: Routes = [
  {
    path: '',
    component: CourseComponent
  },
  {
    path: 'create',
    component: CreateCourseComponent
  },
  {
    path: 'detail/:id',
    component: DetailComponent
  },
  {
    path: 'edit/:id',
    component: CreateCourseComponent
  },
  {
    path: 'detail/:id/assignature/:assignatureId',
    component: AssignatureDetailComponent
  },
];

export const components = [
  CourseComponent,
  CreateCourseComponent,
  DetailComponent,
  AssignatureDetailComponent,
  AssistanceComponent,
  ScoreComponent
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class CourseRoutesModule { };
