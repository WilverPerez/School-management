import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  configuration: TableConfiguration<Course> = {
    title: 'Cursos',
    icon: 'school',
    headers: [
      {
        label: 'name',
        value: (item) => item.name,
        primary: true
      },
      {
        label: 'schedule',
        value: (item) => item.schedule
      },
      {
        label: 'studentCount',
        value: (item) => item.studentCount + ' Students'
      },
      {
        label: 'asignatureCount',
        value: (item) => item.asignatureCount + ' Asignatures'
      }
    ],
    data: []
  }
  
  constructor() { }

  ngOnInit() {
  }

}
