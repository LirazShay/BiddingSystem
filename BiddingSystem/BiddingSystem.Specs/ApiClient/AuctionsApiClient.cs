using System.Net.Http;
using System.Web.Http;
using BiddingSystem.Models;

namespace BiddingSystem.Specs.ApiClient
{
    public class AuctionsApiClient : ApiClientBase
    {
        public void CreateAuction(string auctionName)
        {
            Auction ac = new Auction() {AuctionName = auctionName};
            RestClient.SendRequest("/api/auctions", HttpMethod.Post, ac);
        }


        public AuctionsApiClient(HttpServer server) : base(server)
        {
        }
    }
}