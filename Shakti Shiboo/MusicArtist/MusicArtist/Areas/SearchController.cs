using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Logics;
using BusinessLayer.Models.Dto;
using BusinessLayer.Models.ReturnTypes;
using Newtonsoft.Json;

namespace MusicArtist.Areas
{
    public class SearchController : Controller
    {
        private readonly IBusinessLogic _businessLogic;

        public SearchController()
        {
            _businessLogic = BusinessLogicFactory.Create();
        }

        // GET: Search
        [HttpGet]
        public JsonResult ArtistDetails(string searchcriteria, int? pagenumber, int? pagesize)
        {
            SearchArtistDto searchArtistDto = new SearchArtistDto() { 
                SearchCriteria = searchcriteria, 
                PageNumber = pagenumber, 
                PageSize = pagesize };
            
            var result = _businessLogic.GetArtists(searchArtistDto);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> GetRelease(Guid? id)
        {
            String artistName = _businessLogic.GetArtistNameById(id.Value);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://musicbrainz.org/ws/2/release/?query=release:{artistName}&fmt=json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

                HttpResponseMessage response = await client.GetAsync($"https://musicbrainz.org/ws/2/release/?query=release:{artistName}&fmt=json");
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();

                    MusicBrainzReturnType returnData = JsonConvert.DeserializeObject<MusicBrainzReturnType>(jsonData);
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
                return Json(new MusicBrainzReturnType(), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAlbums()
        {
            AlbumReturnType albums = new AlbumReturnType();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://musicbrainz.org/ws/2/release/?query=release:mumford%20&%20sons&fmt=json");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

                HttpResponseMessage response = await client.GetAsync($"https://musicbrainz.org/ws/2/release/?query=release:mumford%20&%20sons&fmt=json");
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();

                    MusicBrainzReturnType returnData = JsonConvert.DeserializeObject<MusicBrainzReturnType>(jsonData);

                    albums.MapFromApiData(returnData);
                }
                return Json(albums, JsonRequestBehavior.AllowGet);
            }
        }
    }
}