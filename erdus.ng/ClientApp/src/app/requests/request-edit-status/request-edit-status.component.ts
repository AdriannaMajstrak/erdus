import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RequestService } from '../../_services';
import { Status } from '../interfaces/status';
import { StatusService } from '../../_services/status.service';
import { RequestDetails } from '../interfaces/request-details';
import { ToastService } from '../../_services/toast.service';

@Component({
  selector: 'app-request-edit-status',
  templateUrl: './request-edit-status.component.html',
  styleUrls: ['./request-edit-status.component.less']
})
export class RequestEditStatusComponent implements OnInit {

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
  allStatuses: Status[];
  selectedStatus: number;
  newAnswer: string;
  originStatus: number;
  originalAnswer: string;
  disableSubmitButton = true;
  disableComboBoxAndText = false;

  constructor(private route: ActivatedRoute, private requestService: RequestService, private statusService: StatusService, private toastService: ToastService) {
  }

  mapInitialized() {
    this.getRequest(this.requestId);
    this.getStatusesList();
  }

  getRequest(id: number) {
    this.requestService.getRequestById(id).subscribe({
      next: request => {
        this.request = request;
        this.selectedStatus = this.request.statusId;
        this.originStatus = this.request.statusId;
        this.originalAnswer = this.request.answer;
        this.newAnswer = this.request.answer;
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

  getStatusesList() {
    this.statusService.getAllStatuses().subscribe({
      next: statuses => {
        this.allStatuses = statuses;
      },
      error: err => this.errorMessage = err
    })
  }

  changedAnswer(newAnswer: string) {
    this.newAnswer = newAnswer;
    this.disableSubmitButton = (this.selectedStatus == this.originStatus) && (this.newAnswer == this.originalAnswer);
  }

  changed() {
    this.disableSubmitButton = (this.selectedStatus == this.originStatus) && (this.newAnswer == this.originalAnswer);
  }

  onSave() {
    this.disableComboBoxAndText = true;
    this.disableSubmitButton = true;
    this.requestService.editRequestStatus(this.request.id, this.selectedStatus, this.newAnswer).subscribe({
      next: () => {
        this.toastService.Success('Zmieniono zgłoszenie').subscribe({
          complete: () => location.href = '/#/requests',
        });
      },
      error: e => {
        this.toastService.Error('Błąd przy zapisywaniu zgłoszenia. ' + e);
        this.disableSubmitButton = false;
        this.disableComboBoxAndText = false;

      }
    });
  }
}

