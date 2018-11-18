using BiddingSystem.Entities;
using BiddingSystem.Specs.ApiClient;

namespace BiddingSystem.Specs.Steps
{
    public class AuctionsTestContext : TestContextBase
    {
        private AuctionsApiClient apiClient => Resolve<AuctionsApiClient>();
        public Auction LastAuction { get; private set; }

        public void CreateAuction(string auctionName)
        {
            LastAuction = apiClient.CreateAuction(auctionName);
        }
    }
}