using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dependency;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnsureInitialized();

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );

            config.DependencyResolver = new DependencyRegistr.UnityResolver(DependencyRegistr.RegisterComponents());
        }
    }
}
