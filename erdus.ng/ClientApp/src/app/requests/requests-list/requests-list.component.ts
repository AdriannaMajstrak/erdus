import { Component, OnInit } from '@angular/core';
import { RequestService } from '../../_services';
import { Request } from '../interfaces/request';
import { AppSettingService } from '../../shared/appSettingService';
import { DataTableSettings } from '../../shared/datatableSettings';

@Component({
  selector: 'app-requests-list',
  templateUrl: './requests-list.component.html',
  styleUrls: ['./requests-list.component.less']
})
export class RequestsListComponent implements OnInit {

  dtOptions: DataTables.Settings = {}

  requestsList: Request[] = null;
  errorMessage = 'Błąd';

  constructor(private requestService: RequestService, private appSettingService: AppSettingService) { }

  ngOnInit() {
    this.appSettingService.getDataTablesSettings().subscribe({
      next: options => {
        this.dtOptions = options;
      }
    });

    this.requestService.getAllRequest().subscribe({
      next: requests => {
        this.requestsList = requests;
      },
      error: err => this.errorMessage = err
    });
  }

}
