using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.ReturnTypes
{
    public class Area
    {
        public string id { get; set; }
        public string name { get; set; }

        [JsonProperty("sort-name")]
        public string sortname { get; set; }

        [JsonProperty("iso-3166-1-codes")]
        public List<string> iso31661codes { get; set; }
    }

    public class Artist
    {
        public string id { get; set; }
        public string name { get; set; }

        [JsonProperty("sort-name")]
        public string sortname { get; set; }
    }

    public class ArtistCredit
    {
        public string name { get; set; }
        public Artist artist { get; set; }
    }

    public class Label
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class LabelInfo
    {
        [JsonProperty("catalog-number")]
        public string catalognumber { get; set; }
        public Label label { get; set; }
    }

    public class Medium
    {
        public string format { get; set; }

        [JsonProperty("disc-count")]
        public int disccount { get; set; }

        [JsonProperty("track-count")]
        public int trackcount { get; set; }
    }

    public class Release
    {
        public string id { get; set; }
        public int score { get; set; }

        [JsonProperty("status-id")]
        public string statusid { get; set; }

        [JsonProperty("packaging-id")]
        public string packagingid { get; set; }
        public int count { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string packaging { get; set; }

        [JsonProperty("text-representation")]
        public TextRepresentation textrepresentation { get; set; }

        [JsonProperty("artist-credit")]
        public List<ArtistCredit> artistcredit { get; set; }

        [JsonProperty("release-group")]
        public ReleaseGroup releasegroup { get; set; }
        public string date { get; set; }
        public string country { get; set; }

        [JsonProperty("release-events")]
        public List<ReleaseEvent> releaseevents { get; set; }
        public string barcode { get; set; }

        [JsonProperty("label-info")]
        public List<LabelInfo> labelinfo { get; set; }

        [JsonProperty("track-count")]
        public int trackcount { get; set; }
        public List<Medium> media { get; set; }
    }

    public class ReleaseEvent
    {
        public string date { get; set; }
        public Area area { get; set; }
    }

    public class ReleaseGroup
    {
        public string id { get; set; }

        [JsonProperty("type-id")]
        public string typeid { get; set; }

        [JsonProperty("primary-type-id")]
        public string primarytypeid { get; set; }
        public string title { get; set; }

        [JsonProperty("primary-type")]
        public string primarytype { get; set; }
    }

    public class MusicBrainzReturnType
    {
        public DateTime created { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public List<Release> releases { get; set; }
    }

    public class TextRepresentation
    {
        public string language { get; set; }
        public string script { get; set; }
    }


}
