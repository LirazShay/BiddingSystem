using System.Net.Http;
using System.Web.Http;

namespace BiddingSystem.Specs.ApiClient
{
    public class ApiClientBase
    {
        protected MyRestClient RestClient { get; }

        public ApiClientBase(HttpServer server)
        {
            var httpClient = new HttpClient(server);
            RestClient = new MyRestClient(httpClient);
        }
    }
}