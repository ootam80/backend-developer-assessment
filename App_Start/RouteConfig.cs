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

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //artist/search/<search_criteria>/<page_number>/<page_size>
            routes.MapRoute(
                name: "search",
                url: "artist/search/{searchcriteria}/{pagenumber}/{pagesize}",
                defaults: new { area = "artist", controller = "artist", action = "search", searchcriteria = UrlParameter.Optional, pagenumber = UrlParameter.Optional, pagesize = UrlParameter.Optional }
            );
        }
    }
}
