using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Models;
using Dapper;

namespace Chinook.DataAccess
{
    public class InvoiceRepo
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";

        public IEnumerable<Invoice> GetInvoiceTotals()
        {
            var sql = @"
                      select 
	                    Invoice.InvoiceId,
	                    Invoice.Total,
                        Invoice.InvoiceDate,
	                    Customer.FirstName + ' ' + Customer.LastName as CustomerFullName, 
	                    Invoice.BillingCountry,
	                    Employee.FirstName + ' ' + Employee.LastName as SalesAgentFullName
                      from Invoice
	                    join Customer
		                    on Customer.CustomerId = Invoice.CustomerId
	                    join Employee
		                    on Customer.SupportRepId = Employee.EmployeeId; 
                      ";

            var sql2 = @"
                        select invoiceLineId, invoiceid from invoiceline;
                        ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<Invoice>(sql);
                var result2 = db.Query<InvoiceLine>(sql2);
                
                foreach (var invoice in result)
                {
                    
                    invoice.InvoiceLines = result2.Where(il => il.InvoiceId == invoice.InvoiceId).Select(il => il.InvoiceLineId);                    
                }

                

                return result;
            }
        }

        public IEnumerable<InvoiceLineCount> GetInvoiceLineCount(int invoiceId)
        {
            var sql = @"
                        select InvoiceLine.InvoiceId, count(*) as LineCount
                        from InvoiceLine
                        where InvoiceId = @InvoiceId
						group by InvoiceLine.InvoiceId;
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { InvoiceId = invoiceId };
                var result = db.Query<InvoiceLineCount>(sql,parameters);
                return result;
            }
        }

        public IEnumerable<InvoiceByCountry> GetInvoicesGroupedByCountry()
        {
            var sql = @"
                        select Invoice.BillingCountry, sum(Invoice.Total) as Total
                        from Invoice
                        group by Invoice.BillingCountry;
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<InvoiceByCountry>(sql);
                return result;
            }
        }

        public IEnumerable<InvoiceFromCountry> GetAllInvoicesFromCountry(string country)
        {
            var sql = @"
                        select (Customer.FirstName + ' ' + Customer.LastName) as FullName, InvoiceId, InvoiceDate, BillingCountry
                        from Invoice
	                        join Customer
		                        on invoice.CustomerId = customer.CustomerId
                        where BillingCountry = @BillingCountry
                        order by customer.LastName;
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { BillingCountry = country };
                var result = db.Query<InvoiceFromCountry>(sql, parameters);
                return result;
            }
        }
    }
}
