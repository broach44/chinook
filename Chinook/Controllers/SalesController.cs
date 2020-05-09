using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        SalesRepo _repository = new SalesRepo();

        //api/sales/
        [HttpGet]
        public IActionResult GetAllInvoicesGroupedByCountry()
        {
            var invoices = _repository.GetInvoicesGroupedByCountry();
            var isEmpty = !invoices.Any();
            if (isEmpty)
            {
                return NotFound("No invoices found in that country");
            }
            return Ok(invoices);

        }
    }
}