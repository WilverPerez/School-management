import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { components, CourseRoutesModule } from './course.routing';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CourseRoutesModule
  ],
  declarations: [...components]
})
export class CourseModule { }
