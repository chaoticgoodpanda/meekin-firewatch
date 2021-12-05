using System.Collections.Generic;
using Domain;
using Domain.Facebook;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Persistence
{
  public class MeekinFirewatchContext : IdentityDbContext<User>
  {
    public MeekinFirewatchContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Root> Roots {get; set;}
    public DbSet<Post> Posts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Medium> Media { get; set; }
    public DbSet<PostLabeling> PostLabelings { get; set; }

    // overrides the OnModelCreating method to add new roles
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<IdentityRole>()
        .HasData(
          new IdentityRole { Name = "Member", NormalizedName = "MEMBER" },
          new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
        );
    }

  }
}