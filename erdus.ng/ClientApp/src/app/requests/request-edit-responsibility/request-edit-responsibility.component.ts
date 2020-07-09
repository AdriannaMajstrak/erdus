import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RequestService, UserService } from '../../_services';
import { Status } from '../interfaces/status';
import { StatusService } from '../../_services/status.service';
import { RequestDetails } from '../interfaces/request-details';
import { UserRequest } from '../interfaces/user-request';
import { ToastService } from '../../_services/toast.service';

@Component({
    selector: 'app-request-edit-responsibility',
    templateUrl: './request-edit-responsibility.component.html',
    styleUrls: ['./request-edit-responsibility.component.less']
})
export class RequestEditResponsibilityComponent implements OnInit {

    ngOnInit(): void {
        const param = this.route.snapshot.paramMap.get('id');

        if (param) {
            const id = +param;
            this.requestId = id;
        }
    }
    
    coordinatesList: Coordinates[] = [];
    request: RequestDetails;
    errorMessage = 'Błąd ładowania szczegółów';
    requestId: number;
    allResponsiblePeople: UserRequest[];
    selectedPerson: string;
    originPerson: string;
    disableSubmitButton = true;
    disableComboBoxStatus = false;

    constructor(private route: ActivatedRoute, private requestService: RequestService, private userService: UserService, private toastService: ToastService) {
    }

    mapInitialized() {
        this.getRequest(this.requestId);
        this.getPeopleCanBeResponsible();
    }

    getRequest(id: number) {
        this.requestService.getRequestById(id).subscribe({
            next: request => {
                this.request = request;
                this.selectedPerson = this.request.responsiblePersonGuid;
                this.originPerson = this.request.responsiblePersonGuid;
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

    getPeopleCanBeResponsible() {
        this.userService.getPeopleCanBeResponsible().subscribe({
            next: people => {
                this.allResponsiblePeople = people;
            },
            error: err => this.errorMessage = err
        })
    }



    responsiblePersonChanged() {
        this.disableSubmitButton = this.selectedPerson == this.originPerson;
    }

    onSave() {
        this.disableComboBoxStatus = true;
        this.disableSubmitButton = true;
        this.requestService.editRequestResponsiblePerson(this.request.id, this.selectedPerson).subscribe({
            next: () => {
                this.toastService.Success('Zmieniono zgłoszenie').subscribe({
                    complete: () => location.href = '/#/requests',
                });
            },
            error: e => {
                this.toastService.Error('Błąd przy zapisywaniu zgłoszenia. ' + e);
                this.disableSubmitButton = false;
                this.disableComboBoxStatus = false;

            }
        });
    }
}

