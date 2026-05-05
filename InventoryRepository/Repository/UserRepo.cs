using InventoryData;
using InventoryModels.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryRepository.Repository
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
            return await _dbSet.Include(u => u.UsersRole)
            .ThenInclude(ur => ur.Role)
                .ThenInclude(r => r.RolePermissions)    // ← needed
                    .ThenInclude(rp => rp.Permission)   // ← needed
                     .FirstOrDefaultAsync(u => u.Email == email);
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

        public async Task<List<Users>> GetAllWithIncludesAsync()
        {
            return await _dbSet
                .Include(u => u.UsersRole)
                    .ThenInclude(ur => ur.Role)
                        .ThenInclude(r => r.RolePermissions)
                            .ThenInclude(rp => rp.Permission)
                .ToListAsync();
        }

        // ← NEW
        public async Task<Users?> GetByIdWithIncludesAsync(int id)
        {
            return await _dbSet
                .Include(u => u.UsersRole)
                    .ThenInclude(ur => ur.Role)
                        .ThenInclude(r => r.RolePermissions)
                            .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
