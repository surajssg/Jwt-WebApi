using JwtImplementation.Interfaces;
using JwtImplementation.Models;
using JwtImplementation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<Employee> Get()
        {
        
            var emps = _employeeService.GetEmployeeDetails();
            return emps;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public Employee Get(int id)
        {
            var emp = _employeeService.GetEmployee(id);

            return emp;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public Employee Post([FromBody] Employee employee)
        {
            var emp = _employeeService.AddEmployee(employee);

            return emp;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public Employee Update(int id, [FromBody] Employee employee)
        {
            var emp = _employeeService.UpdateEmployee(employee);

            return emp; 
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public bool Delete(int id)
        {
            var emp = (_employeeService.DeleteEmployee(id));
             return emp;
        }
    }
}
