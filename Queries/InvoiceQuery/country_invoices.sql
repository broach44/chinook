select BillingCountry, count(*)
from Invoice
group by BillingCountry