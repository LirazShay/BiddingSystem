using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingSystem.Models;
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

    }
}