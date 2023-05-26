using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;

namespace MusicBrainz.Core.Handlers
{
    public interface IArtistSearchHandler
    {
        Task<OneOf<List<Artist>, NotFound, Error<string>>> HandleAsync(ArtistSearchRequest request, CancellationToken cancellationToken);
    }
}
