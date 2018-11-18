using System.Collections.Generic;
using BiddingSystem.Entities;
using BiddingSystem.Services;
using BiddingSystem.Specs.ApiClient;

namespace BiddingSystem.Specs.Steps
{
    public class BidsTestContext : TestContextBase
    {
        private BidsApiClient BidsApi => Resolve<BidsApiClient>();

        public void PlaceBid(Bid bid)
        {
            BidsApi.PlaceBid(bid);
        }

        public IList<Bid> GetAllBids()
        {
            return BidsService.GetAllBids();
        }
    }
}