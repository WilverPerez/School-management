import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Assignature } from '../models/assignature.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  private _baseUrl = `${environment.api}/Course`;

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Array<Assignature>> {
    return this.httpClient.get<Array<Assignature>>(this._baseUrl);
  }
  
  public persist(assignature: Assignature): void {
    this.httpClient.post<Assignature>(this._baseUrl, assignature);
  }
}
