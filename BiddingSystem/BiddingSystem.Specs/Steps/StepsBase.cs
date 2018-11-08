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
    }
}