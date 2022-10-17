import { Component, OnInit } from '@angular/core';
import { SwitchConfiguration } from 'src/app/models/switch-configuration.model';

@Component({
  selector: 'app-create-assignature',
  templateUrl: './create-assignature.component.html',
  styleUrls: ['./create-assignature.component.scss']
})
export class CreateAssignatureComponent implements OnInit {

  assignatureConfiguration: SwitchConfiguration<any> = {
    title: 'Cursos',
    data: [
      {
        id: 'spanish',
        label: 'Lengua Española',
        checked: true
      },
      {
        id: 'math',
        label: 'Matematicas',
        checked: false
      },
      {
        id: 'history',
        label: 'Ciencias Sociales',
        checked: false
      },
      {
        id: 'science',
        label: 'Ciencias Naturales',
        checked: false
      }
    ]
  }
  
  constructor() { }

  ngOnInit() {
  }

}
