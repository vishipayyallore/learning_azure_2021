import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddHospitalOrderComponent } from './add-hospitalorder.component';

describe('AddOrderComponent', () => {
  let component: AddHospitalOrderComponent;
  let fixture: ComponentFixture<AddHospitalOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddHospitalOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddHospitalOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
