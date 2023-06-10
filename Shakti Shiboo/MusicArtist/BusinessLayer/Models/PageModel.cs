using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class PageModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int NumberOfPages { get; set; }
    }
}
