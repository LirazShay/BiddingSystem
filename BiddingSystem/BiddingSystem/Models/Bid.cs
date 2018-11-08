using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiddingSystem.Models
{
    public class Bid
    {
        public string Username { get; set; }

        public double? Price { get; set; }
    }
}