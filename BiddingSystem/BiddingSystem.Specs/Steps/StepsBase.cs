using System.Linq;
using TechTalk.SpecFlow;

namespace BiddingSystem.Specs.Steps
{
    [Binding]
    public abstract class StepsBase : TechTalk.SpecFlow.Steps
    {
        protected T Resolve<T>()
        {
            return ScenarioContext.ScenarioContainer.Resolve<T>();
        }

        public bool IsScenarioHasTag(string tag)
        {
            return ScenarioContext.ScenarioInfo.Tags.Any(a => a == tag)
                   || FeatureContext.FeatureInfo.Tags.Any(a => a == tag);
        }
    }
}