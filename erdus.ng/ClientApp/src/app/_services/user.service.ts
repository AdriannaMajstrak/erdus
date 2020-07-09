import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@app/_models';
import { UserRequest } from '../requests/interfaces/user-request';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    //getAll() {
    //    return this.http.get<User[]>(`${environment.apiUrl}/users`);
    //}

    getById(id: number) {
        return this.http.get<User>(`${environment.apiUrl}/users/${id}`);
    }

    getPeopleCanBeResponsible() {
        return this.http.get<UserRequest[]>(`${environment.apiUrl}/users/peopleCanBeResponsible`);
    }


}
