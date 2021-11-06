using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using RestResponse = API.Helpers.RestResponse;

namespace API.Tests
{
    [TestClass]
    public class ApiUnitTest
    {
        private string _fbApiKey = "KHfpY8pNGbJeov4JdALnuSBOU9mvFWscnZItoutX";
        private string _instaApiKey;

        private string _redditApiKey;
        // public ApiUnitTest(IConfiguration config)
        // {
        //     _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
        //     _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
        //     _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;
        // }

        // runs first before every test
        [TestInitialize]
        public void Setup()
        {

        }
        
        private string baseUrl = "https://api.crowdtangle.com/";
        private string postsUrl = "posts?token=";
        [TestMethod]
        [Ignore]
        public void CrowdtangleGetPostsEndpointTest()
        {
            
            // creating a new httpClient
            HttpClient httpClient = new HttpClient();
            // access the endpoint
            var result = httpClient.GetAsync(baseUrl + postsUrl + _fbApiKey);
            Console.Write(result);
            // close the connection
            httpClient.Dispose();
        }

        [TestMethod]
        [Ignore]
        public void TestGetAllEndPointsWithUri()
        {
            
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(baseUrl + postsUrl + _fbApiKey);
            httpClient.GetAsync(getUri);
            // capture the response from the message
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            // return the response
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            // get the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            // print the status code -- will print "OK" if it is 200
            Console.WriteLine("Status Code: " + statusCode);
            // if want the "200", cast to integer
            Console.WriteLine("Status Code: " + (int)statusCode);
            httpClient.Dispose();
        }
        
        // tests for invalid status code return
        [TestMethod]
        public void TestGetAllEndPointsWithUnauthorizedUrl()
        {
            
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(baseUrl + postsUrl + "akld;fjadl;kfjadls;fj");
            httpClient.GetAsync(getUri);
            // capture the response from the message
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            // return the response
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            // get the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            // print the status code -- will print "OK" if it is 200
            Console.WriteLine("Status Code: " + statusCode);
            // if want the "200", cast to integer
            Console.WriteLine("Status Code: " + (int)statusCode);
            httpClient.Dispose();
        }
        
        [TestMethod]
        [Ignore]
        public void TestGetAllEndPointsWithUriContent()
        {
            
            HttpClient httpClient = new HttpClient();
            Uri getUri = new Uri(baseUrl + postsUrl + _fbApiKey);
            httpClient.GetAsync(getUri);
            // capture the response from the message
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            // return the response
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            // get the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            // print the status code -- will print "OK" if it is 200
            Console.WriteLine("Status Code: " + statusCode);
            // if want the "200", cast to integer
            Console.WriteLine("Status Code: " + (int)statusCode);
            
            // response data
            HttpContent response = httpResponseMessage.Content;
            Task<string> responseData = response.ReadAsStringAsync();
            string data = responseData.Result;
            // print the response data
            Console.WriteLine(data);
            httpClient.Dispose();
        }
        
        // get the response in Json format
        [TestMethod]
        public void TestGetAllEndPointsWithUriContentInJsonFormat()
        {
            
            HttpClient httpClient = new HttpClient();
            
            // set up the request to return json for the default request headers
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            
            Uri getUri = new Uri(baseUrl + postsUrl + _fbApiKey);
            httpClient.GetAsync(getUri);
            // capture the response from the message
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            // return the response
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            // get the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;

            // response data
            HttpContent response = httpResponseMessage.Content;
            Task<string> responseData = response.ReadAsStringAsync();
            string data = responseData.Result;
            // print the response data
            Console.WriteLine(data);
            
            //call helper function
            RestResponse restResponse = new RestResponse((int)statusCode, responseData.Result);
            // Console.WriteLine(restResponse.ToString());
            var jsonObject = JsonConvert.DeserializeObject<Post>(restResponse.ResponseContent);
            
            Console.WriteLine(jsonObject.ToString());
            
            // assertion test that 200 code is returned
            Assert.AreEqual(200, restResponse.StatusCode);
            // assert there's data in the response
            Assert.IsNotNull(restResponse.ResponseContent);
            // conditional asserts
            // Assert.IsTrue(jsonObject.AccountType.Contains("facebook_page"));
            
            httpClient.Dispose();
        }
        
                // get the response in Json format
        [TestMethod]
        public async Task TestSpecificPostIdEndpoint()
        {
            string id = "155869377766434_6112776065409039";
            // specific post ID segment of URL
            var onePost = string.Format("post/{0}?token=", id);
            
            string[] idTokens = id.Split('_');
            var number1 = Int64.Parse(idTokens[0]);
            var number2 = Int64.Parse(idTokens[1]);

            IRestClient client = new RestClient();
            Uri getUri = new Uri(baseUrl + onePost + _fbApiKey);
            IRestRequest request = new RestRequest(getUri);
            request.AddHeader("Accept", "application/json");
            var cancellationTokenSource = new CancellationTokenSource();
            // request.AddUrlSegment("id", number1 + "_" + number2);

            var response = await client.ExecuteAsync<Root>(request, cancellationTokenSource.Token);

            // if error, print stack trace
            if (!response.IsSuccessful) Console.WriteLine("Stack Trace: " + response.ErrorException); 
            
            // assertion test that 200 code is returned
            Assert.IsTrue(response.IsSuccessful);

            Console.WriteLine(response.Data);


        }

        // test sending a message to endpoint
        [TestMethod]
        [Ignore]
        public void TestGetEndpointUsingSendAsync()
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(baseUrl + postsUrl + _fbApiKey);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Uri getUri = new Uri(baseUrl + postsUrl + _fbApiKey);
            httpClient.GetAsync(getUri);
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            // get the status code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            // print the status code -- will print "OK" if it is 200
            Console.WriteLine("Status Code: " + statusCode);
            // if want the "200", cast to integer
            Console.WriteLine("Status Code: " + (int)statusCode);
            
            // response data
            HttpContent response = httpResponseMessage.Content;
            Task<string> responseData = response.ReadAsStringAsync();
            string data = responseData.Result;
            // print the response data
            Console.WriteLine(data);
            httpClient.Dispose();
        }
        
        // runs last
        [TestCleanup]
        public void TearDown()
        {
            Console.WriteLine("This is Cleanup");
        }

        // test class methods need static
        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            Console.WriteLine("Class Setup");
        }

        [ClassCleanup]
        public static void ClassTearDown()
        {
            Console.WriteLine("Class Cleanup");
        }

        [AssemblyInitialize]
        public static void AssemblySetup(TestContext testContext)
        {
            Console.WriteLine("Assembly Setup");
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            Console.WriteLine("Assembly Cleanup");
        }
    }
}
