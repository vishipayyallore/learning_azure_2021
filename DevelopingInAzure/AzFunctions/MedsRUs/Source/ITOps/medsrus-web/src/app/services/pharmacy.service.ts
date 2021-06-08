import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { IPharmacyMedicineOrder } from '../interfaces/IPharmacyMedicineOrder';
import { IPharmacyMedicineOrderApproval } from '../interfaces/IPharmacyMedicineOrderApproval';

const baseUrl = environment.pharmacyServiceUrl;
const httpOptions = {
	headers: new HttpHeaders({
		'Content-Type': 'application/json',
	}),
};

@Injectable({
	providedIn: 'root'
})
export class PharmacyService {

	constructor(private httpClient: HttpClient) { }

	GetAllOrdersPharmacyForApproval(): Observable<IPharmacyMedicineOrder[]> {
		return this.httpClient
			.get<IPharmacyMedicineOrder[]>(`${baseUrl}/GetAllOrdersForApproval`)
			.pipe(retry(1), catchError(this.errorHandler));
	}

	GetOrderById(patientName: string, orderId: string): Observable<IPharmacyMedicineOrder> {
		console.log(`Get Order By request received for ${orderId}`);
		return this.httpClient
			.get<IPharmacyMedicineOrder>(`${baseUrl}/GetSingleOrderForApproval/${patientName}/${orderId}`)
			.pipe(retry(1), catchError(this.errorHandler));
	}

	UpdateOrderById(medicineOrderApproval: IPharmacyMedicineOrderApproval) {
		console.log(
			`Update Order request received for ${JSON.stringify(medicineOrderApproval)}`
		);
		return this.httpClient
			.post<IPharmacyMedicineOrderApproval>(
				`${baseUrl}/UpdatePharmacyOrder/${medicineOrderApproval.patientName}/${medicineOrderApproval.id}`,
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
