import { Guid } from 'guid-typescript';

export interface IPharmacyMedicineOrder {

    id: Guid;

    patientName: string;

    patientDOB: Date;

    attendingPhysicianName: string;

    medicationName: string;

    medicationDosage: string;

    medicationFrequency: number;

    urgencyRanking: number;

    lotNumber: string;

    pharmacyOrderStatus: string;

    pharmacyTimeofApproval: Date;

    pharmacyAdditionalComments: string;
}

