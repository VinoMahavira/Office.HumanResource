using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Office.HumanResource.WebApi.Models;

namespace Office.HumanResource.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly HumanResourceContext _context;

        public EmployeesController(HumanResourceContext context)
        {
            _context = context;            
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}
