using Employee.CURD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.CRUD.Repository;
using Microsoft.EntityFrameworkCore;
using Employee.CRUD.Repository.Extenisons;
using Employee.CURD.Model.ServiceModel;

namespace Employee.CRUD.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeApiDbContext _dbcontext;
        public EmployeeRepository(EmployeeApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _dbcontext.Employees.Select(x => x.AsModel());
        }
        public Guid CreateEmployee(EmployeeModel employee)
        {
            employee.Id = Guid.NewGuid();
            _dbcontext.Employees.AddAsync(employee.AsEntity());
            _dbcontext.SaveChangesAsync();
            return employee.Id;
        }

        public EmployeeModel FindEmployee(Guid id)
        {
            var employee = _dbcontext.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return null;
            }
            return employee.AsModel();
        }

        public bool DeleteEmployee(Guid id)
        {
            var employee = _dbcontext.Employees.FirstOrDefault(o => o.Id == id);
            if (employee == null)
            {
                return false;
            }
            _dbcontext.Employees.Remove(employee);
            _dbcontext.SaveChanges();

            return true;
        }

        public bool UpdateEmployee(Guid id, EmployeeModel employee)
        {
            var employeeData = _dbcontext.Employees.Where(o => o.Id == id).FirstOrDefault();
            if (employee == null)
                return false;

            employeeData.FirstName = employee.FirstName;
            employeeData.LastName = employee.LastName;
            employeeData.Email = employee.Email;
            employeeData.Mobile = employee.Mobile;
            employeeData.Salary = employee.Salary;
            employeeData.Role = employee.Role;
            _dbcontext.Employees.Update(employeeData);
            _dbcontext.SaveChanges();
            return true;

        }

        public IEnumerable<EmployeeModel> Seaching(string searchKey)
        {
            var collection = _dbcontext.Employees as IQueryable<Employee>;
            searchKey = searchKey.Trim();
            collection = collection.Where(e => e.FirstName.ToLower().Contains(searchKey.ToLower()));
            return collection.OrderBy(c => c.FirstName).Select(x => x.AsModel());
        }

        public async Task<PagingEmployee> Getpagination(int pageNumber, int pageSize)
        {

            var records = _dbcontext.Employees;
            
            var result = await records.OrderBy(e => e.FirstName).Skip(pageSize * (pageNumber - 1)).Take(pageSize).Select(x => x.AsModel()).ToListAsync();

            var totalCount = records.Count();
           
            var pagingEmployee = new PagingEmployee()
            {
               TotalCount = totalCount,
               Employees = result,
               PageSize = pageSize,
               PageIndex = pageNumber,

            };
            return pagingEmployee;
                           

        }
         
    }
}

