using HumanResourceManagement.ApplicationCore.Data;
using HumanResourceManagement.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceManagement.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        HumanResourceContext db = new HumanResourceContext();

        [HttpGet]
        public IActionResult Get()
        {
            var employees = db.Employees.ToList();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employees = db.Employees.Find(id);
            if (employees == null)
            {
                return NotFound("no employee exists");
            }

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            if (employee == null)
                return BadRequest();

            db.Employees.Add(employee);
            db.SaveChanges();

            return Created($"api/employees/{employee.Id}", null);
        }
        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges();

            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
                return BadRequest("Employee id you provided does not exist.");

            db.Employees.Remove(employee);
            db.SaveChanges();

            return NoContent();
        }


    }
}
//API, WEB API, HTTP API, REST API, HTTP EndPoints etc all are same.
//Api: application programming interface.
