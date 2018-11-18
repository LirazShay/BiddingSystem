using System.Web.Http;
using BiddingSystem.Entities;

namespace BiddingSystem.Controllers
{
    public class AuctionsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddAuction(Auction auction)
        {
            return Ok();
        }
    }
}