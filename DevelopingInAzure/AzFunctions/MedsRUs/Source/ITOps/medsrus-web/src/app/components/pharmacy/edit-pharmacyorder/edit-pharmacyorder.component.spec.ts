import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPharmacyorderComponent } from './edit-pharmacyorder.component';

describe('EditPharmacyorderComponent', () => {
  let component: EditPharmacyorderComponent;
  let fixture: ComponentFixture<EditPharmacyorderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPharmacyorderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPharmacyorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
