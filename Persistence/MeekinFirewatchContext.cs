using Domain.Facebook;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class MeekinFirewatchContext : DbContext
  {
    public MeekinFirewatchContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Root> Roots {get; set;}
    public DbSet<Post> Posts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Medium> Media { get; set; }
    

  }
}