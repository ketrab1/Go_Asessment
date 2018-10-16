using System;
using System.Threading.Tasks;
using System.Linq;

namespace Asset.Domain.Model.Asset.Infrastructure
{
    public interface IAssetRepository : IRepository<Domain.Asset>
    {
        IQueryable<Domain.Asset> GetAssets();
        Task GetByIdAsync(Guid Id);
        Task DeletedAsync(Guid Id);
        Task UpdateAsync(Guid Id);
        Task CreateAsync(Guid Id);
    }
}

