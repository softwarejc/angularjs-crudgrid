using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Items.Web.App_Start
{
    public static class JsonFormatter
    {
        public static void Configure()
        {
            // JSON camel casing
            var jsonFormatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Include;
        }
    }
}