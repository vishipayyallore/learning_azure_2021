import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HospitalOrdersComponent } from './hospitalorders.component';

describe('OrdersListComponent', () => {
  let component: HospitalOrdersComponent;
  let fixture: ComponentFixture<HospitalOrdersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HospitalOrdersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HospitalOrdersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
