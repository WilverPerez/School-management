import { Component, OnInit } from '@angular/core';
import { SwitchConfiguration } from 'src/app/models/switch-configuration.model';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrls: ['./create-student.component.scss']
})
export class CreateStudentComponent implements OnInit {

  coursesConfiguration: SwitchConfiguration<any> = {
    title: 'Cursos',
    data: [
      {
        id: 'spanish',
        label: 'Lengua Española',
        checked: true
      },
      {
        id: 'math',
        label: 'Matematicas',
        checked: false
      },
      {
        id: 'history',
        label: 'Ciencias Sociales',
        checked: false
      },
      {
        id: 'science',
        label: 'Ciencias Naturales',
        checked: false
      }
    ]
  }

  assignatureConfiguration: SwitchConfiguration<any> = {
    title: 'Asignaturas',
    data: [
      {
        id: 'spanish',
        label: 'Lengua Española',
        checked: true
      },
      {
        id: 'math',
        label: 'Matematicas',
        checked: false
      },
      {
        id: 'history',
        label: 'Ciencias Sociales',
        checked: false
      },
      {
        id: 'science',
        label: 'Ciencias Naturales',
        checked: false
      }
    ]
  }
  
  constructor() { }

  ngOnInit() {
  }

}
