select 
	Invoice.InvoiceId,
	Invoice.Total,
	Customer.FirstName + ' ' + Customer.LastName as CustomerFullName, 
	Invoice.BillingCountry,
	Employee.FirstName + ' ' + Employee.LastName as SalesAgentFullName
from Invoice
	join Customer
		on Customer.CustomerId = Invoice.CustomerId
	join Employee
		on Customer.SupportRepId = Employee.EmployeeId