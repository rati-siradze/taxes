using System.Data.Entity;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Taxes.Data;
using Taxes.Engine;
using Unity;
using Unity.Lifetime;

namespace Taxes.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            var container = new UnityContainer();

            container.RegisterType<DbContext, TaxesContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ITaxWorker, Worker>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
