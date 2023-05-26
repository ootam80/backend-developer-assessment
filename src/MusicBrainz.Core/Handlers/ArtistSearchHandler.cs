using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public async Task<OneOf<List<Artist>, NotFound, Error<string>>> HandleAsync(ArtistSearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = new List<Artist>();

                if (data?.Any() != true)
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
