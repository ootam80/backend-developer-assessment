using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;

namespace MusicBrainz.Core.Handlers
{
    public interface IArtistSearchHandler
    {
        Task<OneOf<ArtistSearchResponse, NotFound, Error<string>>> HandleAsync(ArtistSearchRequest request, CancellationToken cancellationToken);
    }
}
