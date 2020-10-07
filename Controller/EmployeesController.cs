using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Api.Models;
using EmployeeManager.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository = null;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public List<Employee> Get()
        {
            return employeeRepository.SelectAll();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employeeRepository.SelectByID(id);
        }

        [HttpPost]
        public void Post([FromBody]Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Insert(emp);

            }
        }

        // The id parameter isn't used for the update process, 
        // since it is included in the emp object.
        // Book left it like this "in case you want to use it for some processing"
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.Update(emp);

            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }
    }
}
