using System.ComponentModel.DataAnnotations;

namespace Employee.CURD.Model
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public long Salary { get; set; }
        public string Role { get; set; }

    }

}
