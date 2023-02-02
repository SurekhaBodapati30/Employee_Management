using Employee.CURD.Model;
using Employee.CURD.Model.ServiceModel;
using Employee.CURD.WebApi.DTOs;

namespace Employee.CURD.WebApi.Extensions
{
    public static class EmployeeExtension
    {
        public static EmployeeDto AsDto(this Model.EmployeeModel employee)
        {
            return new EmployeeDto(employee.Id, employee.FirstName, employee.LastName, employee.Email, employee.Mobile, employee.Salary, employee.Role);
        }
        public static EmployeepagingDto AsPagingEmployeeDto(this PagingEmployee item)
        {
            var contactList = item.Employees.Select(c => AsDto(c));
            return new EmployeepagingDto(item.TotalCount, item.PageIndex, item.PageSize, contactList);
        }
        public static EmployeeModel AsModel(this EmployeeDto employee)
        {
            return new Model.EmployeeModel() { 
                Id= employee.Id,
                FirstName= employee.FirstName,
                LastName= employee.LastName,
                Email= employee.Email,
                Mobile= employee.Mobile,
                Salary= employee.Salary,
                Role= employee.Role

            };
        }

    }
}
