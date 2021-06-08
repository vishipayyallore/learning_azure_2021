import { Guid } from 'guid-typescript';

export interface IPharmacyMedicineOrderApproval {

    id: Guid;

    patientName: string,

    medicationName: string,

    lotNumber: string;

    pharmacyOrderStatus: string;

    pharmacyAdditionalComments: string;
}

