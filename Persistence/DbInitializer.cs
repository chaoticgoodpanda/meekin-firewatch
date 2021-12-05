using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Facebook;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    // with a static class, don't need to create new instance of the class
    public static class DbInitializer
    {
        public static async Task Initialize(MeekinFirewatchContext context, UserManager<User> userManager)
        {
          // check to see if any users in DB
          if (!userManager.Users.Any())
          {
              var users = new List<User>
              {
                  new User
                  {
                      DisplayName = "Maung Maung", UserName = "maung", Email = "maung@test.com",
                      Organization = "Koe Koe Tech"
                  },
                  new User
                  {
                      DisplayName = "Desi UNDP", UserName = "desi", Email = "desi@test.com", Organization = "UNDP"
                  },
                  new User
                  {
                      DisplayName = "Lilli FHI360", UserName = "lilli", Email = "lilli@test.com",
                      Organization = "FHI360"
                  }

              };

              foreach (var user in users)
              {
                  // generate user and user password
                  await userManager.CreateAsync(user, "Pa$$w0rd");
                  // user will have a "Member" role
                  await userManager.AddToRoleAsync(user, "Member");
              }
              
              // create sample admin
              var admin = new User
              {
                  UserName = "admin",
                  Email = "admin@test.com"
              };

              // generate admin user and admin password
              await userManager.CreateAsync(admin, "Pa$$w0rd");
              // admin will have multiple roles: "Member" role and "Admin" role
              await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});

          };
        
        }
    }
}