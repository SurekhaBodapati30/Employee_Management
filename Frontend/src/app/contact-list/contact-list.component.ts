import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Employee } from '../employee.model';
import { EmployeeService } from '../employee.service';
@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss'],
})
export class ContactListComponent {
  employeeRequest = new Employee();
  employeeFormGroup: FormGroup;
  constructor(
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder
  ) {
    this.employeeFormGroup = formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      mobile: ['', Validators.required],
      salary: [0, Validators.required],
      role: ['', Validators.required],
    });
  }

  onSubmit() {
    console.log(this.employeeFormGroup.value);
    this.employeeRequest.id = '3fa85f64-5717-4562-b3fc-2c963f66afa6';
    this.employeeRequest.firstName = this.employeeFormGroup.value['firstName'];
    this.employeeRequest.lastName = this.employeeFormGroup.value['lastName'];
    this.employeeRequest.email = this.employeeFormGroup.value['email'];
    this.employeeRequest.mobile = this.employeeFormGroup.value['mobile'];
    this.employeeRequest.salary = this.employeeFormGroup.value['salary'];
    this.employeeRequest.role = this.employeeFormGroup.value['role'];

    console.log(this.employeeRequest);
    this.employeeService
      .postEmployee(this.employeeRequest)
      .subscribe((data) => {
        console.log('added sucessfuly:', data);
        this.employeeFormGroup.reset();
      });
  }
}
