using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_CRUD.DTOs.EmployeeDto
{
    public class AddEmpDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string EmpCode { get; set; }
        public string Position { get; set; }
        public string OfficeLocation { get; set; }
    }
}
