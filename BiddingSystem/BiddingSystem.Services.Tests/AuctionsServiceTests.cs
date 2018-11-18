using NUnit.Framework;
using BiddingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingSystem.Entities;

namespace BiddingSystem.Services.Tests
{
    [TestFixture]
    public class AuctionsServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            AuctionsService.ClearAllAuctions();
        }

        [TearDown]
        public void TearDown()
        {
            AuctionsService.ClearAllAuctions();
        }

        [Test]
        public void AddNewAuction_WhenValidName_WillBeSaved()
        {
            var auctionToAdd = new Auction()
            {
                AuctionName = "Test-Auction"
            };

            AuctionsService.AddNewAuction(auctionToAdd);

            var allAuctions = AuctionsService.GetAllAuctions();
            CollectionAssert.Contains(allAuctions, auctionToAdd);
        }

        [Test]
        public void AddNewAuction_WhenEmptyName_WillThrowException()
        {
            var auctionToAdd = new Auction()
            {
                AuctionName = ""
            };

            var ex = Assert.Throws<ArgumentException>(() => AuctionsService.AddNewAuction(auctionToAdd));

            StringAssert.Contains("AuctionName can't be empty", ex.Message);
        }

        [Test]
        public void AddNewAuction_WhenAddingValidAuction_WillSaveWithNewId()
        {
            var auctionToAdd = new Auction() { AuctionName = "Auction1" };

            AuctionsService.AddNewAuction(auctionToAdd);

            var addedAuction = AuctionsService.GetAllAuctions().Single();
            Assert.AreEqual(1, addedAuction.Id);
        }

        [Test]
        public void AddNewAuction_WhenAddingSecondAuction_WillSaveWithNewIdIncreasedBy1()
        {
            var auctionToAdd = new Auction() { AuctionName = "Auction1" };
            AuctionsService.AddNewAuction(auctionToAdd);
            var secondAuctionToAdd = new Auction() { AuctionName = "Auction2" };

            AuctionsService.AddNewAuction(secondAuctionToAdd);

            var lastAddedAuction = AuctionsService.GetAllAuctions().Last(a => a.AuctionName == "Auction2");
            Assert.AreEqual(2, lastAddedAuction.Id);
        }

        [Test()]
        public void ClearAllAuctions_Always_WillDeleteAllAuctions()
        {
            var auctionToAdd = new Auction() { AuctionName = "Auction1" };
            AuctionsService.AddNewAuction(auctionToAdd);

            AuctionsService.ClearAllAuctions();

            CollectionAssert.IsEmpty(AuctionsService.GetAllAuctions());
        }
    }
}