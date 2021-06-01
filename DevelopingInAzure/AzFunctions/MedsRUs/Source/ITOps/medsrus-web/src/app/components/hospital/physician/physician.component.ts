import { Component, OnInit } from '@angular/core';

import { HospitalService } from 'src/app/services/hospital.service';
import { IMedicineOrder } from '../../../interfaces/imedicine-order';

@Component({
  selector: 'app-physician',
  templateUrl: './physician.component.html',
  styleUrls: ['./physician.component.css']
})
export class PhysicianComponent implements OnInit {

  medicineOrderList: IMedicineOrder[] = [];

  constructor(private hospitalService: HospitalService) {
  }

  ngOnInit(): void {
    this.loadPendingOrders();
  }

  loadPendingOrders() {
    this.hospitalService.GetPendingOrders()
      .subscribe((data: IMedicineOrder[]) => {
        this.medicineOrderList = data;
        console.log(this.medicineOrderList);
      });
  }

}
