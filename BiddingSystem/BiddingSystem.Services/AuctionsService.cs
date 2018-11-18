using System;
using System.Collections;
using System.Collections.Generic;
using BiddingSystem.Entities;

namespace BiddingSystem.Services
{
    public class AuctionsService
    {
        private static readonly List<Auction> Auctions = new List<Auction>();

        public static Auction AddNewAuction(Auction auction)
        {
            if(string.IsNullOrWhiteSpace(auction.AuctionName))
                throw new ArgumentException($"{nameof(auction.AuctionName)} can't be empty");
            lock (Auctions)
            {
                Auctions.Add(auction);
                auction.Id = Auctions.Count;
                return auction;
            }
        }

        public static IList<Auction> GetAllAuctions()
        {
            return Auctions.AsReadOnly();
        }

        public static void ClearAllAuctions()
        {
            Auctions.Clear();
        }
    }
}