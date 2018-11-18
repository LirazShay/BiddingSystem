using System.Web.Http;
using BiddingSystem.Entities;
using BiddingSystem.Services;

namespace BiddingSystem.Controllers
{
    public class BidsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PlaceBid(Bid bid)
        {
            if (bid == null)
                return BadRequest("Bid cannot be empty!");
            if (!bid.Price.HasValue)
                return BadRequest("Price cannot be empty!");
            if (string.IsNullOrEmpty(bid.Username))
                return BadRequest("Username cannot be empty!");
            if (bid.Price <= 0)
                return BadRequest("Price must be greater than 0");

            BidsService.PlaceBid(bid);

            return Ok();
        }

        [Route("api/auctions/{auctionId}/bids")]
        [HttpGet]
        public IHttpActionResult GetAllBids(int auctionId)
        {
            var allBids = BidsService.GetAllBids(auctionId);
            return Ok(allBids);
        }
    }
}