using System.Collections.Generic;

namespace BusinessLayer.Model.ReturnTypes
{
    public class SearchResultReturnType
    {
        public List<ArtistDetailsReturnType> Results { get; set; }
        public int NumberOfSearchResults { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int NumberOfPages { get; set; }
    }
}
