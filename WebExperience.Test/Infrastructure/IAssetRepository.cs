using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeneralKnowledge.Test.App.Domain.Model;

namespace WebExperience.Test.Infrastructure
{
    public interface IAssetRepository 
    {
        Task<IEnumerable<Asset>> GetAssets();
        Task<Asset> GetByIdAsync(Guid Id);
        Task DeletedAsync(Guid id);
        Task UpdateAsync(Asset asset);
        Task CreateAsync(Asset asset);
    }
}



