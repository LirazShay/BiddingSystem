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
    public sealed class GeneralHooks: StepsBase
    {
        [BeforeScenario("ErrorStatusCode")]
        public void BeforeScenario()
        {
            Resolve<MyRestClient>().IgnoreErrors = true;
        }
   
    }
}
