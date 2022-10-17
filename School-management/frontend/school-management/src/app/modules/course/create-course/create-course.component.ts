import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { SwitchConfiguration } from 'src/app/models/switch-configuration.model';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.scss']
})
export class CreateCourseComponent implements OnInit {

  assignatureConfiguration: SwitchConfiguration<Course> = {
    title: 'Asignaciones',
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
  
  scheduleConfiguration: SwitchConfiguration<Course> = {
    title: 'Horarios',
    data: [
      {
        id: 'Lunes',
        label: 'Lunes',
        checked: true
      },
      {
        id: 'Martes',
        label: 'Martes',
        checked: false
      },
      {
        id: 'Miercoles',
        label: 'Miercoles',
        checked: false
      },
      {
        id: 'Jueves',
        label: 'Jueves',
        checked: false
      },
      {
        id: 'Viernes',
        label: 'Viernes',
        checked: false
      }
    ]
  }

  studentConfiguration: SwitchConfiguration<Course> = {
    title: 'Alumnos',
    data: [
      {
        id: 'Lunes',
        label: 'Lunes',
        checked: true
      },
      {
        id: 'Martes',
        label: 'Martes',
        checked: false
      },
      {
        id: 'Miercoles',
        label: 'Miercoles',
        checked: false
      },
      {
        id: 'Jueves',
        label: 'Jueves',
        checked: false
      },
      {
        id: 'Viernes',
        label: 'Viernes',
        checked: false
      }
    ]
  }

  constructor() { }

  ngOnInit() {
  }

}
