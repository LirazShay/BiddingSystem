using System.Net.Http;
using System.Web.Http;
using BiddingSystem.Models;

namespace BiddingSystem.Specs.ApiClient
{
    public class BidsApiClient : ApiClientBase
    {
        public BidsApiClient(MyRestClient restClient) : base(restClient)
        {
        }

        public void PlaceBid(Bid bid)
        {
            RestClient.SendRequest("/api/bids", HttpMethod.Post, bid);
        }
    }
}