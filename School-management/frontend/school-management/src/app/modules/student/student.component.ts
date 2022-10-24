import { Component, OnInit, ViewChild } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { Student } from 'src/app/models/student.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
import { StudentService } from 'src/app/services/student.service';
import { TableComponent } from 'src/app/shared/table/table.component';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
export class StudentComponent implements OnInit {

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

  constructor(private studentService: StudentService) { }

  ngOnInit() {
    this._bootstrap();
  }

  private _bootstrap() {
    this.studentService.getAll().subscribe((students) => {
      this.configuration.data = students;
      console.log(this.table);
      
      this.table.refresh();
    });
  }

}
