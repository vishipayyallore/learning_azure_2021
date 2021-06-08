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
import { HospitalOrdersComponent } from './components/hospital/hospitalorders/hospitalorders.component';
import { AddHospitalOrderComponent } from './components/hospital/add-hospitalorder/add-hospitalorder.component';
import { EditHospitalOrderComponent } from './components/hospital/edit-hospitalorder/edit-hospitalorder.component';
import { PharmacyordersComponent } from './components/pharmacy/pharmacyorders/pharmacyorders.component';
import { EditPharmacyorderComponent } from './components/pharmacy/edit-pharmacyorder/edit-pharmacyorder.component';

@NgModule({
	declarations: [
		AppComponent,
		TopNavbarComponent,
		FooterComponent,
		PageNotfoundComponent,
		DashboardComponent,
		HospitalOrdersComponent,
		AddHospitalOrderComponent,
		EditHospitalOrderComponent,
		PharmacyordersComponent,
		EditPharmacyorderComponent
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
