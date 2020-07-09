import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { AdminComponent } from './admin';
import { LoginComponent } from './login';
import { AuthGuard } from './_helpers';
import { Role } from './_models';
import { RequestsListComponent } from './requests/requests-list/requests-list.component';
import { RequestCreateComponent } from './requests/request-create/request-create.component';
import { RequestDetailComponent } from './requests/request-detail/request-detail.component';
import { RequestEditComponent } from './requests/request-edit/request-edit.component';
import { RequestEditStatusComponent } from './requests/request-edit-status/request-edit-status.component';
import { RequestEditResponsibilityComponent } from './requests/request-edit-responsibility/request-edit-responsibility.component';
import { RegisterComponent } from './register/register.component';
import { RequestDeleteComponent } from './requests/request-delete/request-delete.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { RequestsUserListComponent } from './requests/requests-user-list/requests-user-list.component';
import { RequestsResponsibilityListComponent } from './requests/requests-responsibility-list/requests-responsibility-list.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard],
    //data: { roles: [Role.Admin] }
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'privacy',
    component: PrivacyComponent
  },
  {
    path: 'requests',
    component: RequestsListComponent
  },
  {
    path: 'user/requests',
    canActivate: [AuthGuard],
    component: RequestsUserListComponent
  },
  {
    path: 'responsibility/requests',
    canActivate: [AuthGuard],
    component: RequestsResponsibilityListComponent
  },
  {
    path: 'requests/create',
    component: RequestCreateComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'requests/:id',
    component: RequestDetailComponent
  },
  {
    path: 'requests/edit/:id',
    canActivate: [AuthGuard],
    component: RequestEditComponent
  },
  {
    path: 'requests/delete/:id',
    canActivate: [AuthGuard],
    component: RequestDeleteComponent
  },
  {
    path: 'requests/status/edit/:id',
    canActivate: [AuthGuard],
    component: RequestEditStatusComponent
  },
  {
    path: 'requests/responsibility/edit/:id',
    canActivate: [AuthGuard],
    component: RequestEditResponsibilityComponent
  },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes, { useHash: true });
