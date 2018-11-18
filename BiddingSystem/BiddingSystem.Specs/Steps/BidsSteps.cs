using System.Collections.Generic;
using System.Linq;
using BiddingSystem.Entities;
using BiddingSystem.Specs.ApiClient;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BiddingSystem.Specs.Steps
{
    public class BidsSteps : StepsBase
    {
        private IList<Bid> GetBidListFromLastResponse()
        {
            return Resolve<MyRestClient>().LastResponse.DeserializeTo<IList<Bid>>();
        }

        public BidsTestContext BidsTestContext => Resolve<BidsTestContext>();

        [When(@"I place a bid")]
        public void WhenIPlaceABid(Bid bid)
        {
            BidsTestContext.PlaceBidByApi(bid);
        }

        [When(@"I perform get all bids request")]
        public void WhenIPerformGetAllBidsRequest()
        {
            BidsTestContext.GetAllBidsByApi();
        }

        [Given(@"the following bids were offered")]
        public void GivenTheFollowingBidsWereOffered(IList<Bid> bids)
        {
            BidsTestContext.CreateBidsByService(bids);
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

        [Then(@"the response will be empty bids list")]
        public void ThenTheResponseWillBeEmptyBidsList()
        {
            var bidList = GetBidListFromLastResponse();
            Assert.AreEqual(0, bidList.Count);
        }

        [Then(@"the response will contain the bid list")]
        public void ThenTheResponseWillContainTheBidList(IList<Bid> expectedBids)
        {
           expectedBids.ToList().ForEach(a=>BidsTestContext.LinkBidToScenarioAuction(a));
           expectedBids.ShouldCompare(GetBidListFromLastResponse());
        }


    }
}