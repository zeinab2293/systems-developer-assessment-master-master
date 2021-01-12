using System.Web.Mvc;
using System.Web.Routing;

namespace NetC.JuniorDeveloperExam.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "BlogPost", action = "Index", id = "1"}  // Parameter defaults
            );
        }
        //protected void Application_Start()
        //{
        //    RegisterRoutes(RouteTable.Routes);
        //}
    }
}
