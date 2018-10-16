using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GeneralKnowledge.Test.App.Domain.Model;

namespace WebExperience.Test.Infrastructure
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AssetDbContext _dbContext;

        public AssetRepository(AssetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            var data = await _dbContext.Assets.ToListAsync();
            foreach (var asset in data)
            {
                _dbContext.Entry(asset).Reference(x => x.Country).Load();
                _dbContext.Entry(asset).Reference(x => x.MimeType).Load();
            }

            return data;
        }

        public async Task<Asset> GetByIdAsync(Guid id)
        {
           var data = await _dbContext.Assets.Where(x => x.AssetId == id)
                .FirstOrDefaultAsync<Asset>();
            _dbContext.Entry(data).Reference(x => x.Country).Load();
            _dbContext.Entry(data).Reference(x => x.MimeType).Load();

            return data;
        }

        public async Task DeletedAsync(Guid id)
        {
            var data = await _dbContext.Assets.Where(x => x.AssetId == id)
                .FirstOrDefaultAsync<Asset>();
            _dbContext.Entry(data).Reference(x => x.Country).Load();
            _dbContext.Entry(data).Reference(x => x.MimeType).Load();
            if (data != null)
                _dbContext.Assets.Remove(data);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Asset asset)
        {
           
            var data = await _dbContext.Assets.Include(x => x.Country).Include(x => x.MimeType).FirstOrDefaultAsync(x => x.AssetId == asset.AssetId);
            if (data != null)
            {
              _dbContext.Entry(data).CurrentValues.SetValues(asset);

              var countriesToUpdate = await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == data.Country.Id);
              _dbContext.Entry(countriesToUpdate).Entity.Name = asset.Country.Name;

              var miemTypeToUpdate = await _dbContext.MieMimeTypes.FirstOrDefaultAsync(x => x.Id == data.MimeType.Id);
              _dbContext.Entry(miemTypeToUpdate).Entity.Type = asset.MimeType.Type;

      }
                
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(Asset asset)
        {
    
            _dbContext.Assets.Add(asset);
            _dbContext.SaveChanges();
        }
    }
}
