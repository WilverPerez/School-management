import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { components, StudentRoutesModule } from './student.routing';

@NgModule({
  imports: [
    CommonModule,
    StudentRoutesModule,
    SharedModule
  ],
  declarations: [...components],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class StudentModule { }
