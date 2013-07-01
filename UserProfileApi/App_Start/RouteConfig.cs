﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UserProfileApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Authentication",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}