import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateStudentComponent } from './create-student/create-student.component';
import { StudentComponent } from './student.component';

const routes: Routes = [
  {
    path: '',
    component: StudentComponent
  },
  {
    path: 'create',
    component: CreateStudentComponent
  },
];

export const components = [
  StudentComponent,
  CreateStudentComponent
]

@NgModule({
  imports: [RouterModule.forChild(routes)]
})

export class StudentRoutesModule { }
