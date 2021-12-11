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
    //to query the joined table directly
    public DbSet<ReportReporter> ReportReporters { get; set; }
    public DbSet<PostFollower> PostFollowers { get; set; }

    // overrides the OnModelCreating method to add new roles
    // as well as override the joined DbSets
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<IdentityRole>()
        .HasData(
          new IdentityRole { Name = "Member", NormalizedName = "MEMBER" },
          new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
        );
      
      // forms the primary key in table
      builder.Entity<ReportReporter>(x => x.HasKey(aa => new { aa.UserId, aa.ReportId }));

      builder.Entity<ReportReporter>()
        .HasOne(u => u.User)
        .WithMany(a => a.Reports)
        .HasForeignKey(aa => aa.UserId);
      
      // other side of the relationship
      builder.Entity<ReportReporter>()
        .HasOne(u => u.Report)
        .WithMany(a => a.Reporters)
        .HasForeignKey(aa => aa.ReportId);

      builder.Entity<PostFollower>(x => x.HasKey(aa => new { aa.UserId, aa.PostId }));

      builder.Entity<PostFollower>()
        .HasOne(u => u.User)
        .WithMany(a => a.Posts)
        .HasForeignKey(aa => aa.UserId);

      builder.Entity<PostFollower>()
        .HasOne(u => u.Post)
        .WithMany(a => a.PostFollowers)
        .HasForeignKey(aa => aa.PostId);
    }
    
    

  }
}