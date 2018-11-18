using BiddingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiddingSystem.Services
{
    public class BidsService
    {
        static List<Bid> bids = new List<Bid>();

        public static void PlaceBid(Bid bid)
        {
            if (bid == null) throw new ArgumentNullException(nameof(bid));
            if (string.IsNullOrWhiteSpace(bid.Username)) throw new ArgumentException(nameof(bid.Username) + " can't be null");
            if (bid.Price == null) throw new ArgumentException(nameof(bid.Price) + " can't be null");
            if (bid.Price <= 0) throw new ArgumentException("Invalid price, price should be greater than 0");
            if (!bid.AuctionId.HasValue) throw new ArgumentException(nameof(bid.AuctionId) + " can't be null");
            bids.Add(bid);
        }

        public static IList<Bid> GetAllBids(int auctionId)
        {
            return bids.Where(a => a.AuctionId == auctionId).ToList().AsReadOnly();
        }

        public static void ClearAllBids()
        {
            bids.Clear();
        }
    }
}