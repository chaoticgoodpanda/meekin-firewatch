using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Facebook;
using Microsoft.EntityFrameworkCore;

namespace API.Data
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