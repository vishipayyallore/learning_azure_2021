import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopNavbarComponent } from './components/shared/top-navbar/top-navbar.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { PageNotfoundComponent } from './components/shared/page-notfound/page-notfound.component';
import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { StaffComponent } from './components/pharmacy/staff/staff.component';
import { OrdersListComponent } from './components/hospital/orders-list/orders-list.component';
import { AddOrderComponent } from './components/hospital/add-order/add-order.component';
import { EditOrderComponent } from './components/hospital/edit-order/edit-order.component';

@NgModule({
	declarations: [
		AppComponent,
		TopNavbarComponent,
		FooterComponent,
		PageNotfoundComponent,
		DashboardComponent,
		StaffComponent,
		OrdersListComponent,
		AddOrderComponent,
		EditOrderComponent
	],
	imports: [
		BrowserModule,
		HttpClientModule,
		ReactiveFormsModule,
		AppRoutingModule
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule { }
