import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../employee.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.scss'],
})
export class UpdateEmployeeComponent implements OnInit {
  employeeRequest = new Employee();
  employeeFormGroup!: FormGroup;
  empId: string = '';
  constructor(
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder,
    private routes: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.routes.queryParams.subscribe((s: any) => {
      this.empId = s.id;
      this.getDetail(this.empId);
    });

    this.employeeFormGroup = this.formBuilder.group({
      id: [, Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      mobile: ['', Validators.required],
      salary: [0, Validators.required],
      role: ['', Validators.required],
    });
  }
  initializeForm() {
    this.employeeFormGroup.controls['id'].setValue(this.empId);
    this.employeeFormGroup.controls['firstName'].setValue(
      this.employeeRequest.firstName
    );
    this.employeeFormGroup.controls['lastName'].setValue(
      this.employeeRequest.lastName
    );
    this.employeeFormGroup.controls['email'].setValue(
      this.employeeRequest.email
    );
    this.employeeFormGroup.controls['mobile'].setValue(
      this.employeeRequest.mobile
    );
    this.employeeFormGroup.controls['salary'].setValue(
      this.employeeRequest.salary
    );
    this.employeeFormGroup.controls['role'].setValue(this.employeeRequest.role);
  }

  getDetail(id: string) {
    this.employeeService.findEmployee(id).subscribe((res: any) => {
      this.employeeRequest = res;
      this.initializeForm();
    });
  }
  onSubmit() {}
  onUpdate() {
    console.log('clicked');

    this.employeeService
      .updateEmployee(this.employeeFormGroup.value)
      .subscribe((res) => {
        console.log(res);
      });
  }
}
