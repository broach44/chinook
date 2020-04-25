select *
from Artist
--where id > 100
--where Name like 'P%m'
--where name in ('AC/DC', 'Os Mutantes', 'Olodum')
--and ArtistId > 100


-- inner join
-- artists that have matching album
select Artist.Name as ArtistName, Album.Title as AlbumName
from Artist
	join Album
		on Artist.ArtistId = Album.ArtistId

-- left outer join
-- all artists and any matching album
select Artist.Name as ArtistName, Album.Title as AlbumName
from Artist
	left join Album
		on Artist.ArtistId = Album.ArtistId
where Album.Title is null

-- right outer join
-- all albums and any matching artist
select Artist.Name as ArtistName, Album.Title as AlbumName
from Artist
	right join Album
		on Artist.ArtistId = Album.ArtistId

-- all albums with an artist that starts with 'a'
select Album.*
from Album
	join Artist
		on album.ArtistId = Artist.ArtistId
where Artist.Name like 'a%'

-- combine similar result sets
-- union -- give me the unique combination
--union all -- the all says don't elimnate duplicates
except  -- only those from the first set that don't appear in the second set

-- all albums and tracks that start with the letter b
select distinct Album.*
from Album
	join Track
		on Track.AlbumId = Album.AlbumId
where track.Name like 'b%'
-- order by Album.Title desc (implicitly orders ascending if 'desc' not included)


select artistId, count(*) as albumCount
from Album
where ArtistId in (select ArtistId from Artist where Name like 'a%')
group by ArtistId

select artist.ArtistId, artist.Name, count(*)
from Album
	join Artist
		on  Album.ArtistId = Artist.ArtistId
where Artist.Name like 'a%'
group by artist.ArtistId, artist.name


select invoiceId, sum(unitprice * quantity)
from InvoiceLine
group by InvoiceId