namespace BiddingSystem.Entities
{
    public class Bid
    {
        public int? AuctionId { get; set; }

        public string Username { get; set; }

        public double? Price { get; set; }
    }
}