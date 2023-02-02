using Employee.CRUD.Repository;
using Employee.CURD.Model;
using Employee.CURD.Model.ServiceModel;

namespace Employee.CURD.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRep)
        {
            this._employeeRepository = employeeRep;

        }
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _employeeRepository.GetAllEmployee();

        }
        public Guid CreateEmployee(EmployeeModel employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        public EmployeeModel FindEmployee(Guid id)
        {
            return _employeeRepository.FindEmployee(id);
        }

        public bool DeleteEmployee(Guid id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public bool UpdateEmployee(Guid id, Model.EmployeeModel employee)
        {
            return _employeeRepository.UpdateEmployee(id, employee);
        }

        public IEnumerable<EmployeeModel> Search(string name)
        {
            return _employeeRepository.Seaching(name);
        }

        public async Task<PagingEmployee> Getpagination(int pageNumber, int pageSize)
        {
            return await _employeeRepository.Getpagination(pageNumber, pageSize);
        }
    }
}

