select InvoiceId, count(*) as totalLineItems
from InvoiceLine
group by InvoiceId