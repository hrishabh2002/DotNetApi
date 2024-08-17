using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Model.Dtos;
using WebApplication2.Model.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {

        private readonly ApplicationDb _applicationDb;

        public EmployeesController(ApplicationDb applicationDb)
        {
            _applicationDb= applicationDb;
        }

        [HttpGet]
        public IActionResult GetAllEmployees() {

            var emp= _applicationDb.Employees.ToList();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult AddEmployees(EmployeeDto empDto) {

            Employees emp = new Employees()
            {
                Name = empDto.Name,
                Salary = empDto.Salary,
                Address = empDto.Address,
            };

            _applicationDb.Add(emp);
            _applicationDb.SaveChanges();
            return Ok(emp);

        }

        [HttpGet]
        [Route("id")]
        public IActionResult GetEmployee(int id)
        {

            var emp = _applicationDb.Employees.Find(id);
            if(emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPut]
        [Route("id")]
        public IActionResult EditEmployee(int id,UpdateDto updateDto)
        {

            var emp = _applicationDb.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                emp.Salary= updateDto.Salary;
                emp.Address= updateDto.Address;

                _applicationDb.SaveChanges();
                return Ok(emp);
            }
            
        }

        [HttpDelete]
        [Route("id")]
        public IActionResult RemoveEmployee(int id)
        {

            var emp = _applicationDb.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            _applicationDb.Remove(emp);
            _applicationDb.SaveChanges();
            return Ok(emp);
        }
    }
}
