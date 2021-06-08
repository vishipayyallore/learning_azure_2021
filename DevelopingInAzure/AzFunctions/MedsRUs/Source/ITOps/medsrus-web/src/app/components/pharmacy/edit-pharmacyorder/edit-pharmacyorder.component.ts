import { Component, NgZone, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IPharmacyMedicineOrder } from 'src/app/interfaces/IPharmacyMedicineOrder';
import { IPharmacyMedicineOrderApproval } from 'src/app/interfaces/IPharmacyMedicineOrderApproval';

import { PharmacyService } from 'src/app/services/pharmacy.service';

@Component({
	selector: 'app-edit-pharmacyorder',
	templateUrl: './edit-pharmacyorder.component.html',
	styleUrls: ['./edit-pharmacyorder.component.css']
})
export class EditPharmacyorderComponent implements OnInit {

	// @ts-ignore
	medicineOrder: IPharmacyMedicineOrder;

	// @ts-ignore
	medicineOrderApproval: IPharmacyMedicineOrderApproval;

	// @ts-ignore
	medicineOrderForm: FormGroup;

	constructor(private pharmacyService: PharmacyService, private route: ActivatedRoute, private formBuilder: FormBuilder
		, private ngZone: NgZone, private router: Router) {
		this.medicineOrderForm = this.formBuilder.group({
			id: '',
			patientName: '',
			medicationName: '',
			lotNumber: 'A102',
			pharmacyOrderStatus: '',
			pharmacyAdditionalComments: 'Sending Order'
		});
	}

	ngOnInit(): void {
		this.route.paramMap.subscribe(params => {
			console.log(`${params.get('patientName')} ${params.get('orderId')}`)
			// @ts-ignore
			this.pharmacyService.GetOrderById(params.get('patientName'), params.get('orderId'))
				.subscribe((medicineOrder: IPharmacyMedicineOrder) => {
					this.medicineOrder = medicineOrder;
					console.log(`${this.medicineOrder.medicationName}`);
				});
		});
	}

	onApproveRejectOrder(orderStatus: string): void {

		this.medicineOrderApproval = this.medicineOrderForm.value;
		this.medicineOrderApproval.pharmacyOrderStatus = orderStatus;

		console.log(this.medicineOrderApproval);

		this.pharmacyService.UpdateOrderById(this.medicineOrderApproval).subscribe(res => {

			console.log('Order Modified!')
			this.ngZone.run(() => this.router.navigateByUrl('/pharmacyorders'))
		});

	}

}
