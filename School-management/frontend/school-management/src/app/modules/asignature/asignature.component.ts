import { Component, OnInit, ViewChild } from '@angular/core';
import { AssignatureList } from 'src/app/models/assignature-list.model';
import { Assignature } from 'src/app/models/assignature.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
import { AssignatureService } from 'src/app/services/assignature.service';
import { TableComponent } from 'src/app/shared/table/table.component';

@Component({
  selector: 'app-asignature',
  templateUrl: './asignature.component.html',
  styleUrls: ['./asignature.component.scss']
})
export class AsignatureComponent implements OnInit {

  configuration: TableConfiguration<AssignatureList> = {
    title: 'Asignaturas',
    icon: 'school',
    headers: [
      {
        label: 'name',
        value: (item) => item.name,
        primary: true
      },
      {
        label: 'courseCount',
        value: (item) => item.courseCount + ' Cursos',
        primary: false
      }
    ],
    data: []
  }

  @ViewChild('table') table!: TableComponent;

  constructor(private assignatureService: AssignatureService) { }

  ngOnInit() {
    this._bootstrap();
  }

  private _bootstrap() {
    this._loadAssignatures();
  }

  private _loadAssignatures() {
    this.assignatureService.getAll().subscribe(assignatures => {
      this.configuration.data = assignatures;
      this.table.refresh();
    });
  }
}
