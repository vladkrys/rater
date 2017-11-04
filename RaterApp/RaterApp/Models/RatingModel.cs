using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaterApp.Models
{
    public class RatingModel
    {
        public int id { get; set; }
        public string MovieName { get; set; }
        public decimal Rating { get; set; }
        public DateTime BroadcastTime { get; set; }
        public string Channel { get; set; }
        public IList<ProviderScore> Providers { get; set; }
    }
}