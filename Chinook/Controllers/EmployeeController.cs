using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chinook.DataAccess;

namespace Chinook.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepo _repository = new EmployeeRepo();

        //api/employees
        [HttpGet]
        public IActionResult AllEmployeeInformation()
        {
            var employees = _repository.GetAllEmployees();
            var isEmpty = !employees.Any();
            if (isEmpty)
            {
                return NotFound("No customers found in that country");
            }
            return Ok(employees);
        }

        //api/employees/sales_agents
        [HttpGet("sales_agents")]
        public IActionResult AllSalesAgentsInformation()
        {
            var employees = _repository.GetAllSalesAgents();
            var isEmpty = !employees.Any();
            if (isEmpty)
            {
                return NotFound("Couldn't find any sales agents.");
            }
            return Ok(employees);
        }

        //api/employees/total_sales_by_employee
        [HttpGet("total_sales_by_employee")]
        public IActionResult EmployeeTotalSales()
        {
            var employeeSales = _repository.GetEmployeeTotalSales();
            var isEmpty = !employeeSales.Any();
            if (isEmpty)
            {
                return NotFound("Not able to find employee sales information");
            }
            return Ok(employeeSales);
        }

        //api/employees/sales_agent_customer_counts
        [HttpGet("sales_agent_customer_counts")]
        public IActionResult SalesAgentCustomerCounts()
        {
            var agents = _repository.GetSalesAgentCustomerCounts();
            var isEmpty = !agents.Any();
            if (isEmpty)
            {
                return NotFound("Not able to find sales agents counts");
            }
            return Ok(agents);
        }
    }
}