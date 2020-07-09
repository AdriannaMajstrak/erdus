import { Component, OnInit } from '@angular/core';
import { RequestService } from '../../_services';
import { Request } from '../interfaces/request';
import { AppSettingService } from '../../shared/appSettingService';

@Component({
  selector: 'app-requests-responsibility-list',
  templateUrl: './requests-responsibility-list.component.html',
  styleUrls: ['./requests-responsibility-list.component.less']
})
export class RequestsResponsibilityListComponent implements OnInit {

  requestsList: Request[] = null;
  errorMessage = 'Błąd';
  dtOptionsDeskop: DataTables.Settings = {}
  dtOptionsMobile: DataTables.Settings = {}

  constructor(private requestService: RequestService, private appSettingService: AppSettingService) { }


  ngOnInit() {

    this.appSettingService.getDataTablesSettingsForUsers().subscribe({
      next: options => {
        this.dtOptionsDeskop = options;
        this.dtOptionsDeskop.order = [[2, "desc"]];
        this.dtOptionsDeskop.columns = [
          { "orderable": true },
          { "orderable": true },
          { "orderable": true },
          { "orderable": true },
          { "orderable": true },
          { "orderable": true },
          { "orderable": false }
        ];

      }
    });

    this.appSettingService.getDataTablesSettingsForUsers().subscribe({
      next: options => {
        this.dtOptionsMobile = options;
        this.dtOptionsMobile.columns = [
          { "orderable": true },
          { "orderable": true },
          { "orderable": true }
        ];
      }
    });



    this.requestService.getAllResponsiblePersonRequest().subscribe({
      next: requests => {
        this.requestsList = requests;
      },
      error: err => this.errorMessage = err
    });
  }

}
