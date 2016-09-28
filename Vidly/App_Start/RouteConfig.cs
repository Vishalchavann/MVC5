using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            #region CUstom Route Example.
            //routes.MapRoute(
            //       "movieByReleseDate",
            //       "Movies/relesed/{year}/{Month}",
            //       new { Controller = "Movies", action = "ByRelesedDate" },
            //       new { year = @"2015| 2016", month = @"\d{2}" }
            //       );

            #endregion
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
