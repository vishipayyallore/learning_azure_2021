import { Guid } from 'guid-typescript';

export interface IMedicineOrder {

    id: Guid;

    patientName: string;

    patientDOB: Date;

    patientRoom: number;

    employeeInitiatingOrder: string;

    medicationName: string;

    medicationDosage: string;

    urgencyRanking: number;
}
