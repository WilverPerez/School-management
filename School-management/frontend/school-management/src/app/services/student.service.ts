import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StudentAssistance } from '../models/student-assistance.model';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private _baseUrl = `${environment.api}/Student`;

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Array<Student>> {
    return this.httpClient.get<Array<Student>>(this._baseUrl);
  }
  
  public getAllWithoutCourse(): Observable<Array<Student>> {
    return this.httpClient.get<Array<Student>>(this._baseUrl + '/without-course');
  }
  
  public persist(student: Student): Observable<boolean> {
    return this.httpClient.post<boolean>(this._baseUrl, student);
  }

  public getByAssignatureIntoCourse(courseId: string, assignatureId: string) {
    return this.httpClient.get<Array<StudentAssistance>>(this._baseUrl + '/by-assignature', {params: {courseId, assignatureId}});
  }
}
