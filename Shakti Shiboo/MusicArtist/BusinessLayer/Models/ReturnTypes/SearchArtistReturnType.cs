using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.ReturnTypes
{
    public class SearchArtistReturnType : PageModel
    {
        public List<ArtistModel> Results { get; set; }
        public int NumberOfSearchResults { get; set; }

        public void SetFromData(List<DataLayer.Artist> artists)
        {
            Results = new List<ArtistModel>();

            artists.ForEach(a => {
                Results.Add(new ArtistModel() {
                    Name = a.Name,
                    Country = a.Country.Code,
                    Alias = a.Aliases.Select(al => al.Name).ToList()
                });
            });
        }
    }
}
