import { Component, OnInit } from '@angular/core';
import { Assignature } from 'src/app/models/assignature.model';
import { Course } from 'src/app/models/course.model';
import { SwitchConfiguration, SwitchData } from 'src/app/models/switch-configuration.model';
import { AssignatureService } from 'src/app/services/assignature.service';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-create-assignature',
  templateUrl: './create-assignature.component.html',
  styleUrls: ['./create-assignature.component.scss']
})
export class CreateAssignatureComponent implements OnInit {

  courseConfiguration: SwitchConfiguration<any> = {
    title: 'Cursos',
    data: []
  }
  
  constructor(private courseService: CourseService,
              private assignatureService: AssignatureService) { }

  ngOnInit() {
    this._boostrap();
  }

  private _boostrap() {
    this.courseService.getAll().subscribe(schedule => {
      this.courseConfiguration.data = schedule.map<SwitchData<Course>>(sch => {
        return {
          id: sch.id,
          label: sch.name,
          checked: false
        }
      })
    });
  }

  public persist() {
      let assignature: Assignature = {
          id: '',
          name: '',
          courses: []
      };

      assignature.name = 'Test 1S';
      assignature.courses = this.courseConfiguration.data.filter(course => course.checked).map<Course>(course => {
        console.log(course);
        
        return {
          id: course.id,
          name: course.label,
          asignatureCount: 0,
          studentCount: 0,
          schedule: ''
        }
      });

      this.assignatureService.persist(assignature).subscribe({
        next: () => alert('Success')
      })
  }

}
