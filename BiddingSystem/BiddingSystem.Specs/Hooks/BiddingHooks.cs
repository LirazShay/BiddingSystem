using BiddingSystem.Specs.ApiClient;
using BiddingSystem.Specs.Steps;
using TechTalk.SpecFlow;

namespace BiddingSystem.Specs.Hooks
{
    [Binding]
    public sealed class BiddingHooks : StepsBase
    {
        [BeforeScenario]
        public void InitializeServerBeforeScenario()
        {
            var server = HttpServerFactory.StartServer();
            var restClient = MyRestClientFactory.CreateRestClient(server);
            ScenarioContext.ScenarioContainer.RegisterInstanceAs(server,dispose:true);
            ScenarioContext.ScenarioContainer.RegisterInstanceAs(restClient, dispose: true);
        }
    }
}