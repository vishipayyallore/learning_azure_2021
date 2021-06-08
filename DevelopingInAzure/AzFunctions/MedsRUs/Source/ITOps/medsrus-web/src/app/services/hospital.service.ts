import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { IAddMedicineOrderDto } from '../interfaces/IAddMedicineOrderDto';
import { IMedicineOrder } from '../interfaces/IMedicineOrder';
import { IMedicineOrderApproval } from '../interfaces/IMedicineOrderApproval';

const baseUrl = environment.hospitalServiceUrl;
const key = environment.information;

const httpOptions = {
	headers: new HttpHeaders({
		'Content-Type': 'application/json',
		'Ocp-Apim-Subscription-Key': key,
		'Ocp-Apim-Trace': 'true',
	}),
};

@Injectable({
	providedIn: 'root'
})
export class HospitalService {

	constructor(private httpClient: HttpClient) { }

	//Add Medicine Order
	AddMedicineOrder(addMedicineOrderDto: IAddMedicineOrderDto): Observable<IAddMedicineOrderDto> {

		console.log(`Adding New Order: ${JSON.stringify(addMedicineOrderDto)}`);

		return this.httpClient
			.post<IAddMedicineOrderDto>(`${baseUrl}/RequestMedicalSupplyOrder`, JSON.stringify(addMedicineOrderDto), httpOptions)
			.pipe(
				retry(1),
				catchError(this.errorHandler)
			)
	}

	GetPendingOrders(): Observable<IMedicineOrder[]> {
		return this.httpClient
			.get<IMedicineOrder[]>(`${baseUrl}/GetMedicalSupplyOrdersForApproval`, httpOptions)
			.pipe(retry(1), catchError(this.errorHandler));
	}

	GetOrderById(id: string): Observable<IMedicineOrder> {
		console.log(`Get Order By request received for ${id}`);
		return this.httpClient
			.get<IMedicineOrder>(`${baseUrl}/GetMedicalSupplyOrderById/${id}`, httpOptions)
			.pipe(retry(1), catchError(this.errorHandler));
	}

	UpdateOrderById(medicineOrderApproval: IMedicineOrderApproval) {
		console.log(
			`Update Order request received for ${JSON.stringify(medicineOrderApproval)}`
		);
		return this.httpClient
			.post<IMedicineOrderApproval>(
				`${baseUrl}/ApproveMedicalSupplyOrder`,
				JSON.stringify(medicineOrderApproval),
				httpOptions
			)
			.pipe(retry(1), catchError(this.errorHandler));
	}

	// Error handling
	errorHandler(error: any) {
		let errorMessage = '';
		if (error.error instanceof ErrorEvent) {
			// Get client-side error
			errorMessage = error.error.message;
		} else {
			// Get server-side error
			errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
		}
		console.log(errorMessage);
		return throwError(errorMessage);
	}

}
