using System;

using DotNetNuke.Web.Api;

namespace DNNAwesomeService
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("DNNAwesomeService", "default", "{controller}/{action}", new[] { "DNNAwesomeService" });
        }
    }
}
