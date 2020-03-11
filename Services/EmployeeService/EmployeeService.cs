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

        public async Task DeleteEmployee(int id)
        {
            var employeeRecord = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employeeRecord);
            await _context.SaveChangesAsync();
        }

        public async Task EditEmployee(Employee employee)
        {
            var employeeRecord = await _context.Employees.FindAsync(employee.EmployeeId);

            employeeRecord.EmployeeId = employee.EmployeeId;
            employeeRecord.Email = employee.Email;
            employeeRecord.EmpCode = employee.EmpCode;
            employeeRecord.FullName = employee.FullName;
            employeeRecord.OfficeLocation = employee.OfficeLocation;
            employeeRecord.Position = employee.Position;

            _context.Employees.Update(employeeRecord);
            await _context.SaveChangesAsync();
        }

        public Task<Employee> GetEmployee()
        {
            throw new NotImplementedException();
        }

    }
}
