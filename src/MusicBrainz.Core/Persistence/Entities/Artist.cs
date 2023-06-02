using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainz.Core.Persistence.Entities
{
    public class Artist
    {
        [Key]
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Country { get; set; }
    }
}
