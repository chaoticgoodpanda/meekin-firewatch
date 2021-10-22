using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using Microsoft.Extensions.Configuration;

namespace API.Crowdtangle
{
    
    public class CrowdtangleApi<T>
    {
        private readonly MeekinFirewatchContext _context;
        private static string _fbApiKey;
        private readonly string _instaApiKey;
        private readonly string _redditApiKey;
        
        public CrowdtangleApi(MeekinFirewatchContext context, IConfiguration config)
        {
            _context = context;
            _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
            _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
            _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;

        }
        private const string baseUrl = "https://api.crowdtangle.com/";
        private string urlParameters = "posts?";

        public static async Task<T> Get(string url)
        {
            url = baseUrl + url;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Key", _fbApiKey);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await client.GetAsync(string.Format(url)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objectJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonSerializer.Deserialize<T>(objectJsonString);

                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return default(T);
            }

        }
        
    }
}