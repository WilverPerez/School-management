import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Dictionary } from '@fullcalendar/angular';
import { Student } from 'src/app/models/student.model';
import { TableConfiguration } from 'src/app/models/table-configuration.model';
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
  data!: Array<Student>;
  assignatureId: string = '';
  courseId: string = '';
  hasLoaded: boolean = false;

  constructor(
    private studentService: StudentService,
    private route: ActivatedRoute) { }

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
    if(!this.configuration) return;
    this.data = this.configuration.data;
    this._totalRows = this.configuration.data.length;
    const page = Math.floor(this._totalRows / this._maxPerPage);
    const cantPages = page < 1 ? 1 : page;
    
    this.pages = Array(cantPages).fill(1).map((x, i) => i+1);
  }

}
