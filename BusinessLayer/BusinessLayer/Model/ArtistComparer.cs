using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ArtistComparer : IEqualityComparer<Artist>
    {
        public bool Equals(Artist a, Artist b)
        {
            return a.ArtistId == b.ArtistId;
        }
        public int GetHashCode(Artist artist)
        {
            return artist.GetHashCode();
        }
    }
}
