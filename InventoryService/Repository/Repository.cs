using InventoryData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext context)
        {
            _context= context;
            this.dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
           
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            IQueryable<T> query = dbSet;

            // Assuming T has a property named "Id" of type int.
            // If not, you need to provide more info about how to get by id.
            var entity = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            return entity!;
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public IQueryable<T> GetQuery()
        {
            return dbSet.AsQueryable();
        }

    }
}
