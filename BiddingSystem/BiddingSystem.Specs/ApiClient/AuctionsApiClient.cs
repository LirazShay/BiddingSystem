using System.Net.Http;
using BiddingSystem.Entities;
using Newtonsoft.Json;

namespace BiddingSystem.Specs.ApiClient
{
    public class AuctionsApiClient : ApiClientBase
    {
        public AuctionsApiClient(MyRestClient restClient) : base(restClient)
        {
        }

        public Auction CreateAuction(string auctionName)
        {
            Auction ac = new Auction() {AuctionName = auctionName};
            return RestClient
                .SendRequest("/api/auctions", HttpMethod.Post, ac)
                .DeserializeTo<Auction>();
        }
    }
}