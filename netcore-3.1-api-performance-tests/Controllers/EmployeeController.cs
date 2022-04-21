using Microsoft.AspNetCore.Mvc;
using netcore_3._1_api_performance_tests.Models;
using netcore_3._1_api_performance_tests.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace netcore_3._1_api_performance_tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private DateTime createdAt;
        private EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.createdAt = DateTime.Now;
            this._employeeService = employeeService;
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = new Employee { Name = "Tiago", BirthDate = new System.DateTime(2000, 1, 1), OnBoardDate = new System.DateTime(2021, 11, 25) };
            Thread.Sleep(1000); //simulates a 1 second duration IO/database operation
            return Ok(employee);
        }

        [HttpGet("async/{id}", Name = "GetEmployeeAsync")]
        public async Task<ActionResult<Employee>> GetAsync(int id)
        {
            var employee = new Employee { Name = "Tiago", BirthDate = new System.DateTime(2000, 1, 1), OnBoardDate = new System.DateTime(2021, 11, 25) };
            await Task.Delay(1000); //simulates a 1 second duration IO/database operation
            return Ok(employee);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            IEnumerable<Employee> employees = _employeeService.Employees;
            Thread.Sleep(2000); //simulates a 2 seconds duration IO/database operation
            return Ok(employees);
        }

        [HttpGet("async")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAsync()
        {
            IEnumerable<Employee> employees = _employeeService.Employees;
            await Task.Delay(1000); //simulates a 2 seconds duration IO/database operation
            return Ok(employees);
        }
    }
}
