select Invoice.BillingCountry, sum(Invoice.Total)
from Invoice
group by Invoice.BillingCountry