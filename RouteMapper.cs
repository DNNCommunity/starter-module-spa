using DotNetNuke.Web.Api;

namespace starter_module_spa
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                "starter-module-spa",
                "default",
                "{controller}/{action}",
                new string[] { "starter_module_spa.Controllers" });
        }
    }
}