import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

// used to create fake backend
import { AppComponent } from './app.component';
import { appRoutingModule } from './app.routing';

import { JwtInterceptor, ErrorInterceptor } from './_helpers';


import { HomeComponent } from './home';
import { AdminComponent } from './admin';
import { LoginComponent } from './login';
import { RequestsListComponent } from './requests/requests-list/requests-list.component';
import { RequestCreateComponent } from './requests/request-create/request-create.component';
import { RequestDetailComponent } from './requests/request-detail/request-detail.component';
import { MapComponentComponent } from './shared/map-component/map-component.component';
import { RequestEditComponent } from './requests/request-edit/request-edit.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { RequestEditStatusComponent } from './requests/request-edit-status/request-edit-status.component';
import { RequestEditResponsibilityComponent } from './requests/request-edit-responsibility/request-edit-responsibility.component';
import { RegisterComponent } from './register/register.component';
import { RequestDeleteComponent } from './requests/request-delete/request-delete.component';
import { NgcCookieConsentModule, NgcCookieConsentConfig } from 'ngx-cookieconsent';
import { TranslateModule } from '@ngx-translate/core';
import { PrivacyComponent } from './privacy/privacy.component';
import { RequestsUserListComponent } from './requests/requests-user-list/requests-user-list.component';
import { RequestsResponsibilityListComponent } from './requests/requests-responsibility-list/requests-responsibility-list.component';
import { DataTablesModule } from 'angular-datatables';


const cookieConfig: NgcCookieConsentConfig = {
  cookie: {
    domain: 'localhost'// it is recommended to set your domain, for cookies to work properly
  },
  palette: {
    popup: {
      background: '#7e7d7d'
    },
    button: {
      background: '#000'
    }
  },
  theme: 'edgeless',
  type: 'opt-out',
  layout: 'basic',
  elements: {
    messagelink: `
    <span id="cookieconsent:desc" class="cc-message">{{message}} 
      <a class="cc-link" href="{{tosHref}}" target="_blank">{{tosLink}}</a>
    </span>
    `,
  },
  content: {
    message: 'Nasza strona do poprawnego działania wymaga plików cookie. Więcej: ',

    tosLink: 'Polityka prywatności',
    tosHref: '/privacy',
  }
};

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    appRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSnackBarModule,
    NgcCookieConsentModule.forRoot(cookieConfig),
    TranslateModule.forRoot(),
    DataTablesModule
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    AdminComponent,
    LoginComponent,
    RequestsListComponent,
    RequestCreateComponent,
    RequestDetailComponent,
    MapComponentComponent,
    RequestEditComponent,
    RequestEditStatusComponent,
    RequestEditResponsibilityComponent,
    RegisterComponent,
    RequestDeleteComponent,
    PrivacyComponent,
    RequestsUserListComponent,
    RequestsResponsibilityListComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
