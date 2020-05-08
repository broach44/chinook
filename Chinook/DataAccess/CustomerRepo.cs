using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Models;
using Dapper;

namespace Chinook.DataAccess
{
    public class CustomerRepo
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";

        public IEnumerable<Customer> GetCustomersByCountry(string country)
        {
            var sql = @"
                      select *
                      from Customer
                      where Country = @Country  
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var parameters = new { Country = country };
                var result =  db.Query<Customer>(sql, parameters);
                return result;
            }
        }

    }
}
