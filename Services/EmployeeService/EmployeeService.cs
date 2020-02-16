using CORE_CRUD.DTOs.EmployeeDto;
using CORE_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_CRUD.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(AddEmpDto addEmpDto)
        {
            Employee employee = new Employee
            {
                Email = addEmpDto.Email,
                EmpCode = addEmpDto.EmpCode,
                FullName = addEmpDto.FullName,
                OfficeLocation = addEmpDto.OfficeLocation,
                Position = addEmpDto.Position
            };

            await _context.Employees.AddAsync(employee);
            _context.SaveChanges();
        }

        public List<Employee> AllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Task EditEmployee()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee()
        {
            throw new NotImplementedException();
        }

    }
}
