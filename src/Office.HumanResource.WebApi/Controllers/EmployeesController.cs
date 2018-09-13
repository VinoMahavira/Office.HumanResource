using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Office.HumanResource.Core.Entities;
using Office.HumanResource.Core.Interfaces;

namespace Office.HumanResource.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;            
        }

        [HttpGet]
        public IActionResult List()
        {
            var items = _employeeRepository.List();
            return Ok(items);
        }
    }
}
