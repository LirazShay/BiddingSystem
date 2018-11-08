using System;
using BiddingSystem.Specs.ApiClient;
using BoDi;
using TechTalk.SpecFlow;

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