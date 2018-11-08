using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BiddingSystem.Models;

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