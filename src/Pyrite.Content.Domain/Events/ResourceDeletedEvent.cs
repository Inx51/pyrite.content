using Pyrite.Content.Domain.Constants;
using Pyrite.Content.Domain.Events.Bases;
using Pyrite.Event.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyrite.Content.Domain.Events
{
    public class ResourceDeletedEvent : PyriteContentEventBase<ResourceDeletedEvent>
    {
        public ResourceDeletedEvent(string identifier)
        {
            this.Payload = new Dictionary<string, object>
            {
                [ResourceEventPayloadKeys.Identifier] = identifier
            };
        }
    }
}