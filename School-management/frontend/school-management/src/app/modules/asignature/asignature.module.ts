import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AsignatureRoutesModule, components } from './asignature.routing';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    AsignatureRoutesModule
  ],
  declarations: [...components],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AsignatureModule { }
