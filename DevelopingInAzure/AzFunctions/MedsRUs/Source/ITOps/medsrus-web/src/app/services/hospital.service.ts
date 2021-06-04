import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

import { IMedicineOrder } from '../interfaces/imedicine-order';
import { IMedicineOrderApproval } from '../interfaces/IMedicineOrderApproval';

const baseUrl = 'http://localhost:7071/api';
const apiName = 'GetMedicalSupplyOrdersForApproval';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root'
})
export class HospitalService {

  constructor(private httpClient: HttpClient) { }

  GetPendingOrders(): Observable<IMedicineOrder[]> {
    return this.httpClient
      .get<IMedicineOrder[]>(`${baseUrl}/${apiName}`)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  GetOrderById(id: string): Observable<IMedicineOrder> {
    console.log(`Get Order By request received for ${id}`);
    return this.httpClient
      .get<IMedicineOrder>(`${baseUrl}/GetMedicalSupplyOrderById/${id}`)
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
