import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AssignementListComponent } from './assignement-list/assignement-list.component';
import { StudentListComponent } from './student-list/student-list.component';
import { CardComponent } from './card/card.component';
import { LayoutComponent } from './layout/layout.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { SwitchListComponent } from './switch-list/switch-list.component';
import { TableComponent } from './table/table.component';
import { HttpClientModule } from '@angular/common/http';
import { CalendarComponent } from '../components/calendar/calendar.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';

FullCalendarModule.registerPlugins([
  dayGridPlugin,
]);
@NgModule({
  declarations: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent,
    AssignementListComponent,
    StudentListComponent,
    SwitchListComponent,
    CalendarComponent
  ],
  imports: [
    NgbModule,
    FontAwesomeModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    FullCalendarModule
  ],
  exports: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent,
    AssignementListComponent,
    StudentListComponent,
    SwitchListComponent,
    ReactiveFormsModule,
    CalendarComponent
  ],
  providers: [],
  bootstrap: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

})
export class SharedModule { }
