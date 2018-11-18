using System;
using System.Linq;
using NUnit.Framework;
using BiddingSystem.Entities;
using KellermanSoftware.CompareNetObjects;

namespace BiddingSystem.Services.Tests
{
    [TestFixture]
    public class BidsServiceTests
    {
        [Test]
        public void PlaceBid_WithValidUsernameAndPrice_WillBeSaved()
        {
            var newBid = new Bid()
            {
                Price = 10,
                Username = "Vadim"
            };

            BidsService.PlaceBid(newBid);

            var bids = BidsService.GetAllBids();
            var actualBid = bids.First();
            actualBid.ShouldCompare(newBid);
        }

        [Test]
        public void PlaceBid_WithNullBid_WillThrowException()
        {
            TestDelegate act = 
                () => BidsService.PlaceBid(null);

            var ex = Assert.Throws<ArgumentNullException>(act); 

            StringAssert.Contains("Bid can't be null",ex.Message);
        }

    }
}