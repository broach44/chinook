select Employee.EmployeeId, Employee.FirstName, Employee.LastName,Count(*) as CustomerCount
from Customer
	join Employee
		on Customer.SupportRepId = Employee.EmployeeId
group by EmployeeId, Employee.Firstname, Employee.LastName