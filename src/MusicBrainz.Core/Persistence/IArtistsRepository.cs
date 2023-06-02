using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;

namespace MusicBrainz.Core.Persistence
{
    public interface IArtistsRepository
    {
        Task<OneOf<ArtistSearchResponse, NotFound, Error<string>>> GetArtistAsync(ArtistSearchRequest request, CancellationToken cancellationToken);
    }
}
