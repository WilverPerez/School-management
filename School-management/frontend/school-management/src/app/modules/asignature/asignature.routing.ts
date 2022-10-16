import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AsignatureComponent } from './asignature.component';

const routes: Routes = [
  {
    path: '',
    component: AsignatureComponent
  },
];

export const components = [
  AsignatureComponent
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class AsignatureRoutesModule { };
