import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SwitchConfiguration, SwitchData } from 'src/app/models/switch-configuration.model';

@Component({
  selector: 'app-switch-list',
  templateUrl: './switch-list.component.html',
  styleUrls: ['./switch-list.component.scss']
})
export class SwitchListComponent implements OnInit {

  @Input() configuration!: SwitchConfiguration<any>;
  @Input() multipleOption: boolean = true;
  @Output() onSelected: EventEmitter<any> = new EventEmitter<any>();

  constructor() { }

  ngOnInit() {
  }

  onSelectedChange(item: SwitchData<any>) {
    if(!this.multipleOption)
      this.configuration.data.filter(data => data.checked = false);
    
    item.checked = true;
    this.onSelected.emit(item);
  }
}
