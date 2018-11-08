using BiddingSystem.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BiddingSystem.Specs.Steps
{
    [Binding]
    public sealed class StepArgsTransformation
    {
        [StepArgumentTransformation]
        public Bid TableToBid(Table table) => table.CreateInstance<Bid>();
    }
}