import { Injectable } from '@angular/core';
import { DataTableSettings } from '../shared/datatableSettings';
import { DatatableSettingsForUsers } from '../shared/datatableSettingsForUsers';
import { Observable } from 'rxjs';
import { of } from 'rxjs'

@Injectable({ providedIn: 'root' })
export class AppSettingService {

  getDataTablesSettings(): Observable<DataTables.Settings> {
    return of(new DataTableSettings())
  }

  getDataTablesSettingsForUsers(): Observable<DataTables.Settings> {
    return of(new DatatableSettingsForUsers())
  }
}

