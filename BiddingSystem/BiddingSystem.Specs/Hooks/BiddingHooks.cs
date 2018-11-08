using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiddingSystem.Specs.ApiClient;
using BiddingSystem.Specs.Steps;
using TechTalk.SpecFlow;

namespace BiddingSystem.Specs.Hooks
{
    [Binding]
    public sealed class BiddingHooks : StepsBase
    {
        [BeforeScenario]
        public void BeforeScenarioStartServer()
        {
            var server = HttpServerFactory.StartServer();
            ScenarioContext.ScenarioContainer.RegisterInstanceAs(server,dispose:true);
        }
    }
}