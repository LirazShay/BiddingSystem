using System.Net.Http;
using BiddingSystem.Entities;
namespace BiddingSystem.Specs.ApiClient
{
    public class AuctionsApiClient : ApiClientBase
    {
        public AuctionsApiClient(MyRestClient restClient) : base(restClient)
        {
        }

        public void CreateAuction(string auctionName)
        {
            Auction ac = new Auction() {AuctionName = auctionName};
            RestClient.SendRequest("/api/auctions", HttpMethod.Post, ac);
        }
    }
}