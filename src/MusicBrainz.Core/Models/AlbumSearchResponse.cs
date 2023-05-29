using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicBrainz.Api.Models
{
    public record AlbumSearchResponse
    {
        [JsonPropertyName("releases")]
        public List<Album> Releases { get; set; } = new List<Album>();

    }
}