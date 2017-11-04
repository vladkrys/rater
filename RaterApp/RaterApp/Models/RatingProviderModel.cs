using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaterApp.Models
{
    public class RatingProviderModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal TrustScore { get; set; }
        public string ApiUrl { get; set; }
    }
}