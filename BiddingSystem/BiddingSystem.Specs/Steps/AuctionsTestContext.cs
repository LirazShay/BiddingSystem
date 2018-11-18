using BiddingSystem.Specs.ApiClient;

namespace BiddingSystem.Specs.Steps
{
    public class AuctionsTestContext : TestContextBase
    {
        private AuctionsApiClient apiClient => Resolve<AuctionsApiClient>();

        public void CreateAuction(string auctionName)
        {
            apiClient.CreateAuction(auctionName);
        }
    }
}