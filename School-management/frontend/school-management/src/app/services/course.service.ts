import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CourseList } from '../models/course-list.model';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private _baseUrl = `${environment.api}/Course`;

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Array<CourseList>> {
    return this.httpClient.get<Array<CourseList>>(this._baseUrl);
  }
  
  public persist(course: Course): Observable<boolean> {
    return this.httpClient.post<boolean>(this._baseUrl, course);
  }
  
  public getById(courseId: string): Observable<Course> {
    return this.httpClient.get<Course>(this._baseUrl + '/by-id', {params: {courseId}});
  }
}
