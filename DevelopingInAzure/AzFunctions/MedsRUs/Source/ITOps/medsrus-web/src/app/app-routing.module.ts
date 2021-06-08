import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { AddHospitalOrderComponent } from './components/hospital/add-hospitalorder/add-hospitalorder.component';
import { EditHospitalOrderComponent } from './components/hospital/edit-hospitalorder/edit-hospitalorder.component';
import { HospitalOrdersComponent } from './components/hospital/hospitalorders/hospitalorders.component';
import { EditPharmacyorderComponent } from './components/pharmacy/edit-pharmacyorder/edit-pharmacyorder.component';
import { PharmacyordersComponent } from './components/pharmacy/pharmacyorders/pharmacyorders.component';
import { PageNotfoundComponent } from './components/shared/page-notfound/page-notfound.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'add-hospitalorder', component: AddHospitalOrderComponent },
  { path: 'hospitalorders', component: HospitalOrdersComponent },
  { path: 'edit-hospitalorder/:orderId', component: EditHospitalOrderComponent },
  { path: 'pharmacyorders', component: PharmacyordersComponent },
  { path: 'edit-pharmacyorder/:orderId/:patientName', component: EditPharmacyorderComponent },
  { path: 'pagenotfound', component: PageNotfoundComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'pagenotfound', pathMatch: 'full' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
