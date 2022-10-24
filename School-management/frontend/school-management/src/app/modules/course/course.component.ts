import { Component, OnInit, ViewChild } from '@angular/core';
import { CourseList } from 'src/app/models/course-list.model';
import { Course } from 'src/app/models/course.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
import { CourseService } from 'src/app/services/course.service';
import { TableComponent } from 'src/app/shared/table/table.component';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {

  configuration: TableConfiguration<CourseList> = {
    title: 'Cursos',
    icon: 'school',
    headers: [
      {
        label: 'name',
        value: (item) => item.name,
        primary: true
      },
      // {
      //   label: 'schedule',
      //   value: (item) => item.schedule
      // },
      {
        label: 'studentCount',
        value: (item) => item.studentCount + ' Students'
      },
      {
        label: 'asignatureCount',
        value: (item) => item.assignatureCount + ' Asignatures'
      }
    ],
    data: []
  }

  @ViewChild('table') table!: TableComponent;
  
  constructor(private courseService: CourseService) { }

  ngOnInit() {
    this._bootstrap();
  }

  private _bootstrap() {
    this._loadCourses();
  }

  private _loadCourses() {
    this.courseService.getAll().subscribe(courses => {
      this.configuration.data = courses;
      this.table.refresh();
    });
  }

}
