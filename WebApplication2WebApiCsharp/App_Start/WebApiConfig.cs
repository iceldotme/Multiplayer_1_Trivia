using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication2WebApiCsharp
{
    public static class WebApiConfig 
    {
        public static void Register(HttpConfiguration config) {

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "2",
                routeTemplate: "api/{controller}/action/{action}/{info}",
                defaults: new { info = RouteParameter.Optional }
            );

        }
    }
}
