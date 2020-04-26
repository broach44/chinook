select 
	Track.[Name] as TrackName, 
	Album.Title as AlbumName,
	Composer,
	Milliseconds,
	Bytes,
	UnitPrice,
	Genre.[Name] as Genre,
	MediaType.[Name] as MediaType
from Track
	join Album
		on Track.AlbumId = Album.AlbumId
	join Genre
		on  Track.GenreId = Genre.GenreId
	join MediaType
		on Track.MediaTypeId = MediaType.MediaTypeId