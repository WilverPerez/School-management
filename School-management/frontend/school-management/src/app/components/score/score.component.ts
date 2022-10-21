import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Score } from 'src/app/models/score.model';
import { StudentScore } from 'src/app/models/sctudent-score.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
import { ScoreService } from 'src/app/services/score.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-score',
  templateUrl: './score.component.html',
  styleUrls: ['./score.component.scss']
})
export class ScoreComponent implements OnInit {

  private _totalRows = 0;
  private _maxPerPage = 10;
  pages: Array<number> = [];
  search: string = '';
  @Input() configuration!: TableConfiguration<any>;
  data!: Array<StudentScore>;
  assignatureId: string = '';
  courseId: string = '';
  hasLoaded: boolean = false;
  score = 0;
  literal = 'F';

  constructor(
    private studentService: StudentService,
    private route: ActivatedRoute,
    private scoreService: ScoreService) { }

  ngOnInit(): void {
    this._bootstrap();
    this._loadStudent();
  }

  private _bootstrap() {
    this.courseId = this.route.snapshot.params['id'];
    this.assignatureId = this.route.snapshot.params['assignatureId'];
    this._initializeTable();
    this._initializeMap();
  }

  private _initializeMap() {
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

  public refresh() {
    this._bootstrap();
  }

  private _initializeTable() {
    if (!this.configuration) return;
    this.data = this.configuration.data;
    this._totalRows = this.configuration.data.length;
    const page = Math.floor(this._totalRows / this._maxPerPage);
    const cantPages = page < 1 ? 1 : page;

    this.pages = Array(cantPages).fill(1).map((x, i) => i + 1);
  }

  public persist() {
    this.data.forEach(element => {
      element.dateIssue = new Date()
    });

    const assignatures = this.data.map<Score>((student: StudentScore) => {
      return {
        dateIssue: student.dateIssue,
        value: student.value,
        studentId: student.id,
        courseId: this.courseId,
        assignatureId: this.assignatureId
      }
    })

    this.scoreService.persist(assignatures).subscribe({
      error: error => console.error(error)
    })
  }

  public setLiteral(item: StudentScore) {
    if (item.value >= 90) item.literal = 'A';
    if (item.value >= 80 && item.value <= 89) item.literal = 'B';
    if (item.value >= 70 && item.value <= 79) item.literal = 'C';
    if (item.value < 70) item.literal = 'F';
  }
}
