import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseComponent } from './course.component';
import { CreateCourseComponent } from './create-course/create-course.component';

const routes: Routes = [
  {
    path: '',
    component: CourseComponent
  },
  {
    path: 'detail',
    component: CreateCourseComponent
  },
];

export const components = [
  CourseComponent,
  CreateCourseComponent
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class CourseRoutesModule { };
