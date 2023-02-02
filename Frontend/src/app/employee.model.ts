export class Employee {
  id: string = '';
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  mobile: string = '';
  salary: number = 0;
  role: string = '';
  
}
export class PagingEmployee {
  employees = [];
  totalCount = 0;
  pageIndex = 0;
  pageSize = 0;
}
