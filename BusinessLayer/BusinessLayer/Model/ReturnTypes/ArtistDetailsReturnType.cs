using System.Collections.Generic;

namespace BusinessLayer.Model.ReturnTypes
{
    public class ArtistDetailsReturnType
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string> Alias { get; set; }
        public List<string> AlbumsLink { get; set; }
    }
}
