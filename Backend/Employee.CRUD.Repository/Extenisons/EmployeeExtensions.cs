using Employee.CURD.Model;

namespace Employee.CRUD.Repository.Extenisons
{
    public static class EmployeeExtensions
    {
        public static Employee AsEntity(this EmployeeModel employee)
        {
            return new Employee() {
                Id= employee.Id,
                Email= employee.Email,
                FirstName= employee.FirstName,
                LastName= employee.LastName,
                Mobile= employee.Mobile,
                Salary= employee.Salary,
                Role= employee.Role,
            };
        }

        public static EmployeeModel AsModel(this Employee employee)
        {
            return new EmployeeModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName, 
                Email = employee.Email,
                Mobile = employee.Mobile,
                Salary = employee.Salary,
                Role = employee.Role
            };
        }
    }
}
