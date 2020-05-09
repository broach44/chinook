using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.Models
{
    public class TopSalesAgent
    {
        public int EmployeeId { get; set; }
        public string EmployeeFullName {get; set;}
        public decimal TotalSales { get; set; }

    }
}
