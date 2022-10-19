import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Schedule } from '../models/schedule.model';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  private _baseUrl = `${environment.api}/Schedule`;

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Array<Schedule>> {
    return this.httpClient.get<Array<Schedule>>(this._baseUrl);
  }
}
