using System;
using API.Dropbox;
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

        private string _dropboxApiKey =
            "sl.A7A3ZVp5l2ubNqZXAuZ3Bm3nhKEW94ysL__zs84nY43HGDdvt50_u8vNg9yZv-UkzmN9aj5AtHa9DI0UEuw_fZkLQaif-eGFk2XAZiZA4kCwVUXCFj3h6RvXnFbXP_mjVD_blRK3Jws";
        private string dropboxUrl = "https://api.dropboxapi.com/2/files/list_folder";

        private string dropboxBody =
            "{\"path\": \"\",\"recursive\": false,\"include_media_info\": false,\"include_deleted\": false,\"include_has_explicit_shared_members\": false,\"include_mounted_folders\": true,\"include_non_downloadable_files\": true}";
            



        [TestMethod]
        [Ignore]
        public void DropboxApiTest()
        {
            // create a new restClient
            IRestClient client = new RestClient();
            IRestRequest request = new RestRequest()
            {
                Resource = dropboxUrl
            };
            // based on dropbox API docs this is how token should be added to request
            // https://www.dropbox.com/developers/documentation/http/documentation#files-list_folder
            request.AddHeader("Authorization", "Bearer " + _dropboxApiKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(dropboxBody);
            
            //post request
            var response = client.Post<Root>(request);
            Assert.AreEqual(200, (int)response.StatusCode);

            var data = response.Data;
            Console.Write(data.Entries[4].Name);

        }

    }
}