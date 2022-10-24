import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { components } from './score.routing';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [...components]
})
export class ScoreModule { }
