import { Component, OnInit } from '@angular/core';
import { RequestService } from '../../_services';
import { Request } from '../interfaces/request';
import { AppSettingService } from '../../shared/appSettingService';

@Component({
  selector: 'app-requests-user-list',
  templateUrl: './requests-user-list.component.html',
  styleUrls: ['./requests-user-list.component.less']
})
export class RequestsUserListComponent implements OnInit {

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
        this.dtOptionsMobile.order = [[2, "desc"]];
        this.dtOptionsMobile.columns = [
          { "orderable": true },
          { "orderable": true },
          { "orderable": true }
        ];        
      }
    });

    this.requestService.getAllUserRequest().subscribe({
      next: requests => {
        this.requestsList = requests;
      },
      error: err => this.errorMessage = err
    });
  }

}
