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
    public class ArtistSearchHandler : IArtistSearchHandler
    {
        private readonly ILogger _logger;

        public ArtistSearchHandler(ILogger logger)
        {
            _logger = logger.ForContext<ArtistSearchHandler>() ?? throw new ArgumentException(nameof(logger));
        }

        public async Task<OneOf<ArtistSearchResponse, NotFound, Error<string>>> HandleAsync(ArtistSearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = new ArtistSearchResponse();

                if (data == null)
                {
                    return new NotFound();
                }

                return data;

            }
            catch (Exception e)
            {
                _logger.Error(e, "An error occurred while handling an artist request");
                return new Error<string>(e.Message);
            }
        }
    }
}
