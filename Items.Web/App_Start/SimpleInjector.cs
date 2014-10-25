using System.Web.Http;
using Items.Business.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Items.Web.App_Start
{
    public static class SimpleInjector
    {
        public static void Initialize()
        {
            // 1. Create container
            var container = new Container();

            // 2. Register types
            container.Register<IItemsService, ItemsService>();

            // 3. Verity container (throw an exception if some required types cannot be resolved)
            container.Verify();

            // 4. Configure WebApi dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}