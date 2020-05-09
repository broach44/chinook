select sum(Invoice.Total) as InvoiceTotal2009
from Invoice
where InvoiceDate between '2009-01-01' and '2009-12-31'

select sum(Invoice.Total) as InvoiceTotal2011
from Invoice
where InvoiceDate between '2011-01-01' and '2011-12-31'
