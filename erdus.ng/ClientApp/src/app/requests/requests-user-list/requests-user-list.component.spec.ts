import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestsUserListComponent } from './requests-user-list.component';

describe('RequestsUserListComponent', () => {
  let component: RequestsUserListComponent;
  let fixture: ComponentFixture<RequestsUserListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestsUserListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestsUserListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
