import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    validRange: {
      start: '2022-10-09',
      end: '2022-10-16'
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

}
