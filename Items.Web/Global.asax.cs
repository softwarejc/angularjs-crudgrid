using System.Web.Http;
using Items.Web.App_Start;

namespace Items.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Web Api Routing
            GlobalConfiguration.Configure(WebApiConfig.Register);
          
            // Json formatter
            JsonFormatter.Configure();
           
            // Simple injector
            App_Start.SimpleInjector.Initialize();
        }
    }
}
