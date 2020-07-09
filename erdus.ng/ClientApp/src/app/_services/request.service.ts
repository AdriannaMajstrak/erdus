import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Request } from '../requests/interfaces/request';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { RequestDetails } from '../requests/interfaces/request-details';
import { RequestCreate } from '../requests/interfaces/request-create';
import { RequestEdit } from '../requests/interfaces/request-edit';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

    constructor(private http: HttpClient) { }

    getAllRequest(): Observable<Request[]>{
        return this.http.get<Request[]>(`${environment.apiUrl}/requests/`);            
    }

    getAllUserRequest(): Observable<Request[]> {
        return this.http.get<Request[]>(`${environment.apiUrl}/requests/my`);
    }

    getAllResponsiblePersonRequest(): Observable<Request[]> {
        return this.http.get<Request[]>(`${environment.apiUrl}/requests/responsibility`);
    }

    getRequestById(id: number): Observable<RequestDetails> {
        return this.http.get<RequestDetails>(`${environment.apiUrl}/requests/${id}`)
    }

    createRequest(requestCreateItem: RequestCreate): Observable<string> {
        const formData = new FormData();
        formData.append('file', requestCreateItem.file);
        formData.append('topic', requestCreateItem.topic);
        formData.append('location', requestCreateItem.location);
        formData.append('address', requestCreateItem.address);
        formData.append('content', requestCreateItem.content);
        formData.append('categoryId', requestCreateItem.categoryId.toString());

        return this.http.post<string>(`${environment.apiUrl}/requests/`, formData, {
        });
    }

    editRequest(requestEditPostItem: RequestEdit): Observable<string> {
        const formData = new FormData();
        formData.append('id', requestEditPostItem.id.toString());
        formData.append('file', requestEditPostItem.file);        
        formData.append('location', requestEditPostItem.location);
        formData.append('address', requestEditPostItem.address);
        formData.append('content', requestEditPostItem.content);
        formData.append('categoryId', requestEditPostItem.categoryId.toString());

        return this.http.put<string>(`${environment.apiUrl}/requests/${requestEditPostItem.id}`, formData, {
        });
    }

    deleteRequest(id: number): Observable<string> {
        return this.http.delete<string>(`${environment.apiUrl}/requests/${id}`);
    }

    editRequestStatus(requestId: number, statusId: number, answer: string ): Observable<string> {
      return this.http.put<string>(`${environment.apiUrl}/requests/${requestId}/status`, { newStatusId: statusId, answer: answer}, {});
    }

    editRequestResponsiblePerson(requestId: number, personId: string): Observable<string> {
        return this.http.put<string>(`${environment.apiUrl}/requests/${requestId}/responsibility`, { newUserGuid: personId }, {});
    }

}
