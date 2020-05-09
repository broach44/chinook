using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class InvoiceByCountry
    {
        public string BillingCountry { get; set; }
        public decimal Total { get; set; }
    }
}
