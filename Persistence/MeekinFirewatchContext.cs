using System.Collections.Generic;
using Domain;
using Domain.Facebook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

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
    public DbSet<PostLabeling> PostLabelings { get; set; }

  }
}