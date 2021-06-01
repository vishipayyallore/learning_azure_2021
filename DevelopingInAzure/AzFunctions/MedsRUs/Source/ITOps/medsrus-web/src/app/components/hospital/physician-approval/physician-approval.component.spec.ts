import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhysicianApprovalComponent } from './physician-approval.component';

describe('PhysicianApprovalComponent', () => {
  let component: PhysicianApprovalComponent;
  let fixture: ComponentFixture<PhysicianApprovalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PhysicianApprovalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PhysicianApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
