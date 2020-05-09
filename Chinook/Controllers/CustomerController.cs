using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerRepo _repository = new CustomerRepo();

        // GET: api/customers/Brazil
        [HttpGet("{country}")]
        public IActionResult GetByCountry(string country)
        {
            var customers = _repository.GetCustomersByCountry(country);
            var isEmpty = !customers.Any();
            if (isEmpty)
            {
                return NotFound("No customers found in that country");
            }
            return Ok(customers);

           
        }

    }
}
