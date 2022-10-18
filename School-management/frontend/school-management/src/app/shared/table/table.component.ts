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
  search: string = '';
  @Input() configuration!: TableConfiguration<any>;
  data: any;
  constructor() {}

  ngOnInit(): void { 
    if(!this.configuration) return;
    this.data = this.configuration.data;
    this._totalRows = this.configuration.data.length;
    const page = Math.floor(this._totalRows / this._maxPerPage);
    const cantPages = page < 1 ? 1 : page;
    
    this.pages = Array(cantPages).fill(1).map((x, i) => i+1);
  }

  filter() {
    // this.data = this.configuration.data.filter(row: Course => {
    //   const eso = (row as string).toString().includes(this.search);
      
    //   return (row as string).toString().indexOf(this.search) > -1;
    // })

    // this.data = this.configuration.data.filter(row => {
    //   const eso = (row as string).toString().includes(this.search);
      
    //   return (row as string).toString().indexOf(this.search) > -1;
    // })
  }
}
