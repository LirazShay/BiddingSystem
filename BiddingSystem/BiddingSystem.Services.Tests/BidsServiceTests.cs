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
        [SetUp]
        public void SetUp()
        {
            BidsService.ClearAllBids();
        }

        [TearDown]
        public void TearDown()
        {
            BidsService.ClearAllBids();
        }

        [TestCase(0.01, "M")]
        [TestCase(10,"Rami")]
        public void PlaceBid_WithValidUsernameAndPrice_WillBeSaved(double price,string username)
        {
            var newBid = new Bid()
            {
                Price = price,
                Username = username,
                AuctionId = 1
            };

            BidsService.PlaceBid(newBid);

            var bids = BidsService.GetAllBids(1);
            var actualBid = bids.First();
            actualBid.ShouldCompare(newBid);
        }

        [Test]
        public void PlaceBid_UpdatePrice_WillUpdateTheLastBid()
        {
            var firstBid = new Bid() {AuctionId = 1, Price = 10, Username = "TestUsername"};
            BidsService.PlaceBid(firstBid);

            var secondBid = new Bid() { AuctionId = 1, Price = 12, Username = "TestUsername" };
            BidsService.PlaceBid(secondBid);

            var allBids = BidsService.GetAllBids(1);
            Assert.AreEqual(1,allBids.Count);
            allBids[0].ShouldCompare(secondBid);
        }


        [Test]
        public void PlaceBid_WithNullBid_WillThrowException()
        {
            TestDelegate act = 
                () => BidsService.PlaceBid(null);

            var ex = Assert.Throws<ArgumentNullException>(act); 

            StringAssert.Contains("Value cannot be null.\r\nParameter name: bid",ex.Message);
        }

        [Test]
        public void PlaceBid_WithoutPrice_WillThrowException()
        {
            Bid bid = new Bid() {Username = "Rami"};

            TestDelegate act = () => BidsService.PlaceBid(bid);

            var ex = Assert.Throws<ArgumentException>(act);
            StringAssert.Contains("Price can't be null", ex.Message);
        }

        [Test]
        public void PlaceBid_WithoutUsername_WillThrowException()
        {
            Bid bid = new Bid() { Price = 10 };

            TestDelegate act = () => BidsService.PlaceBid(bid);

            var ex = Assert.Throws<ArgumentException>(act);
            StringAssert.Contains("Username can't be null", ex.Message);
        }

        [TestCase(" ")]
        [TestCase("")]
        public void PlaceBid_WithInvalidUsername_WillThrowException(string username)
        {
            Bid bid = new Bid() { Price = 10,Username = username};

            TestDelegate act = () => BidsService.PlaceBid(bid);

            var ex = Assert.Throws<ArgumentException>(act);
            StringAssert.Contains("Username can't be null", ex.Message);
        }


        [TestCase(-0.01)]
        [TestCase(-1)]
        [TestCase(0)]
        public void PlaceBid_WithInvalidPrice_WillThrowException(double price)
        {
            Bid bid = new Bid() { Username = "Rami", Price = price};

            TestDelegate act = () => BidsService.PlaceBid(bid);

            var ex = Assert.Throws<ArgumentException>(act);
            StringAssert.Contains("Invalid price, price should be greater than 0", ex.Message);
        }

    }
}