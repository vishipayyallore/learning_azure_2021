import { Component, NgZone, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { HospitalService } from 'src/app/services/hospital.service';
import { IAddMedicineOrderDto } from 'src/app/interfaces/IAddMedicineOrderDto';

@Component({
	selector: 'app-add-hospitalorder',
	templateUrl: './add-hospitalorder.component.html',
	styleUrls: ['./add-hospitalorder.component.css']
})
export class AddHospitalOrderComponent implements OnInit {

	// @ts-ignore
	addMedicineOrder: IAddMedicineOrderDto;

	// @ts-ignore
	addMedicineOrderForm: FormGroup;

	constructor(private hospitalService: HospitalService, private formBuilder: FormBuilder,
		private ngZone: NgZone, private router: Router) {

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
				this.ngZone.run(() => this.router.navigateByUrl('/hospitalorders'));
			});

	}

}
