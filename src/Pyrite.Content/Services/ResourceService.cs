using Pyrite.Content.Abstractions.Interfaces.Repositories;
using Pyrite.Content.Core.Interfaces.Services;
using Pyrite.Content.Domain;
using Pyrite.Content.Domain.Events;
using Pyrite.Event.Abstractions.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Pyrite.Content.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IEventService _eventService;

        public ResourceService
        (
            IResourceRepository resourceRepository,
            IEventService eventService
        )
        : this(resourceRepository)
        {
            this._eventService = eventService;
        }

        public ResourceService
        (
            IResourceRepository resourceRepository
        )
        {
            this._resourceRepository = resourceRepository;
        }

        public async Task CreateAsync(Resource resource)
        {
            var claimCheckBodyLocation = await CreateClaimCheckResourceAsync(resource);

            await this._resourceRepository.CreateAsync(resource);

            if (this._eventService != null)
                await this._eventService.DispatchAsync
                (
                    new ResourceCreatedEvent
                    (
                        resource.Identifier,
                        resource.Headers,
                        claimCheckBodyLocation
                    )
                );
        }

        public async Task DeleteAsync(string identifier)
        {
            await this._resourceRepository.DeleteAsync(identifier);

            if (this._eventService != null)
                await this._eventService.DispatchAsync(new ResourceDeletedEvent(identifier));
        }

        public async Task<bool> ExistsAsync(string identifier)
        {
            return await this._resourceRepository.ExistsAsync(identifier);
        }

        public async Task<Resource> GetAsync
        (
            string identifier,
            bool includeBody
        )
        {
            return await this._resourceRepository.GetAsync
            (
                identifier,
                includeBody
            );
        }

        public async Task UpdateAsync(Resource resource)
        {
            var claimCheckBodyLocation = await CreateClaimCheckResourceAsync(resource);

            await this._resourceRepository.UpdateAsync(resource);

            if (this._eventService != null)
                await this._eventService.DispatchAsync
                (
                    new ResourceUpdatedEvent
                    (
                        resource.Identifier,
                        resource.Headers,
                        claimCheckBodyLocation
                    )
                );
        }

        private async Task<string> CreateClaimCheckResourceAsync(Resource resource)
        {
            var claimCheckBodyLocation = GenerateClaimCheckBodyLocation(resource.Identifier);

            var claimCheckResource = new Resource
            (
                claimCheckBodyLocation,
                resource.Headers,
                resource.Body
            );

            await this._resourceRepository.CreateAsync(claimCheckResource);

            resource.Body.Position = 0;

            return claimCheckBodyLocation;
        }

        private string GenerateClaimCheckBodyLocation(string resourceIdentifier)
        {
            return $"$/ClaimChecks/{DateTime.UtcNow.Ticks}_{Guid.NewGuid()}/{resourceIdentifier}";
        }
    }
}