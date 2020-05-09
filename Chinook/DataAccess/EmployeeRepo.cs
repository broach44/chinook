using System;
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

        public IEnumerable<EmployeeTotalSales> GetEmployeeTotalSales()
        {
            var sql = @"
                        select Employee.EmployeeId, (Employee.FirstName + ' ' + Employee.LastName) as EmployeeFullName, sum(Invoice.Total) as TotalSales
                        from Invoice
	                        join Customer
		                        on Customer.CustomerId = Invoice.CustomerId
	                        join Employee
		                        on Customer.SupportRepId = Employee.EmployeeId
                        group by Employee.EmployeeId, Employee.FirstName, Employee.LastName;
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<EmployeeTotalSales>(sql);
                return result;
            }
        }

        public IEnumerable<SalesAgentCustomerCount> GetSalesAgentCustomerCounts()
        {
            var sql = @"
                        select Employee.EmployeeId, Employee.FirstName, Employee.LastName,Count(*) as CustomerCount
                        from Customer
	                        join Employee
		                        on Customer.SupportRepId = Employee.EmployeeId
                        group by EmployeeId, Employee.Firstname, Employee.LastName;
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<SalesAgentCustomerCount>(sql);
                return result;
            }
        }

        public IEnumerable<TopSalesAgent> GetTopSalesAgent()
        {
            var sql = @"
                        select TOP(1) Employee.EmployeeId, Employee.FirstName + ' ' + Employee.LastName as EmployeeFullName, sum(Invoice.Total) as TotalSales
                        from Invoice
	                        join Customer
		                        on Customer.CustomerId = Invoice.CustomerId
	                        join Employee
		                        on Customer.SupportRepId = Employee.EmployeeId
                        group by Employee.EmployeeId, Employee.FirstName, Employee.LastName
                        order by sum(Invoice.Total) desc;
                      ";

            using (var db = new SqlConnection(ConnectionString))
            {
                var result = db.Query<TopSalesAgent>(sql);
                return result;
            }
        }

    }
}
