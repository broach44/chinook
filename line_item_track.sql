select InvoiceLine.*, Track.[Name]
from InvoiceLine
	join Track
		on InvoiceLine.TrackId = Track.TrackId