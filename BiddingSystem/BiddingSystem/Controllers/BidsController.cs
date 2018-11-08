using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BiddingSystem.Models;

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
            return Ok();
        }
    }
}
