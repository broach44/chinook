select top(1) Invoice.BillingCountry, sum(Invoice.Total)
from Invoice
group by Invoice.BillingCountry
order by sum(Invoice.Total) desc
