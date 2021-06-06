import { Component, NgZone, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { HospitalService } from 'src/app/services/hospital.service';
import { IAddMedicineOrderDto } from 'src/app/interfaces/IAddMedicineOrderDto';
import { IMedicineOrder } from '../../../interfaces/IMedicineOrder';
import { IMedicineOrderApproval } from '../../../interfaces/IMedicineOrderApproval';

@Component({
	selector: 'app-add-order',
	templateUrl: './add-order.component.html',
	styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {

	// @ts-ignore
	addMedicineOrder: IAddMedicineOrderDto;

	// @ts-ignore
	addMedicineOrderForm: FormGroup;

	constructor(private hospitalService: HospitalService, private route: ActivatedRoute, private formBuilder: FormBuilder
		, private ngZone: NgZone, private router: Router) {

		this.addMedicineOrderForm = this.formBuilder.group({
			medicationName: 'Asprin',
			medicationDosage: '89 mg',
			medicationFrequency: 2,
			urgencyRanking: 1,
			additionalComments: 'Please approve'
		});
	}

	ngOnInit(): void {
	}

	onAddMedicineOrder(bookData: IAddMedicineOrderDto): void {

		this.hospitalService.AddMedicineOrder(bookData)
			.subscribe(res => {
				console.log('Order Added!');
				this.ngZone.run(() => this.router.navigateByUrl('/orders-list'));
			});

	}

}
