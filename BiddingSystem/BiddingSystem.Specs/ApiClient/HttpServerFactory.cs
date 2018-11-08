using System.Web.Http;

namespace BiddingSystem.Specs.ApiClient
{
    public class HttpServerFactory
    {
        /// <summary>
        /// Start in-memory hosting server
        /// </summary>
        /// <returns>HttpServer instance</returns>
        public static HttpServer StartServer()
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiApplication.Configure(config);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            var server = new HttpServer(config);
            return server;
        }
    }
}
