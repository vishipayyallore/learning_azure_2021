import { Component, OnInit } from '@angular/core';

import { IPharmacyMedicineOrder } from 'src/app/interfaces/IPharmacyMedicineOrder';
import { PharmacyService } from 'src/app/services/pharmacy.service';

@Component({
  selector: 'app-pharmacyorders',
  templateUrl: './pharmacyorders.component.html',
  styleUrls: ['./pharmacyorders.component.css']
})
export class PharmacyordersComponent implements OnInit {

	// @ts-ignore
	medicineOrderList: IPharmacyMedicineOrder[];

	constructor(private pharmacyService: PharmacyService) {
	}

  ngOnInit(): void {
		this.GetAllOrdersPharmacyForApproval();
	}

	GetAllOrdersPharmacyForApproval() {
		this.pharmacyService.GetAllOrdersPharmacyForApproval()
			.subscribe((data: IPharmacyMedicineOrder[]) => {
				this.medicineOrderList = data;
				console.log(this.medicineOrderList);
			},
				(error) => {
					console.log(`Error: ${error}`);
					this.medicineOrderList = [];
				});
  }

}
