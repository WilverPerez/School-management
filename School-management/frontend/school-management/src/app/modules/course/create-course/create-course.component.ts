import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course.model';
import { Schedule } from 'src/app/models/schedule.model';
import { SwitchConfiguration, SwitchData } from 'src/app/models/switch-configuration.model';
import { ScheduleService } from 'src/app/services/schedule.service';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.scss']
})
export class CreateCourseComponent implements OnInit {

  assignatureConfiguration: SwitchConfiguration<Course> = {
    title: 'Asignaciones',
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

  scheduleConfiguration: SwitchConfiguration<Schedule> = {
    title: 'Horarios',
    data: []
  }

  studentConfiguration: SwitchConfiguration<Course> = {
    title: 'Alumnos',
    data: [
      {
        id: 'Lunes',
        label: 'Lunes',
        checked: true
      },
      {
        id: 'Martes',
        label: 'Martes',
        checked: false
      },
      {
        id: 'Miercoles',
        label: 'Miercoles',
        checked: false
      },
      {
        id: 'Jueves',
        label: 'Jueves',
        checked: false
      },
      {
        id: 'Viernes',
        label: 'Viernes',
        checked: false
      }
    ]
  }

  constructor(private scheduleService: ScheduleService) { }

  ngOnInit() {
    this._boostrap();
  }

  private _boostrap() {
    this.scheduleService.getAll().subscribe(schedule => {
      this.scheduleConfiguration.data = schedule.map<SwitchData<Schedule>>(sch => {
        return {
          id: sch.id,
          label: sch.name,
          checked: false
        }
      })
    })
  }

}
