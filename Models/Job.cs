using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace career_trender.Models
{
    public class Job
    {
        public Job()
        {
        }
        
        public string Query { get; set; }
        public string Location { get; set; }
        public bool DupeFilter { get; set; }
        public bool Highlight { get; set; }
    }
}
