using Pyrite.Content.Abstractions.Interfaces.Repositories;
using Pyrite.Content.Core.Interfaces.Services;
using Pyrite.Content.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Pyrite.Content.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IPyriteEventService _pyriteEventService;

        public ResourceService
        (
            IResourceRepository resourceRepository,
            IPyriteEventService pyriteEventService
        )
        {
            this._resourceRepository = resourceRepository;
            this._pyriteEventService = pyriteEventService;
        }

        public async Task CreateAsync(Resource resource)
        {
            await this._resourceRepository.CreateAsync(resource);
            await this._pyriteEventService.DispatchAsync(new PyriteContentResourceCreatedEvent(resource));
        }

        public async Task DeleteAsync(string identifier)
        {
            await this._resourceRepository.DeleteAsync(identifier);
            await this._pyriteEventService.DispatchAsync(new PyriteContentResourceDeletedEvent(identifier));
        }

        public async Task<bool> ExistsAsync(string identifier)
        {
            return await this._resourceRepository.ExistsAsync(identifier);
        }

        public async Task<Resource> GetAsync(string identifier, bool includeBody)
        {
            return await this._resourceRepository.GetAsync(identifier, includeBody);
        }

        public async Task UpdateAsync(Resource resource)
        {
            await this._resourceRepository.UpdateAsync(resource);
            await this._pyriteEventService.DispatchAsync(new PyriteContentResourceUpdatedEvent(resource));
        }
    }
}