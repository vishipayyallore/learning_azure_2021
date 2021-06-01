import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { NurseComponent } from './components/hospital/nurse/nurse.component';
import { PhysicianApprovalComponent } from './components/hospital/physician-approval/physician-approval.component';
import { PhysicianComponent } from './components/hospital/physician/physician.component';
import { StaffComponent } from './components/pharmacy/staff/staff.component';
import { PageNotfoundComponent } from './components/shared/page-notfound/page-notfound.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'nurse', component: NurseComponent },
  { path: 'physician', component: PhysicianComponent },
  { path: 'physician-approval/:orderId', component: PhysicianApprovalComponent },
  { path: 'pharmacy-staff', component: StaffComponent },
  { path: 'pagenotfound', component: PageNotfoundComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'pagenotfound', pathMatch: 'full' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
