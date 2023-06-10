﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class ArtistModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<string> Alias { get; set; }
    }
}
