import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';

@Component({
  selector: 'app-asignature',
  templateUrl: './asignature.component.html',
  styleUrls: ['./asignature.component.scss']
})
export class AsignatureComponent implements OnInit {

  configuration: TableConfiguration<Course> = {
    title: 'Asignaturas',
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
