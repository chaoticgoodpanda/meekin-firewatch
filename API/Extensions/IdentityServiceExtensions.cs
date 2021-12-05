using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }
    }
}