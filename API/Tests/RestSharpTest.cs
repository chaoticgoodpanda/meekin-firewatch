using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace API.Tests
{
    [TestClass]
    public class RestSharpTest
    {
        private string _fbApiKey = "KHfpY8pNGbJeov4JdALnuSBOU9mvFWscnZItoutX";
        private string baseUrl = "https://api.crowdtangle.com/";
        private string postsUrl = "posts?token=";


        

        [TestMethod]
        public void TestUsingRestSharp()
        {
            // create a new restClient
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(baseUrl + postsUrl + _fbApiKey);
            restRequest.AddHeader("Accept", "application/json");
            // store the response
            IRestResponse restResponse = restClient.Get(restRequest);
            Console.WriteLine(restResponse.IsSuccessful);
            Console.WriteLine(restResponse.StatusCode);
            Console.WriteLine(restResponse.ErrorMessage);
            Console.WriteLine(restResponse.ErrorException);
            
            // extracting the content from the response
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine(restResponse.Content);
            }
        }
        
    }
}