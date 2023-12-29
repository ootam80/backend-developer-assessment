using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{

    public class RootObject
    {
        public object[] ipis { get; set; }
        public object genderid { get; set; }
        public string disambiguation { get; set; }
        public string[] isnis { get; set; }
        public string id { get; set; }
        public string country { get; set; }
        public ReleaseGroups[] releasegroups { get; set; }
        public Begin_Area begin_area { get; set; }
        public Area area { get; set; }
        public string typeid { get; set; }
        public string sortname { get; set; }
        public object end_area { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public LifeSpan lifespan { get; set; }
        public object endarea { get; set; }
        public BeginArea beginarea { get; set; }
        public object gender { get; set; }
    }

    public class Begin_Area
    {
        public string sortname { get; set; }
        public string disambiguation { get; set; }
        public object type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public object typeid { get; set; }
    }

    public class Area
    {
        public string id { get; set; }
        public string name { get; set; }
        public string[] iso31661codes { get; set; }
        public object typeid { get; set; }
        public string sortname { get; set; }
        public string disambiguation { get; set; }
        public object type { get; set; }
    }

    public class LifeSpan
    {
        public bool ended { get; set; }
        public string begin { get; set; }
        public object end { get; set; }
    }

    public class BeginArea
    {
        public string sortname { get; set; }
        public string disambiguation { get; set; }
        public object type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public object typeid { get; set; }
    }

    public class ReleaseGroups
    {
        public string title { get; set; }
        public string primarytypeid { get; set; }
        public string primarytype { get; set; }
        public string id { get; set; }
        public string[] secondarytypeids { get; set; }
        public string disambiguation { get; set; }
        public string[] secondarytypes { get; set; }
        public string firstreleasedate { get; set; }
    }

}
