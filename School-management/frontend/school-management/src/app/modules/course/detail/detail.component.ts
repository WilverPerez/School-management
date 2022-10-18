import { Component, OnInit } from '@angular/core';
import { TableConfiguration } from 'src/app/models/table-configuration.model';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {

  configuration: TableConfiguration<any> = {
    title: 'Alumnos',
    icon: 'school',
    headers: [
      {
        label: 'name',
        value: (item) => item.name,
        primary: true
      },
      {
        label: 'tutor',
        value: (item) => item.tutor + ' (Tutor / a)'
      },
      {
        label: 'linked',
        value: (item) => item.linked + ' (Vinculo)'
      }
    ],
    data: [
      {
        name: 'Anthony Perez',
        tutor: 'Faustina Romero',
        linked: 'Madre'
      },
      {
        name: 'Alejandro Garcia',
        tutor: 'Faustina Romero',
        linked: 'Madre'
      },
      {
        name: 'Wilson Perez',
        tutor: 'Faustina Romero',
        linked: 'Madre'
      }
    ]
  }
  
  constructor() { }

  ngOnInit() {
  }

}
