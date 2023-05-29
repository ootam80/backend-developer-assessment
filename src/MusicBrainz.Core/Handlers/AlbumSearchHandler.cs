using System;
using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;
using Serilog;

namespace MusicBrainz.Core.Handlers
{
     public class AlbumSearchHandler : IAlbumSearchHandler
    {
        private readonly ILogger _logger;

        public AlbumSearchHandler(ILogger logger)
        {
            _logger = logger.ForContext<AlbumSearchHandler>() ?? throw new ArgumentException(nameof(logger));
        }

        public async Task<OneOf<AlbumSearchResponse, NotFound, Error<string>>> HandleAsync(AlbumSearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = new AlbumSearchResponse();

                if (data == null)
                {
                    return new NotFound();
                }

                return data;

            }
            catch (Exception e)
            {
                _logger.Error(e, "An error occurred while handling an artist's albums request");
                return new Error<string>(e.Message);
            }
        }

    }
}