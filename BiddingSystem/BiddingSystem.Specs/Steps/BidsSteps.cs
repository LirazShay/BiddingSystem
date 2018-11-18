﻿using BiddingSystem.Entities;
using TechTalk.SpecFlow;

namespace BiddingSystem.Specs.Steps
{
    public class BidsSteps : StepsBase
    {
        public BidsTestContext BidsTestContext => Resolve<BidsTestContext>();

        [When(@"I place a bid")]
        public void WhenIPlaceABid(Bid bid)
        {
            BidsTestContext.PlaceBid(bid);
        }

        [When(@"I send place bid request without bid")]
        public void WhenISendPlaceBidRequestWithoutBid()
        {
            BidsTestContext.PlaceBid(null);
        }

        [Then(@"the bid list will be")]
        public void ThenTheBidListWillBe(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}