using InventoryData;
using InventoryModels.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Repository
{
    public class UserRepo : Repository<Users>,IUserRepo
    {
        private readonly AppDbContext _context;
        internal DbSet<Users> _dbSet;
        public UserRepo(AppDbContext context):base(context)
        {
            _context = context;
            this._dbSet = context.Set<Users>();
        }
        

       
        public  async Task<bool> EmailExistsAsync(string email)
        {
            var normalizedEmail = email.ToLower().Trim();
            return await _dbSet.AnyAsync(u => u.Email == normalizedEmail);
        }

       

        public async Task<Users> GetByEmailAsync(string email)
        {
            var normalizedEmail = email.ToLower().Trim();
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == normalizedEmail);
        }

       

        public async Task<Users> GetByUsernameAsync(string username)
        {
            var normalizedUsername = username.ToLower().Trim();
            return await _dbSet.FirstOrDefaultAsync(u =>
                ((u.FirstName ?? "") + " " + (u.LastName ?? ""))
                .ToLower().Trim() == normalizedUsername);
        }

        
        public async Task<bool> UsernameExistsAsync(string username)
        {
            var normalizedUsername = username.ToLower().Trim();
            return await _dbSet.AnyAsync(u =>
                ((u.FirstName ?? "") + " " + (u.LastName ?? ""))
                .ToLower().Trim() == normalizedUsername);
        }
    }
}
