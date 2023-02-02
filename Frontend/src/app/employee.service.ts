import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee, PagingEmployee } from './employee.model';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  pageSize = 10;
  constructor(private http: HttpClient) {}
  getEmployee(): Observable<Array<Employee>> {
    return this.http.get<Array<Employee>>(
      'https://localhost:7076/api/Employee'
    );
  }
  postEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(
      'https://localhost:7076/api/Employee',
      employee
    );
  }
  updateEmployee(employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(
      `https://localhost:7076/api/Employee?id=${employee.id}`,
      employee
    );
  }
  deleteEmployee(id: string): Observable<any> {
    return this.http.delete<any>(
      `https://localhost:7076/api/Employee?id=${id}`
    );
  }
  findEmployee(id: string): Observable<Array<Employee>> {
    return this.http.get<Array<Employee>>(
      `https://localhost:7076/api/Employee/${id}`
    );
  }
  pagedEmployee(page: any, pageSize: any) {
    return this.http.get<PagingEmployee>(
      `https://localhost:7076/api/Employee/PagedEmployee?pageNumber=${page}&pageSize=${pageSize}`
    );
  }
  Searching(firstName: string) {
    return this.http.get<Array<Employee>>(
      'https://localhost:7076/searching?searchKey=' + firstName
    );
  }
}
