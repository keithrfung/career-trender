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
        public IEnumerable<GitJobSearchResult> Get()
        {
            GitJobSearch query = new GitJobSearch();
            GitJobQueryParameters parameters = new GitJobQueryParameters();
            
            parameters.JobQuery = "java";
            parameters.Location = "aberdeen%2C+md";
            parameters.SearchRadius = "";
            parameters.Country = "us";
            parameters.UserIP = "1.2.3.4";
            parameters.UserAgent = "Mozilla/%2F4.0%28Firefox%29";
            parameters.Limit = "10";
            
            return query.GetSearchResults(parameters);
        }
        
        // GET api/job/5
        [HttpGet("{id}")]
        public GitJobSearchResult Get(int id)
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
