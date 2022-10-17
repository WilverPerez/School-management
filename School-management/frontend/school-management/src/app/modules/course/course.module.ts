import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { components, CourseRoutesModule } from './course.routing';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CourseRoutesModule
  ],
  declarations: [...components],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CourseModule { }
