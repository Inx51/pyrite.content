using Pyrite.Content.Constants;
using Pyrite.Content.Events.Bases;
using Pyrite.Event.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyrite.Content.Events
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