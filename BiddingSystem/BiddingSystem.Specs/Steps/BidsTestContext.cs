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

        public void PlaceBidByApi(Bid bid)
        {
            if (bid != null && !bid.AuctionId.HasValue)
                bid.AuctionId = LastAuctionId;
            BidsApi.PlaceBid(bid);
        }

        public IList<Bid> GetAllBidsFromService()
        {
            return BidsService.GetAllBids(LastAuctionId);
        }
    }
}