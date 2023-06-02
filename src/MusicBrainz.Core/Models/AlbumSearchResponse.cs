using System.Collections.Generic;
using System.Text.Json.Serialization;
using MusicBrainz.Core.Models;

namespace MusicBrainz.Api.Models
{
    public class AlbumSearchResponse
    {
        [JsonPropertyName("releases")]
        public List<Album> Releases { get; set; } = new List<Album>();

    }
}