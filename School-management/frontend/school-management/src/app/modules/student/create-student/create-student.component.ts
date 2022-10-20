import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Assignature } from 'src/app/models/assignature.model';
import { Course } from 'src/app/models/course.model';
import { Student } from 'src/app/models/student.model';
import { SwitchConfiguration, SwitchData } from 'src/app/models/switch-configuration.model';
import { AssignatureService } from 'src/app/services/assignature.service';
import { CourseService } from 'src/app/services/course.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-create-student',
  templateUrl: './create-student.component.html',
  styleUrls: ['./create-student.component.scss']
})
export class CreateStudentComponent implements OnInit {

  coursesConfiguration: SwitchConfiguration<Course> = {
    title: 'Cursos',
    data: []
  }

  assignatureConfiguration: SwitchConfiguration<Assignature> = {
    title: 'Asignaturas',
    data: []
  }

  formGroup!: FormGroup;

  constructor(
    private courseService: CourseService,
    private assignatureService: AssignatureService,
    private formBuilder: FormBuilder,
    private studentService: StudentService) { }

  ngOnInit() {
    this._initializeForm();
    this._loadCourses();
    this._loadAssignature();
  }

  private _initializeForm() {
    this.formGroup = this.formBuilder.group(
      {
        name: ['', [Validators.required, Validators.minLength(3)]],
        lastName: ['', [Validators.required, Validators.minLength(3)]],
        dateOfBorn: ['', [Validators.required, Validators.minLength(3)]],
        parent: this.formBuilder.group({
          name: ['', [Validators.required, Validators.minLength(3)]],
          lastName: ['', [Validators.required, Validators.minLength(3)]],
          email: ['', [Validators.required, Validators.minLength(3), Validators.email]],
          phoneNumber: ['', [Validators.required, Validators.minLength(3)]],
          link: ['', [Validators.required, Validators.minLength(3)]],
        }),
        courses: [],
        assignatures: []
      });
  }

  private _loadCourses() {
    this.courseService.getAll().subscribe(schedule => {
      this.coursesConfiguration.data = schedule.map<SwitchData<Course>>(sch => {
        return {
          id: sch.id,
          label: sch.name,
          checked: false
        };
      });
    });
  }

  private _loadAssignature() {
    this.assignatureService.getAll().subscribe(schedule => {
      this.assignatureConfiguration.data = schedule.map<SwitchData<Assignature>>(sch => {
        return {
          id: sch.id,
          label: sch.name,
          checked: false
        };
      });
    });
  }

  public async persist() {
    const student: Student = this.formGroup.getRawValue();

    student.courses = this._getSeletedCourses();
    student.assignatures = this._getSelectedAssignatures();

    this.studentService.persist(student).subscribe({
      error: error => {
        console.log(error);
      }
    });
  }

  private _getSeletedCourses() {
    return this.coursesConfiguration.data.filter(course => course.checked).map(course => {
      return {
        id: course.id,
        name: course.label
      };
    });
  }

  private _getSelectedAssignatures() {
    return this.assignatureConfiguration.data.filter(assignature => assignature.checked).map(assignature => {
      return {
        id: assignature.id,
        name: assignature.label,
        courseCount: 0
      };
    });
  }

  public onCourseSelectedChange(item: SwitchData<Course>) {
    this.coursesConfiguration.data.filter(course => {
      if(course.id === item.id) {
        course.checked = item.checked;
      }
    });
  }

  public onAssignatureSelectedChange(item: SwitchData<Assignature>) {
    this.assignatureConfiguration.data.filter(assignature => {
      if(assignature.id === item.id) {
        assignature.checked = item.checked;
      }
    });
  }
}
