using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;

namespace MusicBrainz.Core.Persistence
{
    public sealed class ArtistRepository : IArtistsRepository
    {
        public Task<List<ArtistSearchResponse>> GetArtistsAsync(ArtistSearchRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
