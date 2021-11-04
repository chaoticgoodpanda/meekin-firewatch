using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class MeekinFirewatchContext : DbContext
  {
    public MeekinFirewatchContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Facebook.Post> Posts {get; set;}
    // public DbSet<PostLabeling> PostLabels {get; set;}
    
    public DbSet<Vault> Vaults { get; set; }
    
    // we'll have a need to query individual Vault items
    public DbSet<VaultItem> VaultItems { get; set; }
  }
}