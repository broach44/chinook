﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Chinook.Models;
using Dapper;

namespace Chinook.DataAccess
{
    public class EmployeeRepo
    {
        const string ConnectionString = "Server=localhost;Database=Chinook;Trusted_Connection=True;";

        public IEnumerable<Employee> GetAllEmployees()
        {
            var sql = @"
                        select *
                        from Employee;
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<Employee>(sql);

                return result;
            }
        }
        
        public IEnumerable<Employee> GetAllSalesAgents()
        {
            var sql = @"
                        select  *
                        from Employee
                        where employee.Title = 'sales support agent';
                        ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<Employee>(sql);
                return result;
            }
        }

    }
}
