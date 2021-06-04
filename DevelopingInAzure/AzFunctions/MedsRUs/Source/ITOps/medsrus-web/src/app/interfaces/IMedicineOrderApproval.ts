import { Guid } from 'guid-typescript';

export interface IMedicineOrderApproval {

    id: Guid;

    patientName: string;

    medicationName: string;
    
    orderStatus: string;

    additionalComments: string;
}