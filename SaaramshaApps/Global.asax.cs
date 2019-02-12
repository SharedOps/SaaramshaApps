using Autofac;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;

namespace SaaramshaApps
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //Loading autofac module
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new SaaramshaApps.Autofac.DataModule());
            IContainer container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Set the dependency resolver for MVC.

            ContainerBuilder buildermvc = new ContainerBuilder();
            buildermvc.RegisterControllers(Assembly.GetExecutingAssembly());
            buildermvc.RegisterModule(new SaaramshaApps.Autofac.DataModule());
            IContainer mvccontainer = buildermvc.Build();

            var mvcResolver = new AutofacDependencyResolver(mvccontainer);
            DependencyResolver.SetResolver(mvcResolver);


            //Register helppage areas
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           

        }
    }
}
