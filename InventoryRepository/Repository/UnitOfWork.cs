using InventoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                // This ONE LINE works for ANY entity!
                var repository = new Repository<T>(_context);
                _repositories.Add(type, repository);
            }
            return (IRepository<T>)_repositories[type];
        }
    }
}
