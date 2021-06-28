using Microsoft.Extensions.DependencyInjection;
using Pyrite.Content.Abstractions.Interfaces.Repositories;
using Pyrite.Content.Core.Interfaces.Services;
using Pyrite.Content.Services;
using Pyrite.Event.Abstractions.Interfaces.Services;
using System;

namespace Pyrite.Content.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAhsContent(this IServiceCollection services)
        {
            services.AddTransient<IResourceService>
            (
                serviceProvider =>
                {
                    var eventService = serviceProvider.GetService<IEventService>();
                    var resourceRepository = serviceProvider.GetService<IResourceRepository>();

                    if (eventService == null)
                        return new ResourceService(resourceRepository);

                    return new ResourceService
                    (
                        resourceRepository,
                        eventService
                    );
                }
            );
        }
    }
}