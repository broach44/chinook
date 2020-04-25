select Customer.FirstName + ' ' + Customer.LastName as FullName, InvoiceId, InvoiceDate, BillingCountry
from Invoice
	join Customer
		on invoice.CustomerId = customer.CustomerId
where BillingCountry = 'brazil'
order by customer.LastName
