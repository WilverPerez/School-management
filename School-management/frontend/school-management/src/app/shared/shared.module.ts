import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CardComponent } from './card/card.component';
import { LayoutComponent } from './layout/layout.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { TableComponent } from './table/table.component';

@NgModule({
  declarations: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent
  ],
  imports: [
    NgbModule,
    FontAwesomeModule,
    CommonModule
  ],
  exports: [
    SidebarComponent,
    LayoutComponent,
    CardComponent,
    TableComponent
  ],
  providers: [],
  bootstrap: [],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],

})
export class SharedModule { }
