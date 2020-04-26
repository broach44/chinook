select top(5) with ties count(InvoiceLine.InvoiceLineId) as purchaseCount, Track.[Name]
from InvoiceLine
	join Track
		on InvoiceLine.TrackId = Track.TrackId
	join Invoice
		on InvoiceLine.InvoiceId = Invoice.InvoiceId
group by Track.[Name]
order by count(*) desc
