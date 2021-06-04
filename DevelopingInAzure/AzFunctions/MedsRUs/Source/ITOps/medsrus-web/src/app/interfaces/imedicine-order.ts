import { Guid } from 'guid-typescript';

export interface IMedicineOrder {

    id: Guid;

    patientName: string;

    patientDOB: Date;

    patientRoom: number;

    employeeInitiatingOrder: string;

    isPhysicianAssistant: boolean;

    isNurse: boolean;

    medicationName: string;
    
    medicationDosage: string;
    
    medicationFrequency: number;
    
    urgencyRanking: number;

    orderStatus: string;

    pictureUrl: string;

    additionalComments: string;
}

