﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
             "",
             new
             {
                 controller = "Jeans",
                 action = "Index",
                 category = (string)null,
                 page = 1
             }
             );

            routes.MapRoute(null,
            "Page{page}",
            new { controller = "Jeans", action = "Index", color = (string)null },
            new { page = @"\d+" }
            );

            routes.MapRoute(null,
            "{color}",
            new { controller = "Jeans", action = "Index", page = 1 }
            );

            routes.MapRoute(null,
            "{color}/Page{page}",
            new { controller = "Jeans", action = "Index" },
            new { page = @"\d+" }
            );

             routes.MapRoute(null, "{controller}/{action}");

            //#region MyRegion
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(null,
            //"",
            //new
            //{
            //    controller = "Product",
            //    action = "List",
            //    category = (string)null,
            //    page = 1
            //}
            //);
            //routes.MapRoute(null,
            //"Page{page}",
            //new { controller = "Product", action = "List", category = (string)null },
            //new { page = @"\d+" }
            //);
            //routes.MapRoute(null,
            //"{category}",
            //new { controller = "Product", action = "List", page = 1 }
            //);
            //routes.MapRoute(null,
            //"{category}/Page{page}",
            //new { controller = "Product", action = "List" },
            //new { page = @"\d+" }
            //);
            //routes.MapRoute(null, "{controller}/{action}");
            //#endregion


        }
    }
}
