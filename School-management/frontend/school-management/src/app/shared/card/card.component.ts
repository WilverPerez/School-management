import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {

  colors : Array<string> = ['blue', 'gray', 'purple'];
  index = 0;
  @Input() add: boolean = false;
  
  constructor() { 
    this.index = Math.floor((Math.random() * 3));
  }

  ngOnInit() {
  }

}
