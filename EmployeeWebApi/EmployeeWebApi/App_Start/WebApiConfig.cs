using EmployeeWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EmployeeWebApi.Data;
using Unity;
using Unity.Lifetime;

namespace EmployeeWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            //   config.Formatters.Remove(config.Formatters.XmlFormatter);

            var container = new UnityContainer();
            container.RegisterType<IEmployeeService, EmployeeService>(new HierarchicalLifetimeManager());
            container.RegisterInstance(new EmployeeDbContext());
            config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
