using Pyrite.Content.Core;
using Pyrite.Content.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pyrite.Content.Core.Interfaces.Services
{
    public interface IResourceService
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