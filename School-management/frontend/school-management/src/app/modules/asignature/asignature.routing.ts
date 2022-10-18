import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AsignatureComponent } from './asignature.component';
import { CreateAssignatureComponent } from './create-assignature/create-assignature.component';

const routes: Routes = [
  {
    path: '',
    component: AsignatureComponent
  },
  {
    path: 'create',
    component: CreateAssignatureComponent
  },
];

export const components = [
  AsignatureComponent,
  CreateAssignatureComponent
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class AsignatureRoutesModule { };
