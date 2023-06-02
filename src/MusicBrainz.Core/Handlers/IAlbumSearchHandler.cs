using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;

namespace MusicBrainz.Core.Handlers
{
    public interface IAlbumSearchHandler
    {
        Task<OneOf<AlbumSearchResponse, NotFound, Error<string>>> HandleAsync(AlbumSearchRequest request, CancellationToken cancellationToken);
    }
}