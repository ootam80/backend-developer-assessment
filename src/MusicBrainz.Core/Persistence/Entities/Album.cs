using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicBrainz.Core.Persistence.Entities
{
    public class Album
    {
        [Key]
        public string ReleaseId { get; set; }

        public string ArtistId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public int NumberOfTracks { get; set; }
    }
}