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

@NgModule({
  declarations: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent,
    AssignementListComponent,
    StudentListComponent,
    SwitchListComponent
  ],
  imports: [
    NgbModule,
    FontAwesomeModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    HttpClientModule
  ],
  exports: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent,
    AssignementListComponent,
    StudentListComponent,
    SwitchListComponent
  ],
  providers: [],
  bootstrap: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

})
export class SharedModule { }
