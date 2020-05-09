using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Models;
using Dapper;

namespace Chinook.DataAccess
{
    public class SalesRepo
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";

        public IEnumerable<Invoice> GetInvoicesGroupedByCountry()
        {
            var sql = @"
                        select Invoice.BillingCountry, sum(Invoice.Total) as Total
                        from Invoice
                        group by Invoice.BillingCountry 
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                //var parameters = new { Country = country } << Need to get the sum of the invoice ;
                var result = db.Query<Invoice>(sql);
                return result;
            }
        }
    }
}
