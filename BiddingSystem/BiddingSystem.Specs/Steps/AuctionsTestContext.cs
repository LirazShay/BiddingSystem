using BiddingSystem.Entities;
using BiddingSystem.Specs.ApiClient;

namespace BiddingSystem.Specs.Steps
{
    public class AuctionsTestContext : TestContextBase
    {
        private AuctionsApiClient ApiClient => Resolve<AuctionsApiClient>();
        public Auction LastAuction { get; private set; }

        public void CreateAuction(string auctionName)
        {
            LastAuction = ApiClient.CreateAuction(auctionName);
        }
    }
}