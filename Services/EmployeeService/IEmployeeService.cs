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
        //Create 
        Task AddEmployee(AddEmpDto addEmpDto);
        Task EditEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task<Employee> GetEmployee();
        List<Employee> AllEmployees();
    }
}
