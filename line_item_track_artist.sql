select InvoiceLine.*, Track.[Name], Track.Composer
from InvoiceLine
	join Track
		on InvoiceLine.TrackId = Track.TrackId