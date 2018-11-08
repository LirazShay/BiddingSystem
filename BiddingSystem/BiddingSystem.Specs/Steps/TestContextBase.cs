namespace BiddingSystem.Specs.Steps
{
    public class TestContextBase : TechTalk.SpecFlow.Steps
    {
        protected T Resolve<T>()
        {
            return ScenarioContext.ScenarioContainer.Resolve<T>();
        }
    }
}