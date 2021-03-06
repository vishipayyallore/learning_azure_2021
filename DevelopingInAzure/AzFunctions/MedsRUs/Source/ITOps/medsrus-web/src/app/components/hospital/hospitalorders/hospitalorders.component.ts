import { Component, OnInit } from '@angular/core';

import { HospitalService } from 'src/app/services/hospital.service';
import { IMedicineOrder } from '../../../interfaces/IMedicineOrder';

@Component({
    selector: 'app-hospitalorders',
    templateUrl: './hospitalorders.component.html',
    styleUrls: ['./hospitalorders.component.css']
})
export class HospitalOrdersComponent implements OnInit {

    // @ts-ignore
    medicineOrderList: IMedicineOrder[];

    imageWidth = 50;
    imageMargin = 1;

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
            },
                (error) => {
                    console.log(`Error: ${error}`);
                    this.medicineOrderList = [];
                });
    }

    getRandomIntInclusive(min: number, max: number) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1) + min); //The maximum is inclusive and the minimum is inclusive
    }

}
