import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  sidebarOptions = [
    {
      label: 'Inicio',
      actived: true,
      icon: 'home-outline',
      path: 'home'
    },
    {
      label: 'Cursos',
      actived: false,
      icon: 'school-outline',
      path: 'course'
    },
    {
      label: 'Asignaturas',
      actived: false,
      icon: 'book-outline',
      path: 'assignature'
    },
    {
      label: 'Estudiantes',
      actived: false,
      icon: 'people-outline',
      path: 'student'
    }
  ]
  constructor(private route: Router) { }

  ngOnInit() {
  }

  navigate(option: any) {
      this.sidebarOptions.map(option => option.actived = false);
      option.actived = true;
      this.route.navigate([`/${option.path}`]);
  }

}
