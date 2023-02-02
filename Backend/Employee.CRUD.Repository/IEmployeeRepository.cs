using Employee.CURD.Model;
using Employee.CURD.Model.ServiceModel;

namespace Employee.CRUD.Repository

{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAllEmployee();
        Guid CreateEmployee(EmployeeModel employee);
        EmployeeModel FindEmployee(Guid id);
        bool DeleteEmployee(Guid id);
        bool UpdateEmployee(Guid id, EmployeeModel employee);
        IEnumerable<EmployeeModel> Seaching(string searchKey);
        Task<PagingEmployee> Getpagination(int pageNumber, int pageSize);

    }
}


