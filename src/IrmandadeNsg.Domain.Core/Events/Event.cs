using MediatR;
using System;

namespace IrmandadeNsg.Domain.Core.Events
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
