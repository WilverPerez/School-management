import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
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
  
  public persist(student: Student): Observable<boolean> {
    return this.httpClient.post<boolean>(this._baseUrl, student);
  }
}
