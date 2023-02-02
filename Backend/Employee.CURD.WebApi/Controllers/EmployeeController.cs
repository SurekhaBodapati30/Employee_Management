using Employee.CRUD.Repository;
using Employee.CURD.Model;
using Employee.CURD.Model.ServiceModel;
using Employee.CURD.Service;
using Employee.CURD.WebApi.DTOs;
using Employee.CURD.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Employee.CURD.WebApi.Controllers
{

    [ApiController]
    [Route("api/Employee/")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployee()
        {
            return Ok(employeeService.GetAllEmployee().Select(x=>x.AsDto()));
        }

        [HttpPost]
        public ActionResult<Guid> CreateEmployee(EmployeeDto employee)
        {
            return Ok(employeeService.CreateEmployee(employee.AsModel()));
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<EmployeeDto> FindEmployee(Guid id)
        {
            var result = employeeService.FindEmployee(id);
            if(result== null)
            {
                return NotFound();
            }
            return Ok(result.AsDto());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            
            var result = employeeService.FindEmployee(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(employeeService.DeleteEmployee(id));
        }

        [HttpPut]
        public ActionResult<bool> UpdateEmployee(Guid id, EmployeeModel employee)
        {
            var result = employeeService.FindEmployee(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(employeeService.UpdateEmployee(id, employee));
        }

        [HttpGet("/searching")]
        public ActionResult<IEnumerable<EmployeeDto>> searchFilter(string? searchKey)
        {
            return Ok(employeeService.Search(searchKey).Select(x=>x.AsDto()));
        }
       

        [HttpGet("PagedEmployee")]
        public async Task<ActionResult<EmployeepagingDto>> Getpagination(int pageNumber = 1, int pageSize = 3)
        {
            var paging = await employeeService.Getpagination(pageNumber, pageSize);
            return  Ok(paging.AsPagingEmployeeDto());
        }

    }
}

