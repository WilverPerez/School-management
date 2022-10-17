import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AssignementListComponent } from '../components/assignement-list/assignement-list.component';
import { StudentListComponent } from '../components/student-list/student-list.component';
import { CardComponent } from './card/card.component';
import { LayoutComponent } from './layout/layout.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { TableComponent } from './table/table.component';

@NgModule({
  declarations: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent,
    AssignementListComponent,
    StudentListComponent
  ],
  imports: [
    NgbModule,
    FontAwesomeModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent,
    AssignementListComponent,
    StudentListComponent
  ],
  providers: [],
  bootstrap: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

})
export class SharedModule { }
