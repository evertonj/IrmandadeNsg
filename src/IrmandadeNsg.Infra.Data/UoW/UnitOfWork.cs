using IrmandadeNsg.Domain.Interfaces;
using IrmandadeNsg.Infra.Data.Context;
using System;

namespace IrmandadeNsg.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IrmandadeContext _context;

        public UnitOfWork(IrmandadeContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
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
