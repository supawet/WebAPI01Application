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
            // Configure Web API to use only bearer token authentication.  
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // NAV route
            config.Routes.MapHttpRoute(
                name: "FundPF",
                routeTemplate: "api/FundPF/{id}",
                defaults: new { controller = "FundPF", id = RouteParameter.Optional }//,
                //constraints: new { id="length(2)"}
            );

            config.Routes.MapHttpRoute(
                name: "FundPFTest",
                routeTemplate: "api/FundPFTest/{id}",
                defaults: new { controller = "FundPFTest", id = RouteParameter.Optional }//,
                //constraints: new { id="length(2)"}
            );

            // fund fact sheet, monthly update route
            config.Routes.MapHttpRoute(
                name: "Book",
                routeTemplate: "api/Book/{id}/{action}",
                //routeTemplate: "api/Book/{id}/{action}/{subaction}",
                defaults: new { controller = "Book", id = RouteParameter.Optional }//,
                //defaults: new { controller = "Book", id = RouteParameter.Optional, subaction = RouteParameter.Optional }//,
                //constraints: new { id="length(2)"}
            );

            config.Routes.MapHttpRoute(
                name: "ODD",
                routeTemplate: "api/ODD/{id}/{action}/{subaction}",
                defaults: new { controller = "ODD", id = RouteParameter.Optional, subaction = RouteParameter.Optional }//,
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
