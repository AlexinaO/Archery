using System.Web.Mvc;
using System.Web.Routing;

namespace Archery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "DetailsRoute",
                //url: "Tournoi-{nom}/{id}",

                url: "Tournoi-{nom}",
                defaults: new { controller = "Home", action = "Details", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name:"SubscribeTournamentRoute",
                url:"Tournoi-{nom}",
            defaults: new {controller="Archers", action="SubscribeTournament", id=UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "AboutRoute",
                url: "a-propos",
                defaults: new { controller = "Home", action = "About" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}