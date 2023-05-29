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
     public class AlbumSearchHandler : IAlbumSearchHandler
    {
        private readonly ILogger _logger;
        private readonly IAlbumRepository _albumRepository;

        public AlbumSearchHandler(ILogger logger, IAlbumRepository albumRepository)
        {
            _logger = logger.ForContext<AlbumSearchHandler>() ?? throw new ArgumentException(nameof(logger));
            _albumRepository = albumRepository ?? throw new ArgumentNullException(nameof(albumRepository));
        }

        public async Task<OneOf<AlbumSearchResponse, NotFound, Error<string>>> HandleAsync(AlbumSearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await _albumRepository.GetAlbumsAsync(request, cancellationToken);
            }
            catch (Exception e)
            {
                _logger.Error(e, "An error occurred while handling an artist's albums request");
                return new Error<string>(e.Message);
            }
        }

    }
}