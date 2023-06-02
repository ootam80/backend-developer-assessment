using System.Threading;
using System.Threading.Tasks;
using MusicBrainz.Api.Models;
using MusicBrainz.Core.Models;
using OneOf;
using OneOf.Types;

namespace MusicBrainz.Core.Persistence
{
    public interface IAlbumRepository
    {
        Task<OneOf<AlbumSearchResponse, NotFound, Error<string>>> GetAlbumsAsync(AlbumSearchRequest request, CancellationToken cancellationToken);
    }
}
