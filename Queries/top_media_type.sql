select top(1) count(InvoiceLine.InvoiceLineId) as purchaseCount, Track.MediaTypeId, MediaType.Name
from InvoiceLine
	join Track
		on InvoiceLine.TrackId = Track.TrackId
	join Invoice
		on InvoiceLine.InvoiceId = Invoice.InvoiceId
	join MediaType
		on MediaType.MediaTypeId = Track.MediaTypeId
group by Track.MediaTypeId, MediaType.Name
order by count(*) desc
