import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AsignatureRoutesModule, components } from './asignature.routing';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    AsignatureRoutesModule
  ],
  declarations: [...components]
})
export class AsignatureModule { }
