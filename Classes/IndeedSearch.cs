using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using career_trender.Models;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.IO;

namespace career_trender.Classes
{
    public class IndeedSearch
    {
        /// <summary>
            /// Searches Indeed.
            /// </summary>
            /// <param name="parameters">The search query parameters.</param>
            /// <param name="apiPublisherKey">Your Indeed API key.</param>
            /// <returns>The Indeed job search results.</returns>
            public static List<IndeedSearchResult> GetSearchResults(IndeedQueryParameters parameters, string apiPublisherKey)
            {
                Contract.Requires(null != apiPublisherKey);
                Contract.Requires("" != apiPublisherKey.Trim());

                string requestUrl = "http://api.indeed.com/ads/apisearch" +
                                                String.Format("?publisher={0}", apiPublisherKey) +
                                                String.Format("&q={0}", parameters.JobQuery) +
                                                String.Format("&l={0}", parameters.Location) +
                                                String.Format("&sort={0}", parameters.Sort) +
                                                String.Format("&radius={0}", parameters.SearchRadius) +
                                                String.Format("&st={0}", parameters.St) +
                                                String.Format("&jt={0}", parameters.Jt) +
                                                String.Format("&start={0}", parameters.Start) +
                                                String.Format("&limit={0}", parameters.Limit) +
                                                String.Format("&fromage={0}", parameters.FromAge) +
                                                String.Format("&filter={0}", parameters.Filter) +
                                                String.Format("&latlong={0}", parameters.LatitudeLongitude) +
                                                String.Format("&co={0}", parameters.Country) +
                                                String.Format("&chnl={0}", parameters.Channel) +
                                                String.Format("&userip={0}", parameters.UserIP) +
                                                String.Format("&useragent={0}", parameters.UserAgent) +
                                                "&v=2";
                                                
                        
                Uri url = new Uri(requestUrl);
                
                string xml = string.Empty;
                
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync(url).Result;
                                
                var responseStream = response.Content.ReadAsStreamAsync();
                                
                using (var streamReader = new StreamReader(responseStream.Result))
                {
                    xml = streamReader.ReadToEnd();
                }
                            
                XDocument docu = XDocument.Parse(xml);            
                XElement rootE = docu.Document.Root;
                
                var query = from i in rootE.Element("results").Elements("result")
                            select i;
                
                var results = new List<IndeedSearchResult>();
                
                foreach (XElement node in query)
                {
                    IndeedSearchResult result = new IndeedSearchResult();
                    result.JobTitle = (string)node.Element("jobtitle");
                    result.Company = (string)node.Element("company");
                    result.City = (string)node.Element("city");
                    result.State = (string)node.Element("state");
                    result.Country = (string)node.Element("country");
                    result.FormattedLocationFull = (string)node.Element("formattedLocation");
                    result.Source = (string)node.Element("source");
                    result.Date = (string)node.Element("date");
                    result.Snippet = (string)node.Element("snippet");
                    result.URL = (string)node.Element("url");
                    result.OnMouseDown = (string)node.Element("onmousedown");
                    result.Latitude = (string)node.Element("latitude");
                    result.JobKey = (string)node.Element("jobkey");
                    result.Sponsored = (string)node.Element("sponsored");
                    result.Expired = (string)node.Element("expired");
                    result.FormattedLocationFull = (string)node.Element("formattedLocationFull");
                    result.FormattedRelativeTime = (string)node.Element("formattedRelativeTime");

                    results.Add(result);
                }                

                return results;
            }

            /// <summary>
            /// Returns the Indeed job search results based on the specified query parameters.
            /// This overload uses the project's properties file to supply Indeed with the Publisher Number/API key.
            /// </summary>
            /// <param name="parameters">Indeed search parameters.</param>
            /// <returns>The Indeed job search results.</returns>
            public List<IndeedSearchResult> GetSearchResults(IndeedQueryParameters parameters)
            {
                return GetSearchResults(parameters, "1686088457887041");
            }
    }
}
