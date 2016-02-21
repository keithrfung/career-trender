using System.Collections.Generic;
using career_trender.Models;
using System.Net.Http;
using System.Text;

namespace career_trender.Classes
{
    public class GitJobSearch
    {
        /// <summary>
        /// Searches Indeed.
        /// </summary>
        /// <param name="parameters">The search query parameters.</param>
        /// <returns>The Git job search results.</returns>
        public List<GitJobSearchResult> GetSearchResults(GitJobQueryParameters parameters)
        {
            string url = "https://jobs.github.com/positions.json?description=python&location=sf&full_time=true";

            StringBuilder sb = new StringBuilder();
            sb.Append("https://jobs.github.com/positions.json?");
            sb.Append(string.Format("description={0}", parameters.Description));
            sb.Append(string.Format("&location={0}", parameters.Location));
            sb.Append(string.Format("&full_time={0}", parameters.FullTime.ToString()));
            
            url = sb.ToString();

            var client = new HttpClient();
            
            var response = client.GetAsync(url);
            var posts = response.Result.Content.ReadAsAsync<List<GitJobSearchResult>>();

            //This shit is aweful and I feel aweful. 
            //Seriously, I hate myself so much right now...
            foreach (var post in posts.Result)
            {
                post.Description = HtmlRemoval.StripTagsCharArray(post.Description);
            }            
            
            var results = posts.Result;
                        
            return results;
        }
    }
}
