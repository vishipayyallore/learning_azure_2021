import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { AddOrderComponent } from './components/hospital/add-order/add-order.component';
import { EditOrderComponent } from './components/hospital/edit-order/edit-order.component';
import { OrdersListComponent } from './components/hospital/orders-list/orders-list.component';
import { StaffComponent } from './components/pharmacy/staff/staff.component';
import { PageNotfoundComponent } from './components/shared/page-notfound/page-notfound.component';
//
const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'add-order', component: AddOrderComponent },
  { path: 'orders-list', component: OrdersListComponent },
  { path: 'edit-order/:orderId', component: EditOrderComponent },
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
