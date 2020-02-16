using CORE_CRUD.DTOs.EmployeeDto;
using CORE_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_CRUD.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task AddEmployee(AddEmpDto addEmpDto);
        Task EditEmployee();
        Task<Employee> GetEmployee();
        List<Employee> AllEmployees();
    }
}
