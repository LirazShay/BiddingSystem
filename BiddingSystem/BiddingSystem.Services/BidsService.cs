using BiddingSystem.Entities;
using System;
using System.Collections.Generic;

namespace BiddingSystem.Services
{
    public class BidsService
    {
        static List<Bid> bids = new List<Bid>();

        public static void PlaceBid(Bid bid)
        {
            if (bid == null) throw new ArgumentNullException(nameof(bid));
            bids.Add(bid);
        }

        public static IList<Bid> GetAllBids()
        {
            return bids.AsReadOnly();
        }
    }
}