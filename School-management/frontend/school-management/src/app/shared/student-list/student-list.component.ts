import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss']
})
export class StudentListComponent implements OnInit {

  studentList!: Array<Student>;

  constructor(private studentService: StudentService) { }

  ngOnInit() {
    this._bootstrap();
  }

  private _bootstrap() {
    this._loadStudents();
  }

  private _loadStudents() {
    this.studentService.getAll().subscribe(students => {
      this.studentList = students;
    });
  }

}
