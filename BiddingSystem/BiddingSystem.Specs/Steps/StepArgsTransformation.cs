using System.Collections.Generic;
using System.Linq;
using BiddingSystem.Entities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BiddingSystem.Specs.Steps
{
    [Binding]
    public sealed class StepArgsTransformation
    {
        [StepArgumentTransformation]
        public Bid TableToBid(Table table) => table.CreateInstance<Bid>();

        [StepArgumentTransformation]
        public IList<Bid> TableToBidList(Table table) => table.CreateSet<Bid>().ToList();
    }
}