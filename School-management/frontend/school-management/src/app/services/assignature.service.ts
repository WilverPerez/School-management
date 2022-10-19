import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Assignature } from '../models/assignature.model';

@Injectable({
  providedIn: 'root'
})
export class AssignatureService {

  private _baseUrl = `${environment.api}/Assignature`;

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Array<Assignature>> {
    return this.httpClient.get<Array<Assignature>>(this._baseUrl);
  }
  
  public persist(assignature: Assignature): Observable<boolean> {
    return this.httpClient.post<boolean>(this._baseUrl, assignature);
  }
}
