import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Status } from '../requests/interfaces/status';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

    constructor(private http: HttpClient) { }

    getAllStatuses(): Observable<Status[]> {
        return this.http.get<Status[]>(`${environment.apiUrl}/statuses/`);
    }
}
