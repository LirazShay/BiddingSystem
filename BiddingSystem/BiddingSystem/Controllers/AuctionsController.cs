using System.Web.Http;
using BiddingSystem.Entities;
using BiddingSystem.Services;

namespace BiddingSystem.Controllers
{
    public class AuctionsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddAuction(Auction auction)
        {
            auction = AuctionsService.AddNewAuction(auction);
            return Ok(auction);
        }
    }
}