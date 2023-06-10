using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Dto
{
    public class SearchArtistDto
    {
        public string SearchCriteria { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
