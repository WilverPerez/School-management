import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AssistanceValue } from 'src/app/enums/assistance-value.enum';
import { Assignature } from 'src/app/models/assignature.model';
import { Assistance } from 'src/app/models/assistance.model';
import { StudentAssistance } from 'src/app/models/student-assistance.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
import { AssistanceService } from 'src/app/services/assistance.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-assistance',
  templateUrl: './assistence.component.html',
  styleUrls: ['./assistence.component.scss']
})
export class AssistanceComponent implements OnInit {

  private _totalRows = 0;
  private _maxPerPage = 10;
  pages: Array<number> = [];
  search: string = '';
  @Input() configuration!: TableConfiguration<StudentAssistance>;
  data!: Array<StudentAssistance>;
  assignatureId: string = '';
  courseId: string = '';
  hasLoaded: boolean = false;
  assistanceValue = AssistanceValue;

  constructor(
    private studentService: StudentService,
    private route: ActivatedRoute,
    private assistanceService: AssistanceService) { }

  ngOnInit(): void {
    this._bootstrap();
    this._loadStudent();
  }

  private _bootstrap() {
    this.courseId = this.route.snapshot.params['id'];
    this.assignatureId = this.route.snapshot.params['assignatureId'];
    this._initializeTable();
  }

  filter() {
    // this.data = this.configuration.data.filter(row: Course => {
    //   const eso = (row as string).toString().includes(this.search);

    //   return (row as string).toString().indexOf(this.search) > -1;
    // })

    // this.data = this.configuration.data.filter(row => {
    //   const eso = (row as string).toString().includes(this.search);

    //   return (row as string).toString().indexOf(this.search) > -1;
    // })
  }

  private _loadStudent() {
    this.studentService.getByAssignatureIntoCourse(this.courseId, this.assignatureId).subscribe({
      next: student => {
        this.configuration.data = student;
        this.hasLoaded = true;  
        this.refresh();  
      },
      error: (error) => console.log(error)
    })
  }

  // private _loadStudent() {
  //   this.assistanceService.getByAssignatureByDate('2022-10-21', this.courseId, this.assignatureId).subscribe({
  //     next: student => {
  //       this.configuration.data = student;
  //       this.hasLoaded = true;  
  //       this.refresh();  
  //     },
  //     error: (error) => console.log(error)
  //   })
  // }

  public refresh() {
    this._bootstrap();
  }

  private _initializeTable() {
    if(!this.configuration) return;
    this.data = this.configuration.data;
    this._totalRows = this.configuration.data.length;
    const page = Math.floor(this._totalRows / this._maxPerPage);
    const cantPages = page < 1 ? 1 : page;
    
    this.pages = Array(cantPages).fill(1).map((x, i) => i+1);
  }

  public onChangeAssistance(row: StudentAssistance, assistanceValue: AssistanceValue) {
      row.value = assistanceValue;
  }

  public persist() {
    this.data.forEach(element => {
        element.dateIssue = new Date()
    });

    const assignatures = this.data.map<Assistance>((student: StudentAssistance) => {
      return {
        dateIssue: new Date(),
        value: student.value,
        studentId: student.id,
        courseId: this.courseId,
        assignatureId: this.assignatureId,
      }
    })

    this.assistanceService.persist(assignatures).subscribe({
      error: error => console.error(error)
    })
  }

}
