namespace Employee.CURD.WebApi.DTOs
{
   public record EmployeeDto(Guid Id, string FirstName, string LastName, string Email, string Mobile, long Salary, string Role);
    public record EmployeepagingDto(int TotalCount,int PageIndex,int PageSize,IEnumerable<EmployeeDto>? employees);

 

}



