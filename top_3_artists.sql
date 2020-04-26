select top(3) count(InvoiceLine.InvoiceLineId) as purchaseCount, Track.Composer
from InvoiceLine
	join Track
		on InvoiceLine.TrackId = Track.TrackId
	join Invoice
		on InvoiceLine.InvoiceId = Invoice.InvoiceId
where Track.Composer is not null
group by Track.Composer
order by count(*) desc
