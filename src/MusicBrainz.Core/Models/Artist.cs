using System.Collections.Generic;

namespace MusicBrainz.Api.Models
{
    public record Artist
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public List<string> Alias { get; set; } = new List<string>();
    }
}
