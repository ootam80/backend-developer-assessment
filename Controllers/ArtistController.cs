using BusinessLayer.Model;
using BusinessLayer.Model.ReturnTypes;
using DataLayer;
using DataLayer.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicArtist.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistRepository _artistRepository;
        private IAliasRepository _aliasRepository;
        public ArtistController()
        {
            _artistRepository = new ArtistRepository(new MusicBrainzEntities());
            _aliasRepository = new AliasRepository(new MusicBrainzEntities());
        }
        public ArtistController(IArtistRepository artistRepository, IAliasRepository aliasRepository)
        {
            _artistRepository = artistRepository;
            _aliasRepository = aliasRepository;
        }

        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Search(string searchcriteria, int? pageNumber = 1, int? pageSize = 10)
        {
            SearchResultReturnType searchResultReturnType = new SearchResultReturnType();
            searchResultReturnType.Results = new List<ArtistDetailsReturnType>();
            List<Artist> matchingArtistList = new List<Artist>();
            List<Artist> artistListWithMatchedAlias = new List<Artist>();
            try
            {
                using (MusicBrainzEntities db = new MusicBrainzEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;

                    matchingArtistList = db.Artists
                                           .Where(ar => ar.ArtistName.ToLower().Contains(searchcriteria.ToLower()))
                                           .ToList();
                    artistListWithMatchedAlias = db.Aliases
                                                   .Include("Artist")
                                                   .Where(al => al.AliasDescription.ToLower().Contains(searchcriteria.ToLower()))
                                                   .Select(al => al.Artist)
                                                   .ToList();
                    matchingArtistList.AddRange(artistListWithMatchedAlias);
                    matchingArtistList = matchingArtistList.GroupBy(a => a.ArtistId)
                                                           .Select(g => g.First())
                                                           .ToList();

                    matchingArtistList = matchingArtistList.Skip(pageSize.Value * (pageNumber.Value - 1)).Take(pageSize.Value).ToList();
                    searchResultReturnType.Page = pageNumber.Value;
                    searchResultReturnType.PageSize = pageSize.Value;
                    searchResultReturnType.NumberOfPages = matchingArtistList.Count / pageSize.Value;
                    searchResultReturnType.NumberOfSearchResults = matchingArtistList.Count;

                    foreach (var artist in matchingArtistList)
                    {
                        ArtistDetailsReturnType artistDetailsReturnType = new ArtistDetailsReturnType();
                        artistDetailsReturnType.Name = artist.ArtistName;
                        artistDetailsReturnType.Country = artist.Country;
                        artistDetailsReturnType.Alias = db.Aliases.Where(a => a.ArtistId == artist.ArtistId).Select(a => a.AliasDescription).ToList();
                        artistDetailsReturnType.AlbumsLink = await FetchReleaseGroups(artist.UniqueIdentifier);
                        searchResultReturnType.Results.Add(artistDetailsReturnType);
                    }
                    return Json(searchResultReturnType, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        /// <summary>
        /// returns a collection of links to an Artist's Albums, given the Artist's identifier
        /// </summary>
        /// <param name="uniqueIdentifier"></param>
        /// <returns></returns>
        public async Task<List<string>> FetchReleaseGroups(string uniqueIdentifier)
        {
            List<string> albumsLink = new List<string>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri($"http://musicbrainz.org/ws/2/artist/{uniqueIdentifier}?inc=release-groups&fmt=json");
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

                    HttpResponseMessage response = await client.GetAsync($"http://musicbrainz.org/ws/2/artist/{uniqueIdentifier}?inc=release-groups&fmt=json");
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        // from the json received, specifically deserialize only the release-groups (albums)
                        var jObject = JObject.Parse(jsonData);
                        var jToken = jObject.GetValue("release-groups"); 
                        ReleaseGroups[] releasegroups = (ReleaseGroups[])jToken.ToObject(typeof(ReleaseGroups[]));

                        foreach (var item in releasegroups)
                        {
                            albumsLink.Add("https://musicbrainz.org/release-group/" + item.id);
                        }
                    }

                    return albumsLink;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}