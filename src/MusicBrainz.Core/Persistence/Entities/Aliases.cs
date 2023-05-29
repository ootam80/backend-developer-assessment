using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicBrainz.Core.Persistence.Entities
{
    public class Aliases
    {
        [Key]
        public string AliasesId { get; set; }
        public string ArtistId { get; set; }
        public string Alias { get; set; }
    }
}