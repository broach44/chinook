select 
	Invoice.*, 
	--Customer.FirstName + ' ' + Customer.LastName as CustomerFullName, 
	Employee.FirstName + ' ' + Employee.LastName as SalesAgentFullName
from Invoice
	join Customer
		on Customer.CustomerId = Invoice.CustomerId
	join Employee
		on Customer.SupportRepId = Employee.EmployeeId
