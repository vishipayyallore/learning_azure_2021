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
import { NurseComponent } from './components/hospital/nurse/nurse.component';
import { PhysicianComponent } from './components/hospital/physician/physician.component';
import { StaffComponent } from './components/pharmacy/staff/staff.component';
import { PhysicianApprovalComponent } from './components/hospital/physician-approval/physician-approval.component';

@NgModule({
  declarations: [
    AppComponent,
    TopNavbarComponent,
    FooterComponent,
    PageNotfoundComponent,
    DashboardComponent,
    NurseComponent,
    PhysicianComponent,
    StaffComponent,
    PhysicianApprovalComponent
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
