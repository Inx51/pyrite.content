using Microsoft.Extensions.Primitives;
using Pyrite.Content.Domain.Constants;
using Pyrite.Content.Domain;
using Pyrite.Content.Domain.Events.Bases;
using Pyrite.Event.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyrite.Content.Domain.Events
{
    public class ResourceUpdatedEvent : PyriteContentEventBase<ResourceUpdatedEvent>
    {
        public ResourceUpdatedEvent(Resource resource)
        {
            this.Payload = new Dictionary<string, object>
            {
                [ResourceEventPayloadKeys.Identifier] = resource.Identifier,
                [ResourceEventPayloadKeys.Headers] = resource.Headers,
                [ResourceEventPayloadKeys.Body] = resource.Body
            };
        }

        public ResourceUpdatedEvent
        (
            string identifier,
            IEnumerable<KeyValuePair<string, StringValues>> headers,
            string bodyLocation
        )
        {
            this.Payload = new Dictionary<string, object>
            {
                [ResourceEventPayloadKeys.Identifier] = identifier,
                [ResourceEventPayloadKeys.Headers] = headers,
                [ResourceEventPayloadKeys.BodyLocation] = bodyLocation
            };
        }
    }
}