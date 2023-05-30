using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicBrainz.Core.Models
{
    public record ArtistSearchResponse
    {
        [JsonPropertyName("result")]
        public List<Artist> Result { get; set; } = new List<Artist>();

        public int NumberOfSearchResults { get; set; }

        public string Page { get; set; }

        public string PageSize { get; set; }

        public string NumberOfPages { get; set; }
    }
}
