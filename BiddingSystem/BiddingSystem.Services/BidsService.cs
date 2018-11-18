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
            bids.Add(bid);
        }

        public static IList<Bid> GetAllBids()
        {
            return bids.AsReadOnly();
        }
    }
}