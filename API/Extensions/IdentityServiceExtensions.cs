using System.Text;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            // adding identity roles
            // creates about six DB tables just from adding this code (users, roles, etc.)
            services.AddIdentityCore<User>(opt =>
                {
                    // require unique emails in DB
                    opt.User.RequireUniqueEmail = true;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MeekinFirewatchContext>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        // issuer of our token is our API right now (https://localhost:5001)
                        ValidateIssuer = false,
                        // audience is address of our client on localhost
                        ValidateAudience = false,
                        // true b/c we've given token expiry date and want API to reject post-expiry
                        ValidateLifetime = true,
                        // check secret key of our token matches server-side signature
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(config["JWTSettings:TokenKey"]))
                    };
                });
            services.AddAuthorization();
            // token service is scoped to HttpRequest -- once request is gone, service is disposed of
            services.AddScoped<TokenService>();

            return services;
        }
    }
}