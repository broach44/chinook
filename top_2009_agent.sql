select TOP(1) Employee.EmployeeId, Employee.FirstName + ' ' + Employee.LastName as EEFullName, sum(Invoice.Total) as TotalSales
from Invoice
	join Customer
		on Customer.CustomerId = Invoice.CustomerId
	join Employee
		on Customer.SupportRepId = Employee.EmployeeId
where InvoiceDate between '2009-01-01' and '2009-12-31'
group by Employee.EmployeeId, Employee.FirstName, Employee.LastName
order by sum(Invoice.Total) desc
