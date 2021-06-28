using Pyrite.Content.Constants;
using Pyrite.Event.Abstractions;
using Pyrite.Event.Abstractions.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pyrite.Content.Events.Bases
{
    public class PyriteContentEventBase<TEvent> : EventBase where TEvent : IEvent
    {
        public PyriteContentEventBase()
        : base
        (
            typeof(TEvent).Name,
            SystemInfo.Name
        )
        {
        }
    }
}