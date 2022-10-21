import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { AssignatureList } from 'src/app/models/assignature-list.model';
import { Course } from 'src/app/models/course.model';
import { Schedule } from 'src/app/models/schedule.model';
import { Student } from 'src/app/models/student.model';
import { SwitchConfiguration, SwitchData } from 'src/app/models/switch-configuration.model';
import { AssignatureService } from 'src/app/services/assignature.service';
import { CourseService } from 'src/app/services/course.service';
import { ScheduleService } from 'src/app/services/schedule.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.scss']
})
export class CreateCourseComponent implements OnInit {

  assignatureConfiguration: SwitchConfiguration<AssignatureList> = {
    title: 'Asignaciones',
    data: []
  }

  scheduleConfiguration: SwitchConfiguration<Schedule> = {
    title: 'Horarios',
    data: []
  }

  studentConfiguration: SwitchConfiguration<Student> = {
    title: 'Alumnos',
    data: []
  }

  formGroup!: FormGroup;

  constructor(
    private scheduleService: ScheduleService,
    private studentService: StudentService,
    private assignatureService: AssignatureService,
    private courseService: CourseService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this._boostrap();
    this._initializeForm();
  }

  private _boostrap() {
    this._getAllSchedules(),
      this._getAllStudents(),
      this._getAllAssignatures(),
      this._seOrderDetail();
  }

  private _initializeForm() {
    this.formGroup = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      schedules: [[]],
      students: [[]],
      assignatures: [[]]
    });
  }

  private _getAllSchedules() {
    this.scheduleService.getAll().subscribe(schedule => {
      this.scheduleConfiguration.data = schedule.map<SwitchData<Schedule>>(sch => {
        return {
          id: sch.id,
          label: sch.name,
          checked: false,
          toEntity: () => sch
        };
      });
    });
  }

  private _getAllStudents() {
    this.studentService.getAllWithoutCourse().subscribe(students => {
      this.studentConfiguration.data = students.map<SwitchData<Student>>(student => {
        return {
          id: student.id,
          label: student.fullName,
          checked: false,
          toEntity: () => student
        };
      });
    });
  }

  private _getAllAssignatures() {
    this.assignatureService.getAll().subscribe(assignatures => {
      this.assignatureConfiguration.data = assignatures.map<SwitchData<AssignatureList>>(assignature => {
        return {
          id: assignature.id,
          label: assignature.name,
          checked: false,
          toEntity: () => assignature
        };
      });
    });
  }

  public onSelectAssignatures(event: SwitchData<Course>) {
    this.assignatureConfiguration.data.filter(assignature => {
      if (assignature.id === event.id) {
        assignature.checked = event.checked;
      }
    });
  }

  public onSelectSchedules(event: SwitchData<Schedule>) {
    this.scheduleConfiguration.data.filter(schedule => {
      if (schedule.id === event.id) {
        schedule.checked = event.checked;
      }
    });
  }

  public onSelectStudents(event: SwitchData<Student>) {
    this.studentConfiguration.data.filter(student => {
      if (student.id === event.id) {
        student.checked = event.checked;
      }
    });
  }

  private _seOrderDetail() {
    this.courseService.getById(this.route.snapshot.params['id']).subscribe(value => {
      this.formGroup.setValue(value);
    
      this.scheduleConfiguration.data.filter(schedule => {
        if (value.schedules.find(sch => sch.id === schedule.id)) {
          schedule.checked = true;
        }
      });

      this.studentConfiguration.data.filter(student => {
        if (value.students.find(stu => stu.id === student.id)) {
          student.checked = true;
        }
      });

      this.assignatureConfiguration.data.filter(assignature => {
        if (value.assignatures.find(asg => asg.id === assignature.id)) {
          assignature.checked = true;
        }
      });
    });
  }

  public persist() {
    const course: Course = this.formGroup.getRawValue();
    course.assignatures = this.assignatureConfiguration.data.filter(assignature => assignature.checked).map(assignature => assignature.toEntity());
    course.schedules = this.scheduleConfiguration.data.filter(schedule => schedule.checked).map(schedule => schedule.toEntity());
    course.students = this.studentConfiguration.data.filter(student => student.checked).map(student => student.toEntity());

    this.formGroup.reset();
    this.courseService.persist(course).subscribe(() => {
    });
  }

}
