import { Component, Input, OnInit } from '@angular/core';
import { TableConfiguration } from 'src/app/models/table-configuration.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {

  private _totalRows = 0;
  private _maxPerPage = 10;
  pages:Array<number> = [];

  @Input() configuration!: TableConfiguration<any>;

  constructor() {}

  ngOnInit(): void { 
    if(!this.configuration) return;

    this._totalRows = this.configuration.data.length;
    const page = Math.floor(this._totalRows / this._maxPerPage);
    const cantPages = page < 1 ? 1 : page;
    
    this.pages = Array(cantPages).fill(1).map((x, i) => i+1);
  }
}
