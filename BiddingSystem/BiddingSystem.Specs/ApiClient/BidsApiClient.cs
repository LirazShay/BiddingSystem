using System.Collections.Generic;
using System.Net.Http;
using BiddingSystem.Entities;

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

        public IList<Bid> GetAllBids(int auctionId)
        {
            return RestClient
                .SendRequest($"/api/auctions/{auctionId}/bids", HttpMethod.Get)
                .DeserializeTo<IList<Bid>>();
        }
    }
}