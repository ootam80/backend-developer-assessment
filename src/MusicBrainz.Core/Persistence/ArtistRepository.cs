using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;
using Serilog;
using Artist = MusicBrainz.Core.Persistence.Entities.Artist;

namespace MusicBrainz.Core.Persistence
{
    public sealed class ArtistRepository : IArtistsRepository
    {
        private readonly MusicBrainzDbContext _dbContext;
        private readonly ILogger _logger;

        public ArtistRepository(MusicBrainzDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger.ForContext<AlbumRepository>() ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<OneOf<ArtistSearchResponse, NotFound, Error<string>>> GetArtistAsync(ArtistSearchRequest request, CancellationToken cancellationToken)
        {

            try
            {
                //var artist = await _dbContext.Aliases
                //.Where(x => string.Equals(x.ArtistId.ToLower(), request.SearchCriteria.ToLower()))
                //.ToListAsync(cancellationToken);

                //if (artist == null || !artist.Any())
                //{
                //    return new NotFound();
                //}

                var artists = await (from ali in _dbContext.Aliases
                              join art in _dbContext.Artist
                              on ali.ArtistId equals art.ArtistId
                              where art.ArtistName.StartsWith(request.SearchCriteria)
                              select new Models.Artist()
                              {
                                   Name = art.ArtistName, 
                                   Country = art.Country,
                                   Alias = ali.Alias.Split(',', StringSplitOptions.None ).ToList()
                              }).Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

                if (artists == null)
                {
                    return new NotFound();
                }

                var noOfPages = (int) Math.Ceiling((double)artists.Count / request.PageSize);

                return new ArtistSearchResponse
                {
                    Page = request.PageNumber.ToString(),
                    PageSize = request.PageSize.ToString(),
                    NumberOfPages = noOfPages.ToString(),
                    Result = artists,
                    NumberOfSearchResults = artists.Count
                };

            }
            catch (Exception e)
            {

                _logger
                    .ForContext("Query", request)
                    .Error(e, "An error occurred while fetching artist information");

                return new Error<string>(e.Message);
            }
        }

    }
}
