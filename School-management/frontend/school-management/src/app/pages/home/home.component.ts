import { Component, OnInit } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/angular';
import * as moment from 'moment';
import { CourseList } from 'src/app/models/course-list.model';
import { Schedule } from 'src/app/models/schedule.model';
import { CourseService } from 'src/app/services/course.service';
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

  coursesToNow!: Array<CourseList>;

  constructor(private courseService: CourseService) { }

  ngOnInit() {
    this._bootstrap();
  }

  private _bootstrap() {
    this._loadCourses();
  }

  private _loadCourses() {
    this.courseService.getAll().subscribe(courses => {
      this.coursesToNow = courses;
    });
  }

  private get _currentDate() {
    return moment('2022-10-22').add(1, 'days').format('YYYY-MM-DD');
  }

  private get _startDate() {
    return moment('2022-10-22').subtract(6, 'days').format('YYYY-MM-DD');
  }
}
