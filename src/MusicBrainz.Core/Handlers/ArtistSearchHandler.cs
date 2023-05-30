using System;
using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using MusicBrainz.Core.Persistence;
using OneOf;
using OneOf.Types;
using Serilog;

namespace MusicBrainz.Core.Handlers
{
    public sealed class ArtistSearchHandler : IArtistSearchHandler
    {
        private readonly ILogger _logger;

        private readonly IArtistsRepository _artistsRepository;

        public ArtistSearchHandler(ILogger logger, IArtistsRepository artistsRepository)
        {
            _logger = logger.ForContext<ArtistSearchHandler>() ?? throw new ArgumentException(nameof(logger));
            _artistsRepository = artistsRepository ?? throw new ArgumentException(nameof(artistsRepository));
        }

        public async Task<OneOf<ArtistSearchResponse, NotFound, Error<string>>> HandleAsync(ArtistSearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _artistsRepository.GetArtistAsync(request, cancellationToken);

            }
            catch (Exception e)
            {
                _logger.Error(e, "An error occurred while handling an artist request");
                return new Error<string>(e.Message);
            }
        }
    }
}
