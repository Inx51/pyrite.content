using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.DependencyInjection;
using Pyrite.Event.Abstractions.Interfaces.Services;
using Pyrite.Content.Events;

namespace Pyrite.Content.Builder
{
    public class PyriteContentExtensions
    {
        public void UsePyriteContent(IApplicationBuilder app)
        {
            var eventService = app.ApplicationServices.GetService<IEventService>();
            if (eventService != null)
                PyriteContent.Initialize(eventService);
        }
    }
}