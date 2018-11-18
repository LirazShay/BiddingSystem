using System.Collections.Generic;
using BiddingSystem.Entities;

namespace BiddingSystem.Services
{
    public class AuctionsService
    {
        private static readonly List<Auction> Auctions = new List<Auction>();

        public static Auction AddNewAuction(Auction auction)
        {
            lock (Auctions)
            {
                Auctions.Add(auction);
                auction.Id = Auctions.Count;
                return auction;
            }
        }
    }
}