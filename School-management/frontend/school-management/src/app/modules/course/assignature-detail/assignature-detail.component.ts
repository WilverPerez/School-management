import { Component, OnInit } from '@angular/core';
import { StudentAssistance } from 'src/app/models/student-assistance.model';
import { Student } from 'src/app/models/student.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';

@Component({
  selector: 'app-assignature-detail',
  templateUrl: './assignature-detail.component.html',
  styleUrls: ['./assignature-detail.component.scss']
})
export class AssignatureDetailComponent implements OnInit {
  
  configuration: TableConfiguration<StudentAssistance> = {
    title: 'Alumnos',
    icon: 'school',
    headers: [
      {
        label: 'name',
        value: (item) => item.fullName,
        primary: true
      }
    ],
    data: []
  }
  assistenceMode = true;

  constructor() { }

  ngOnInit() {}

  public onChangeMode() {
    this.assistenceMode = !this.assistenceMode;
  }
}
