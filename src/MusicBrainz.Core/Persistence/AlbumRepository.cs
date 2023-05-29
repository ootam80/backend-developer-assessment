using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;
using Serilog;
using Album = MusicBrainz.Core.Persistence.Entities.Album;
using Artist = MusicBrainz.Core.Persistence.Entities.Artist;

namespace MusicBrainz.Core.Persistence
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicBrainzDbContext _dbContext;
        private readonly ILogger _logger;


        public AlbumRepository(MusicBrainzDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger.ForContext<AlbumRepository>() ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OneOf<AlbumSearchResponse, NotFound, Error<string>>> GetAlbumsAsync(AlbumSearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var albums = await _dbContext.Albums
                    .Where(x => string.Equals(x.ArtistId.ToLower(), request.ArtistId.ToLower()))
                    .ToListAsync(cancellationToken);

                if (albums == null || !albums.Any())
                {
                    return new NotFound();
                }

                var featuringArtists = await _dbContext.FeaturingArtist.Where(x => albums
                    .Select(y => y.ReleaseId.ToLower())
                    .Contains(x.ReleaseId.ToLower())).ToListAsync(cancellationToken);

                if (featuringArtists == null || !featuringArtists.Any())
                {
                    return new NotFound();
                }

                var artists = await _dbContext.Artist
                    .Where(x => featuringArtists.Select(y => y.ArtistId.ToLower()).Contains(x.ArtistId))
                    .ToListAsync(cancellationToken);

                return ConsolidateResult(albums, artists);
            }
            catch (Exception e)
            {
                _logger
                    .ForContext("Query", request)
                    .Error(e, "An error occurred while fetching albums");

                return new Error<string>(e.Message);
            }
        }

        private static AlbumSearchResponse ConsolidateResult(List<Album> albums, List<Artist> artists)
        {
            var response = new AlbumSearchResponse
            {
                Releases = new List<Models.Album>()
            };

            foreach (var album in albums)
            {
                response.Releases.Add(new Models.Album
                {
                    Label = album.Label,
                    NumberOfTracks = album.NumberOfTracks,
                    ReleaseId = album.ReleaseId,
                    Status = album.Status,
                    Title = album.Title,
                    OtherArtist = artists.Select(x => new OtherArtist{ Id = x.ArtistId, Name = x.ArtistName}).ToList()
                });
            }

            return response;
        }
    }
}
