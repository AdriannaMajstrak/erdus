import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RequestService } from '../../_services';
import { RequestDetails } from '../interfaces/request-details';
import { CommentStmt } from '@angular/compiler';

@Component({
  selector: 'app-request-detail',
  templateUrl: './request-detail.component.html',
    styleUrls: ['./request-detail.component.less'],
})
export class RequestDetailComponent implements OnInit {

    coordinatesList: Coordinates[] = [];
    request: RequestDetails;
    errorMessage = 'Błąd ładowania szczegółów';
    requestId: number;

    constructor(private route: ActivatedRoute,
        private requestService: RequestService) { }


    ngOnInit() {

        const param = this.route.snapshot.paramMap.get('id');

        if (param) {
            const id = +param;
            this.requestId = id;
        }
    }

    mapInitialized() {
        this.getRequest(this.requestId);
    }

    getRequest(id: number) {        
        this.requestService.getRequestById(id).subscribe({
            next: request => {
            this.request = request;
                this.coordinatesList = [{
                    longitude: this.request.longitude,
                    latitude: this.request.latitude,
                    accuracy: 0,
                    altitude: 0,
                    altitudeAccuracy: 0,
                    heading: 0,
                    speed: 0
                }]
            },
            error: err => this.errorMessage = err
        });
    }

  canEdit(): boolean {
    return this.request.userPermissions.canEdit && this.request.statusId == 1; //status o  id 1 to status nowy/zgloszny. tylko wtedy mozna dokonac edycji 
  }

}
