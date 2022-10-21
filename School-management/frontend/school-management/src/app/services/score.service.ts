import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Score } from '../models/score.model';
import { StudentAssistance } from '../models/student-assistance.model';

@Injectable({
  providedIn: 'root'
})
export class ScoreService {

  private _baseUrl = `${environment.api}/Score`;

  constructor(private httpClient: HttpClient) { }

  public persist(assistance: Array<Score>): Observable<boolean> {
    return this.httpClient.post<boolean>(this._baseUrl, assistance);
  }
  
  public getByAssignature(courseId: string, assignatureId: string) {
    return this.httpClient.get<Array<StudentAssistance>>(this._baseUrl, {params: { courseId, assignatureId}});
  }
}
