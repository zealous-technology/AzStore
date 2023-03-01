using System.Web.Mvc;
using System.Web.Routing;

namespace AzStore.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{name}",
                defaults: new { controller = "Product", action = "Search", name = UrlParameter.Optional }
            );
        }        
    }
}