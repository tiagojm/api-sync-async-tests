using Microsoft.Extensions.Configuration;
using netcore_3._1_api_performance_tests.Models;
using System;
using System.Collections.Generic;

namespace netcore_3._1_api_performance_tests.Services
{
    public class EmployeeService
    {
        private readonly IConfiguration _configuration;
        private List<Employee> employees = new List<Employee>();
        public IReadOnlyCollection<Employee> Employees 
        { 
            get 
            {
                return this.employees;
            } 
        
        }
        private int employeeAmount;
        private DateTime createdAt;

        public EmployeeService(IConfiguration config)
        {
            this.createdAt = DateTime.Now;
            this._configuration = config;
            if (!Int32.TryParse(_configuration["Tests:EmployeeAmount"], out employeeAmount)) 
            {
                employeeAmount = 50;
            }

            for (int i = 0; i < employeeAmount; i++)
            {
                var employee = new Employee(i) { Name = "Tiago", BirthDate = new DateTime(2000, 1, 1), OnBoardDate = DateTime.Now };
                this.employees.Add(employee);
            }
        }

        
    }
}
