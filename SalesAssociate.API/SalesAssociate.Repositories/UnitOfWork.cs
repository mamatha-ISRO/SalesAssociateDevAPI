using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAssociate.Repositories.Repositories;
using SalesAssociate.Repositories.Repositories.Interfaces;

namespace SalesAssociate.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable

    {
        private readonly SAApplicationDbContext _context;

        public ICarRepository Cars { get; private set; }

        public UnitOfWork(SAApplicationDbContext context)
        {
            _context = context;

            Cars = new CarRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
