import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Assistance } from '../models/assistance.model';
import { StudentAssistance } from '../models/student-assistance.model';

@Injectable({
  providedIn: 'root'
})
export class AssistanceService {

  private _baseUrl = `${environment.api}/Assistance`;

  constructor(private httpClient: HttpClient) { }

  public persist(assistance: Array<Assistance>): Observable<boolean> {
    return this.httpClient.post<boolean>(this._baseUrl, assistance);
  }
  
  public getByAssignatureByDate(dateIssue: string, courseId: string, assignatureId: string) {
    return this.httpClient.get<Array<StudentAssistance>>(this._baseUrl, {params: { dateIssue, courseId, assignatureId}});
  }
}
