using Pyrite.Content.Domain.Constants;
using Pyrite.Event.Abstractions;
using Pyrite.Event.Abstractions.Bases;

namespace Pyrite.Content.Domain.Events.Bases
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