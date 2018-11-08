using System.Net.Http;
using System.Web.Http;

namespace BiddingSystem.Specs.ApiClient
{
    public static class MyRestClientFactory
    {
        public static MyRestClient CreateRestClient(HttpServer server)
        {
            return new MyRestClient(new HttpClient(server));
        }
    }
}