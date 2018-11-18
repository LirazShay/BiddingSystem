using TechTalk.SpecFlow;

namespace BiddingSystem.Specs.Steps
{
    [Binding]
    public sealed class AuctionsSteps : StepsBase
    {
        private AuctionsTestContext TestContext => Resolve<AuctionsTestContext>();

        [Given(@"there is an open auction")]
        public void GivenThereIsAnOpenAuction()
        {
            TestContext.CreateAuction("DemoAction");
        }
    }
}