import { UpdateEmployeeComponent } from './update-employee/update-employee.component';
import { AboutusComponent } from './aboutus/aboutus.component';

import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { HomeComponent } from './home/home.component';
import { ContactListComponent } from './contact-list/contact-list.component';
const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'employee-list', component: EmployeeListComponent },
  {path: 'aboutus', component: AboutusComponent},
  { path: 'add-employee', component: ContactListComponent },
  { path: 'update', component: UpdateEmployeeComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
