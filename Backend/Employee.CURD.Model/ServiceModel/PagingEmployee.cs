using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Employee.CURD.Model.ServiceModel
{
    public  class PagingEmployee
    {

        

 public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<EmployeeModel> Employees { get; set; }


    }
}
