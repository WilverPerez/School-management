import { Component, OnInit, ViewChild } from '@angular/core';
import { Student } from 'src/app/models/student.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
import { StudentService } from 'src/app/services/student.service';
import { TableComponent } from 'src/app/shared/table/table.component';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.scss']
})
export class ScoreListComponent implements OnInit {


  configuration: TableConfiguration<Student> = {
    title: 'Calificaciones - Alumnos',
    icon: 'school',
    hideAddBtn: true,
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
