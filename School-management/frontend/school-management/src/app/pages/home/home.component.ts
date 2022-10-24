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
}
