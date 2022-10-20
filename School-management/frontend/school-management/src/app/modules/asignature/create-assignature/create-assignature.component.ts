import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  formGroup!: FormGroup;

  constructor(private courseService: CourseService,
    private assignatureService: AssignatureService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this._boostrap();
  }

  private _boostrap() {
    this._loadCourses();
    this._initializeForm();
  }

  private _initializeForm() {
    this.formGroup = this.formBuilder.group(
      {
        name: ['', [Validators.required, Validators.minLength(3)]],
        courses: []
      });
  }

  private _loadCourses() {
    this.courseService.getAll().subscribe(schedule => {
      this.courseConfiguration.data = schedule.map<SwitchData<Course>>(sch => {
        return {
          id: sch.id,
          label: sch.name,
          checked: false
        };
      });
    });
  }

  public persist() {
    let assignature: Assignature = this.formGroup.getRawValue();

    assignature.courses = this.courseConfiguration.data.filter(course => course.checked).map<Course>(course => {
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
