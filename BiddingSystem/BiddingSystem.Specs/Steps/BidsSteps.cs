using System.Linq;
using BiddingSystem.Entities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BiddingSystem.Specs.Steps
{
    public class BidsSteps : StepsBase
    {
        public BidsTestContext BidsTestContext => Resolve<BidsTestContext>();

        [When(@"I place a bid")]
        public void WhenIPlaceABid(Bid bid)
        {
            BidsTestContext.PlaceBidByApi(bid);
        }


        [When(@"I perform get all bids request")]
        public void WhenIPerformGetAllBidsRequest()
        {
            
        }


        [When(@"I send place bid request without bid")]
        public void WhenISendPlaceBidRequestWithoutBid()
        {
            BidsTestContext.PlaceBidByApi(null);
        }

        [Then(@"the bid list will be")]
        public void ThenTheBidListWillBe(Table table)
        {
            var allBids = BidsTestContext.GetAllBidsFromService();
            table.CompareToSet(allBids);
        }

    }
}