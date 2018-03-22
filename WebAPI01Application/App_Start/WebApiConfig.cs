using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI01Application
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // NAV route
            config.Routes.MapHttpRoute(
                name: "FundPF",
                routeTemplate: "api/FundPF/{id}",
                defaults: new { controller = "FundPF", id = RouteParameter.Optional }//,
                //constraints: new { id="length(2)"}
            );
            /*
            // Default route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */
        }
    }
}
