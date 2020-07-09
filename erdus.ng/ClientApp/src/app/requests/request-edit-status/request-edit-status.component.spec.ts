import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestEditStatusComponent } from './request-edit-status.component';

describe('RequestEditStatusComponent', () => {
  let component: RequestEditStatusComponent;
  let fixture: ComponentFixture<RequestEditStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestEditStatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestEditStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
