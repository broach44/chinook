select FirstName + ' ' + LastName as FullName, CustomerId, Country
from Customer
where customer.Country != 'USA'