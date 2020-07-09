import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestsResponsibilityListComponent } from './requests-responsibility-list.component';

describe('RequestsResponsibilityListComponent', () => {
  let component: RequestsResponsibilityListComponent;
  let fixture: ComponentFixture<RequestsResponsibilityListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [RequestsResponsibilityListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestsResponsibilityListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
