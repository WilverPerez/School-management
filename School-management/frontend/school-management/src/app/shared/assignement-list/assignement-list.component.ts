import { Component, OnInit } from '@angular/core';
import { AssignatureList } from 'src/app/models/assignature-list.model';
import { AssignatureService } from 'src/app/services/assignature.service';

@Component({
  selector: 'app-assignement-list',
  templateUrl: './assignement-list.component.html',
  styleUrls: ['./assignement-list.component.scss']
})
export class AssignementListComponent implements OnInit {

  assignatureList!: Array<AssignatureList>;

  constructor(private assignatureService: AssignatureService) { }

  ngOnInit() {
    this._bootstrap();
  }

  private _bootstrap() {
    this._loadAssignatures();
  }

  private _loadAssignatures() {
    this.assignatureService.getAll().subscribe(assignatures => {
      this.assignatureList = assignatures;
      console.log(assignatures);
    });
  }

}
