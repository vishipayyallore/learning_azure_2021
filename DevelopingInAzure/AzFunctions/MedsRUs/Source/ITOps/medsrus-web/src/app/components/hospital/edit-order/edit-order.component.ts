import { Component, NgZone, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { HospitalService } from 'src/app/services/hospital.service';
import { IMedicineOrder } from '../../../interfaces/IMedicineOrder';
import { IMedicineOrderApproval } from '../../../interfaces/IMedicineOrderApproval';

@Component({
	selector: 'app-edit-order',
	templateUrl: './edit-order.component.html',
	styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent implements OnInit {

	// @ts-ignore
	medicineOrder: IMedicineOrder;

	// @ts-ignore
	medicineOrderApproval: IMedicineOrderApproval;

	// @ts-ignore
	medicineOrderForm: FormGroup;

	constructor(private hospitalService: HospitalService, private route: ActivatedRoute, private formBuilder: FormBuilder
		, private ngZone: NgZone, private router: Router) {

		this.medicineOrderForm = this.formBuilder.group({
			id: '',
			patientName: '',
			medicationName: '',
			orderStatus: '',
			additionalComments: ''
		});
	}

	ngOnInit(): void {
		this.route.paramMap.subscribe(params => {

			// @ts-ignore
			this.hospitalService.GetOrderById(params.get('orderId'))
				.subscribe((medicineOrder: IMedicineOrder) => {

					this.medicineOrder = medicineOrder;
					console.log(`${this.medicineOrder.medicationName}`);
				});
		});
	}

	onApproveRejectOrder(orderStatus: string): void {

		this.medicineOrderApproval = this.medicineOrderForm.value;
		this.medicineOrderApproval.orderStatus = orderStatus;
		console.log(this.medicineOrderApproval);

		this.hospitalService.UpdateOrderById(this.medicineOrderApproval).subscribe(res => {

			console.log('Order Modified!')
			this.ngZone.run(() => this.router.navigateByUrl('/orders-list'))
		});

	}
}
