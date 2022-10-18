import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import * as moment from 'moment';
import { TableConfiguration } from 'src/app/models/table-configuration.model';

@Component({
  selector: 'app-assignature-detail',
  templateUrl: './assignature-detail.component.html',
  styleUrls: ['./assignature-detail.component.scss']
})
export class AssignatureDetailComponent implements OnInit {

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    // validRange: {
    //   start: this._startDate,
    //   end: this._currentDate
    // },
    contentHeight: 100,
    handleWindowResize: true,
    aspectRatio: 1,
    expandRows: true,
    headerToolbar: {
      start: '', 
      center: 'title',
      end: ''
    },
    locale: 'es'
  };
  
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

  private get _currentDate() {
    return moment('2022-10-22').add(1, 'days').format('YYYY-MM-DD');
  }

  private get _startDate() {
    return moment('2022-10-22').subtract(6, 'days').format('YYYY-MM-DD');
  }

}
