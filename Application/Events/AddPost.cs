using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Persistence;
using RestSharp;
using RestSharp.Serialization.Json;
using JsonSerializer = RestSharp.Serialization.Json.JsonSerializer;

namespace Application.Events
{
    public class AddPost
    {
        public class Command : IRequest
        {
            public string Id {
                get;
                set;
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly string _fbApiKey;
            private readonly string _instaApiKey;
            private readonly string _redditApiKey;
            private string baseUrl = "https://api.crowdtangle.com/";
            private string postsUrl = "posts?token=";
            private string count = "&count=20";

            public Handler(MeekinFirewatchContext context, IConfiguration config)
            {
                _context = context;
                _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
                _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
                _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;

            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // specific post ID segment of URL
                var onePost = string.Format("post/{0}?token=", request.Id);
            
                string[] idTokens = request.Id.Split('_');
                var number1 = Int64.Parse(idTokens[0]);
                var number2 = Int64.Parse(idTokens[1]);

                IRestClient client = new RestClient();
                Uri getUri = new Uri(baseUrl + onePost + _fbApiKey);
                IRestRequest restRequest = new RestRequest(getUri);
                restRequest.AddHeader("Accept", "application/json");
                var cancellationTokenSource = new CancellationTokenSource();


                var response = await client.ExecuteAsync<Root>(restRequest, cancellationTokenSource.Token);
                // if error, print stack trace
                if (!response.IsSuccessful) Console.WriteLine("Stack Trace: " + response.ErrorException);
                var data = response.Data;

                // add the index 0 of the List ot the database (only one item in List)
                _context.Posts.Add(data.Result.Posts[0]);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}