import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseComponent } from './course.component';

const routes: Routes = [
  {
    path: '',
    component: CourseComponent
  },
];

export const components = [
  CourseComponent
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})
export class CourseRoutesModule { };
