import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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
    path: 'detail',
    component: DetailComponent
  },
  {
    path: 'detail/assignature',
    component: AssignatureDetailComponent
  },
];

export const components = [
  CourseComponent,
  CreateCourseComponent,
  DetailComponent,
  AssignatureDetailComponent
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class CourseRoutesModule { };
