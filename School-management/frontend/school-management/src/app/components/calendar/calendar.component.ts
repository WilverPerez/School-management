import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import * as moment from 'moment';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {
  
  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    validRange: {
      start: this._startDate,
      end: this._currentDate
    },
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
