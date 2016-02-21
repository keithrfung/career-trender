using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace career_trender.Models
{
    public class JobResult
    {
        public JobResult()
        {
        }
        
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FormattedLocation { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int JobKey { get; set; }
        public bool Sponsored { get; set; }
        public bool Expired { get; set; }
    }
}
