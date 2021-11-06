using Domain.Facebook;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class MeekinFirewatchContext : DbContext
  {
    public MeekinFirewatchContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Post> Posts {get; set;}
    // public DbSet<PostLabeling> PostLabels {get; set;}

  }
}