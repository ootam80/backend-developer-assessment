using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicArtist
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            ///artist/search/<search_criteria>/<page_number>/<page_size>
            routes.MapRoute(
                name: "search",
                url: "artist/search/{searchcriteria}/{pagenumber}/{pagesize}",
                defaults: new { area = "artist", controller = "search", action = "ArtistDetails", searchcriteria = UrlParameter.Optional, pagenumber = UrlParameter.Optional, pagesize = UrlParameter.Optional }
            );

            ///artist/<artist_id>/releases
            routes.MapRoute(
                name: "releases",
                url: "artist/{id}/releases",
                defaults: new { area = "artist", controller = "search", action = "GetRelease", id = UrlParameter.Optional }
            );

            ///artist/6c44e9c22-ef82-4a77-9bcd-af6c958446d6/albums
            routes.MapRoute(
                name: "albums",
                url: "artist/6c44e9c22-ef82-4a77-9bcd-af6c958446d6/albums",
                defaults: new { area = "artist", controller = "search", action = "GetAlbums" }
            );

            //Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
