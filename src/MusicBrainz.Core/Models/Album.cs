using System.Collections.Generic;

namespace MusicBrainz.Api.Models
{
    public record Album
    {
        public string ReleaseId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Lable { get; set; }

        public int NumberOfTracks { get; set; }

        public List<OtherArtist> OtherArtist { get; set; }

    }

    public record OtherArtist
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}