import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentComponent } from './student.component';

const routes: Routes = [
  {
    path: '',
    component: StudentComponent
  },
];

export const components = [
  StudentComponent
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})

export class StudentRoutesModule { }
