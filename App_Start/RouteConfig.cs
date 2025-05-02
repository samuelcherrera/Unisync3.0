using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Unisync
{
    public class RouteConfig

    {

        public static void RegisterRoutes(RouteCollection routes)

        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ruta predeterminada redirige al HTML

            routes.MapPageRoute(

                "InicioHtml",

                "",

                "~/HtmlViews/inicio.html"

            );

        }

    }


}
