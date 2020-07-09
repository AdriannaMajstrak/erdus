import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../requests/interfaces/Category';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

    constructor(private http: HttpClient) { }

    getAllCategories(): Observable<Category[]> {
        return this.http.get<Category[]>(`${environment.apiUrl}/categories/`);
    }
}
