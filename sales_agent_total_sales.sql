select Employee.EmployeeId, Employee.FirstName + ' ' + Employee.LastName as EEFullName, sum(Invoice.Total) as TotalSales
from Invoice
	join Customer
		on Customer.CustomerId = Invoice.CustomerId
	join Employee
		on Customer.SupportRepId = Employee.EmployeeId
group by Employee.EmployeeId, Employee.FirstName, Employee.LastName