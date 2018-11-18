using System.Collections.Generic;
using BiddingSystem.Entities;
using BiddingSystem.Services;
using BiddingSystem.Specs.ApiClient;

namespace BiddingSystem.Specs.Steps
{
    public class BidsTestContext : TestContextBase
    {
        private BidsApiClient BidsApi => Resolve<BidsApiClient>();

        public void LinkBidToScenarioAuction(Bid bid)
        {
            if (bid != null && !bid.AuctionId.HasValue)
                bid.AuctionId = LastAuctionId;
        }

        public int LastAuctionId => Resolve<AuctionsTestContext>().LastAuction.Id;

        public void PlaceBidByApi(Bid bid)
        {
            LinkBidToScenarioAuction(bid);
            BidsApi.PlaceBid(bid);
        }

        public IList<Bid> GetAllBidsFromService()
        {
            return BidsService.GetAllBids(LastAuctionId);
        }

        public IList<Bid> GetAllBidsByApi()
        {
            return BidsApi.GetAllBids(LastAuctionId);
        }

        public void CreateBidsByService(IList<Bid> bids)
        {
            foreach (var bid in bids)
            {
                LinkBidToScenarioAuction(bid);
                BidsService.PlaceBid(bid);
            }
        }
    }
}