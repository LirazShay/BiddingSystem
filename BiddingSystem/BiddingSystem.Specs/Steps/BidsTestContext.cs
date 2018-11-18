using System.Collections.Generic;
using BiddingSystem.Entities;
using BiddingSystem.Services;
using BiddingSystem.Specs.ApiClient;

namespace BiddingSystem.Specs.Steps
{
    public class BidsTestContext : TestContextBase
    {
        private BidsApiClient BidsApi => Resolve<BidsApiClient>();

        public int LastAuctionId => Resolve<AuctionsTestContext>().LastAuction.Id;

        public void PlaceBid(Bid bid)
        {
            if (!bid.AuctionId.HasValue)
                bid.AuctionId = LastAuctionId;
            BidsApi.PlaceBid(bid);
        }

        public IList<Bid> GetAllBids()
        {
            return BidsService.GetAllBids(LastAuctionId);
        }
    }
}