using Pyrite.Content.Core;
using System.Threading.Tasks;

namespace Pyrite.Content.Abstractions.Interfaces.Repositories
{
    public interface IResourceRepository
    {
        Task CreateAsync(Resource resource);

        Task<Resource> GetAsync
        (
            string identifier,
            bool includeBody
        );

        Task<bool> ExistsAsync(string identifier);

        Task UpdateAsync(Resource resource);

        Task DeleteAsync(string identifier);
    }
}