select Playlist.[Name], count(*) as TrackCount
from PlaylistTrack
	join Playlist
		on PlaylistTrack.PlaylistId = Playlist.PlaylistId
group by Playlist.[Name]