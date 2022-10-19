import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FullCalendarModule } from '@fullcalendar/angular';
import { SharedModule } from 'src/app/shared/shared.module';
import { components, CourseRoutesModule } from './course.routing';
import dayGridPlugin from '@fullcalendar/daygrid';

FullCalendarModule.registerPlugins([
  dayGridPlugin,
]);

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CourseRoutesModule,
    FullCalendarModule
  ],
  declarations: [...components],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class CourseModule { }
