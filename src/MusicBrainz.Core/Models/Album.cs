using System.Collections.Generic;

namespace MusicBrainz.Core.Models
{
    public class Album
    {
        public string ReleaseId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Label { get; set; }

        public int NumberOfTracks { get; set; }

        public List<OtherArtist> OtherArtist { get; set; }

    }

    public class OtherArtist
    {
        public string? Id { get; set; }

        public string? Name { get; set; }
    }
}