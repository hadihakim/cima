using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cima
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
            "Movies",
            "CinemaList/{str}",
            new { controller = "Movies", action = "CinemaList" },
            new { str = @"\w+" });*/



            routes.MapRoute(
    "Movies",
    "Movies/CinemaList/{myString}",
    new { controller = "Movies", action = "CinemaList", myString = UrlParameter.Optional });








            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
