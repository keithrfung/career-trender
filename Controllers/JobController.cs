using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using career_trender.Models;
using career_trender.Classes;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace career_trender.Controllers
{
    [Route("api/[controller]")]
    public class JobController : Controller
    {
        // GET: api/job
        [HttpGet]
        public IEnumerable<IndeedSearchResult> Get()
        {
            IndeedSearch query = new IndeedSearch();
            IndeedQueryParameters parameters = new IndeedQueryParameters();
            
            parameters.JobQuery = "java";
            parameters.Location = "aberdeen%2C+md";
            parameters.SearchRadius = "";
            parameters.Country = "us";
            parameters.UserIP = "1.2.3.4";
            parameters.UserAgent = "Mozilla/%2F4.0%28Firefox%29";
            
            
            return query.GetSearchResults(parameters);
        }
        
        private IEnumerable<JobResult> GetJunkData()
        {
            var results = new List<JobResult>();
                        
            results.Add(new JobResult 
            {
                JobKey = 1,
                JobTitle = "Software Developer",
                Company = "Atlus, LLC",
                City = "Aberdeen",
                State = "MD",
                Country = "USA",
                FormattedLocation = "Aberdeen, MD",
                Source = "N/A",
                Date = DateTime.Now,
                Description = "Altus, LLC is searching for a full-time C++ software developer to support on-going programs at the U.S. Army Research Laboratory (ARL) at Aberdeen Proving Ground, Maryland. The software developer will engage with the team to provide support for modeling and simulation                tools and high performance computing (HPC) resources. Job Requirements: - Expertise with the C++ programming language - Work experience as a programmer/coder - U.S. citizenship - Capability to obtain security clearance - Demonstrated capability to work effectively                    in a dynamic team environment. Additional capabilities desired include experience with the Qt application development framework and strong statistical analysis experience, specifically in the R system for statistical computing, data analysis, and graphics. Salary is                  dependent on candidate strengths in terms of education, work experience, and demonstrated skills. Altus provides an attractive employee benefits package. Altus Engineering is a small business founded in 2003 to deliver engineering services to the U.S. Department of                   Defense. For additional information on Altus please see our web site: http://www.altus-engineering.com/."                
            });
            
            results.Add(new JobResult 
            {
                JobKey = 2,
                JobTitle = "Software Engineer",
                Company = "Atlus, LLC",
                City = "Aberdeen",
                State = "MD",
                Country = "USA",
                FormattedLocation = "Aberdeen, MD",
                Source = "N/A",
                Date = DateTime.Now,
                Description = "Altus, LLC is searching for a full-time C++ software developer to support on-going programs at the U.S. Army Research Laboratory (ARL) at Aberdeen Proving Ground, Maryland. The software developer will engage with the team to provide support for modeling and simulation                tools and high performance computing (HPC) resources. Job Requirements: - Expertise with the C++ programming language - Work experience as a programmer/coder - U.S. citizenship - Capability to obtain security clearance - Demonstrated capability to work effectively                    in a dynamic team environment. Additional capabilities desired include experience with the Qt application development framework and strong statistical analysis experience, specifically in the R system for statistical computing, data analysis, and graphics. Salary is                  dependent on candidate strengths in terms of education, work experience, and demonstrated skills. Altus provides an attractive employee benefits package. Altus Engineering is a small business founded in 2003 to deliver engineering services to the U.S. Department of                   Defense. For additional information on Altus please see our web site: http://www.altus-engineering.com/."                
            });
                        
            return results; 
        }

        // GET api/job/5
        [HttpGet("{id}")]
        public IndeedSearchResult Get(int id)
        {
            return Get().FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
