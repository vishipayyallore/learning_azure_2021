import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PharmacyordersComponent } from './pharmacyorders.component';

describe('PharmacyordersComponent', () => {
  let component: PharmacyordersComponent;
  let fixture: ComponentFixture<PharmacyordersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PharmacyordersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PharmacyordersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
