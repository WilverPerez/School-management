import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import * as moment from 'moment';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    validRange: {
      start: this._startDate,
      end: this._currentDate
    },
    contentHeight:100,
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
