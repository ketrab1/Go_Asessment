using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GeneralKnowledge.Test.App.Domain.Model;

namespace WebExperience.Test.Infrastructure
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext()
        {
          
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MimeType> MieMimeTypes { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Asset>()
                .HasRequired(a => a.Country)
                .WithRequiredPrincipal(x => x.Asset);
            modelBuilder.Entity<Asset>()
                .HasRequired(a => a.MimeType)
                .WithRequiredPrincipal(x => x.Asset);

        }
    }

  internal sealed class DataContextConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<AssetDbContext>
  {
    public DataContextConfiguration()
    {
      AutomaticMigrationsEnabled = true;

    }
  }
}
