select FirstName + ' ' + LastName as FullName, CustomerId, Country
from Customer
where Customer.Country = 'Brazil'