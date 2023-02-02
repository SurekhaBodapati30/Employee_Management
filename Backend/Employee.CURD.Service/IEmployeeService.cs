using Employee.CURD.Model;
using Employee.CURD.Model.ServiceModel;

namespace Employee.CURD.Service
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeModel> GetAllEmployee();
        Guid CreateEmployee(EmployeeModel employee);
        EmployeeModel FindEmployee(Guid id);
        bool DeleteEmployee(Guid id);
        bool UpdateEmployee(Guid id, EmployeeModel employee);

        IEnumerable<EmployeeModel> Search(string name);

        Task<PagingEmployee> Getpagination(int pageNumber, int pageSize);

    }
}