import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Course } from 'src/app/models/course.model';
import { Student } from 'src/app/models/student.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
import { CourseService } from 'src/app/services/course.service';
import { TableComponent } from 'src/app/shared/table/table.component';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.scss']
})
export class DetailComponent implements OnInit {

  configuration: TableConfiguration<Student> = {
    title: 'Alumnos',
    icon: 'school',
    headers: [
      {
        label: 'name',
        value: (item) => item.fullName,
        primary: true
      },
      {
        label: 'tutor',
        value: (item) => item.parent.fullName + ' (Tutor / a)'
      },
      {
        label: 'linked',
        value: (item) => item.parent.link + ' (Vinculo)'
      }
    ],
    data: []
  }

  @ViewChild('table') table!: TableComponent;
  courseData!: Course;

  constructor(
    private courseService: CourseService, 
    private route: ActivatedRoute) { }

  ngOnInit() {
    this._bootstrap();
  }

  private _bootstrap() {
    this._loadStudents();
  }

  private _loadStudents() {
    this.courseService.getById(this.route.snapshot.params['id']).subscribe(course => {
      this.configuration.data = course.students;
      this.table.refresh();
    });
  }
}
