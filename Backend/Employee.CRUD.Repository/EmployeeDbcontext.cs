using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CRUD.Repository
{
    public class EmployeeApiDbContext : DbContext
    {
        public EmployeeApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}

