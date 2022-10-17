import { Component, Input, OnInit } from '@angular/core';
import { SwitchConfiguration } from 'src/app/models/switch-configuration.model';

@Component({
  selector: 'app-switch-list',
  templateUrl: './switch-list.component.html',
  styleUrls: ['./switch-list.component.scss']
})
export class SwitchListComponent implements OnInit {

  @Input() configuration!: SwitchConfiguration<any>;

  constructor() { }

  ngOnInit() {
  }

  // public setData<T>(data: Array<T>) {
  //   this.configuration.data = data.map<SwitchData<T>>(item => {
  //     return {
  //       label: '',
  //       checked: false
  //     }
  //   })
  // }

}
