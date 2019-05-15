using IrmandadeNsg.Domain.Core.Events;
using IrmandadeNsg.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IrmandadeNsg.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        private EventStoreSqlContext _context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~EventStoreSqlRepository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (_context != null))
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
