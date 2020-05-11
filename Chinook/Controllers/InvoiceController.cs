using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chinook.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        InvoiceRepo _repository = new InvoiceRepo();

        //api/invoices
        [HttpGet]
        public IActionResult GetAllInvoiceTotals()
        {
            var invoices = _repository.GetInvoiceTotals();
            var isEmpty = !invoices.Any();
            if(isEmpty)
            {
                return NotFound("No invoices found");
            }
            return Ok(invoices);
        }

        //api/invoices/includes_sales_agent
        [HttpGet("includes_sales_agent")]
        public IActionResult GetAllInvoicesWithSalesAgentName()
        {
            var invoices = _repository.GetInvoiceTotalsWithAgentName();
            var isEmpty = !invoices.Any();
            if (isEmpty)
            {
                return NotFound("No invoices found");
            }
            return Ok(invoices);
        }

        //api/invoices/line_count/{invoiceId}
        [HttpGet("line_count/{invoiceId}")]
        public IActionResult GetInvoiceLineCountById(int invoiceId)
        {
            var invoice = _repository.GetInvoiceLineCount(invoiceId);
            var isEmpty = !invoice.Any();
            if (isEmpty)
            {
                return NotFound("No invoice found by that id");
            }
            return Ok(invoice);
        }

        //api/invoices/groupedBy_country
        [HttpGet("groupedBy_country")]
        public IActionResult GetAllInvoicesGroupedByCountry()
        {
            var invoices = _repository.GetInvoicesGroupedByCountry();
            var isEmpty = !invoices.Any();
            if (isEmpty)
            {
                return NotFound("No invoices found.");
            }
            return Ok(invoices);
        }

        // GET: api/invoices/Brazil
        [HttpGet("{country}")]
        public IActionResult GetInvoicesFromCountry(string country)
        {
            var invoices = _repository.GetAllInvoicesFromCountry(country);
            var isEmpty = !invoices.Any();
            if (isEmpty)
            {
                return NotFound("No invoices found in that country");
            }
            return Ok(invoices);
        }

        // api/invoices/total_sales_by_country
        [HttpGet("total_Sales_by_country")]
        public IActionResult TotalSalesByCountry()
        {
            var sales = _repository.GetTotalSalesByCountry();
            var isEmpty = !sales.Any();
            if (isEmpty)
            {
                return NotFound("No sales found.");
            }
            return Ok(sales);
        }
    }
}