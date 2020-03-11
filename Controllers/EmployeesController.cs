using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORE_CRUD.DTOs.EmployeeDto;
using CORE_CRUD.Models;
using CORE_CRUD.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CORE_CRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return PartialView(_service.AllEmployees());
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmpDto addEmpDto)
        {
            if (ModelState.IsValid)
            {
                _service.AddEmployee(addEmpDto);

                return RedirectToAction("Index", "Employees");
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Edit(Employee employee)
        {
            await _service.EditEmployee(employee);
            return Json(employee);
        }
        
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _service.DeleteEmployee(id);
            return Json("success");
        }
    }
}