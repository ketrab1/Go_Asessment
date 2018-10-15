using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Infrastructure
{
    public class AssetDbContext : DbContext
    {
        public AssetDbContext()
        {
        }

        private DbSet<GeneralKnowledge.Test.App.Asset.Domain.Model.Asset> Assets { get; set; }
    }
}