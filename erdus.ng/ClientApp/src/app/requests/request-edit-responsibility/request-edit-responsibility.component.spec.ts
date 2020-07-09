import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestEditResponsibilityComponent } from './request-edit-responsibility.component';

describe('RequestEditStatusComponent', () => {
    let component: RequestEditResponsibilityComponent;
    let fixture: ComponentFixture<RequestEditResponsibilityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
        declarations: [RequestEditResponsibilityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
      fixture = TestBed.createComponent(RequestEditResponsibilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
