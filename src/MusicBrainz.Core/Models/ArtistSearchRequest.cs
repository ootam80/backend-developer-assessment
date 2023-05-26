namespace MusicBrainz.Core.Models
{
    public record ArtistSearchRequest
    {
        public string SearchCriteria { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
