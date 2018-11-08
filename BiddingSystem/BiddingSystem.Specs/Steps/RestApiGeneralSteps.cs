using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BiddingSystem.Specs.ApiClient;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BiddingSystem.Specs.Steps
{
    public class RestApiGeneralSteps : StepsBase
    {
        private MyRestClient RestClient => Resolve<MyRestClient>();

        [Then(@"I will get an error ""(.*)""")]
        public void ThenIWillGetAnError(string error)
        {
            var lastResponse = RestClient.LastResponse;
            Assert.IsNotNull(lastResponse);
            Assert.IsFalse(lastResponse.IsSuccessStatusCode);
            StringAssert.Contains(error,lastResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
