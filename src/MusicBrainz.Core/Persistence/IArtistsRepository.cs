using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;

namespace MusicBrainz.Core.Persistence
{
    public interface IArtistsRepository
    {
        Task<List<ArtistSearchResponse>> GetArtistsAsync(ArtistSearchRequest request, CancellationToken cancellationToken);
    }
}
