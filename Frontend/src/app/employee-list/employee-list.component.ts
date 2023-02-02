import { Employee } from './../employee.model';
import { EmployeeService } from './../employee.service';
import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Page } from 'ngx-pagination/public-api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent {
  employees: any;
  employee = '';
  id = '';
  total = 0;
  pageSize = 5;
  searchText = '';
  employeeRequest = new Employee();
  employeelist: Array<Employee> = [];
  dataSource: any;
  FirstName = '';
  totalItems: any;
  page: number = 1;
  constructor(
    private service: EmployeeService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.getbyPage(this.page, this.pageSize);
  }
  onPageChange(event: any) {
    console.log('this is a page event: ');
    console.log(event);
    this.page += 1;
    this.getbyPage(event, this.pageSize);
  }
  getAllEmployee() {
    this.service.getEmployee().subscribe((res) => {
      this.employeelist = res;
      console.log('EmployeeListComponent :', this.employeelist);
    });
  }
  onDelete(data: string) {
    this.service
      .deleteEmployee(data)
      .subscribe((isDeleted) => console.log('Status of del req', isDeleted));
    this.getAllEmployee();
  }
  onSearch(FirstName: string) {
    console.log(FirstName);
    this.service.Searching(FirstName).subscribe((res) => {
      this.employeelist = res;
    });
  }
  getbyPage(page: any, pageSize: any) {
    this.service.pagedEmployee(page, pageSize).subscribe((res) => {
      this.employeelist = res.employees;
      this.pageSize = res.pageSize;
      this.page = res.pageIndex;
      this.total = res.totalCount;
      console.log('EmployeeListComponent :', this.employeelist);
    });
  }

  updateEmployee(id: string) {
    this.router.navigate(['update'], { queryParams: { id: id } });
  }
}
