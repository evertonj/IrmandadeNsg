using IrmandadeNsg.Domain.Core.Events;
using System;

namespace IrmandadeNsg.Domain.Events
{
    public class PostRemovedEvent : Event
    {
        public PostRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
