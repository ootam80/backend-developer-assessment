using BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.ReturnTypes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class OtherArtist
    {
        public string id { get; set; }
        public string name { get; set; }

        public void MapFromApiData(ArtistCredit artistCredit)
        {
            this.id = artistCredit.artist.id;
            this.name = artistCredit.artist.name;
        }
    }

    public class AlbumRelease
    {
        public string releaseId { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string label { get; set; }
        public int numberOfTracks { get; set; }
        public List<OtherArtist> otherArtists { get; set; }
    }

    public class AlbumReturnType
    {
        public AlbumReturnType() {
            releases = new List<AlbumRelease>();
        }

        public List<AlbumRelease> releases { get; set; }

        public void MapFromApiData(MusicBrainzReturnType apiData)
        {
            List<Release> albums = apiData.releases.Where(r => r.releasegroup.primarytypeid == ReleaseTypes.Album).OrderBy(release => release.date).Take(10).ToList();

            albums.ForEach(album => {
                AlbumRelease albumRelease = new AlbumRelease();

                albumRelease.title = album.title;
                albumRelease.numberOfTracks = album.trackcount;
                albumRelease.status = album.status;
                albumRelease.releaseId = album.id;
                albumRelease.otherArtists = new List<OtherArtist>();

                album.artistcredit.ForEach(artistcredit => {
                    OtherArtist otherArtist = new OtherArtist();
                    otherArtist.MapFromApiData(artistcredit);
                    albumRelease.otherArtists.Add(otherArtist);
                });

                if (album.labelinfo != null && album.labelinfo.Count > 0)
                {
                    albumRelease.label = string.Join(",", album.labelinfo.Select(l => l.label.name));
                }
                else
                {
                    albumRelease.label = "";
                }

                releases.Add(albumRelease);
            });
        }
    }
}
