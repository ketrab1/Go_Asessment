using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset.Domain.Model.Asset.Domain;

namespace Asset.Domain.Model.Asset.Infrastructure
{
    public class AssetRepository : IAssetRepository
    {
        public Task CreateAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task DeletedAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Domain.Asset> GetAssets()
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
