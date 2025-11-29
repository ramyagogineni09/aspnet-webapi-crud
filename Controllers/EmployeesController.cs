using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult GetAllEmployess()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);

        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDtos addEmployeeDtos)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDtos.Name,
                Email = addEmployeeDtos.Email,
                Phone = addEmployeeDtos.Phone,
                Salary = addEmployeeDtos.Salary

            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);



        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(employee);


        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) { 
            var employees=dbContext.Employees.Find(id);
            if (employees is null) { 
                return NotFound();
            }
          dbContext.Employees.Remove(employees);
            dbContext.SaveChanges();
            return Ok(employees);
        
        }
    }
}
