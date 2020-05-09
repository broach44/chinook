﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CustomerFullName { get; set; }
        public string SalesAgentFullName { get; set; }
        public string BillingCountry { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<int> InvoiceLines { get; set; }
    }
}
