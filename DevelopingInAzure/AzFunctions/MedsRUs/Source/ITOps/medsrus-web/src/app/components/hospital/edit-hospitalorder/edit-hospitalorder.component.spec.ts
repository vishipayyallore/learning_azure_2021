import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditHospitalOrderComponent } from './edit-hospitalorder.component';

describe('EditOrderComponent', () => {
  let component: EditHospitalOrderComponent;
  let fixture: ComponentFixture<EditHospitalOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditHospitalOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditHospitalOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
