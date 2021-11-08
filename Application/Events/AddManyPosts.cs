using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Facebook;
using MediatR;
using Microsoft.Extensions.Configuration;
using Persistence;
using RestSharp;

namespace Application.Events
{
    public class AddManyPosts
    {
        public class Command : IRequest
        {
            
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private readonly MeekinFirewatchContext _context;
            private readonly string _fbApiKey;
            private readonly string _instaApiKey;
            private readonly string _redditApiKey;
            private string baseUrl = "https://api.crowdtangle.com/";
            private string postsUrl = "posts?token=";
            private string count = "&count=10";

            public Handler(MeekinFirewatchContext context, IConfiguration config)
            {
                _context = context;
                _fbApiKey = config.GetSection("CrowdtangleSettings:FacebookApiKey").Value;
                _instaApiKey = config.GetSection("CrowdtangleSettings:InstagramApiKey").Value;
                _redditApiKey = config.GetSection("CrowdtangleSettings:RedditApiKey").Value;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // create a new RestSharp HttpClient
                IRestClient client = new RestClient();
                Uri getUri = new Uri(baseUrl + postsUrl + _fbApiKey + count);
                IRestRequest restRequest = new RestRequest(getUri);
                // cancellation RestSharp token for async requests
                var cancellationTokenSource = new CancellationTokenSource();
                restRequest.AddHeader("Accept", "application/json");
            
                var response =  await client.ExecuteAsync<Root>(restRequest, cancellationTokenSource.Token);

                // if error, print stack trace
                if (!response.IsSuccessful) Console.WriteLine("Stack Trace: " + response.ErrorException);
                var data = response.Data;

                
                _context.Roots.Add(data);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}