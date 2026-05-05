using InventoryModels.Auth;
using InventoryModels.DTOs;
using InventoryRepository.Repository;
using InventoryService.Services.IServices;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.Services
{
    public class UsersService : IUsers
    {
        private readonly IUserRepo _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IUserRepo userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }



        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllWithIncludesAsync();  // ← we need this in repo

            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Email = u.Email,
                FullName = $"{u.FirstName} {u.LastName}",
                Role = u.UsersRole
                               .Select(ur => ur.Role.Name)
                               .FirstOrDefault() ?? "No Role",
                Permissions = u.UsersRole
                               .SelectMany(ur => ur.Role.RolePermissions)
                               .Select(rp => rp.Permission.Code)
                               .Distinct()
                               .ToList(),
                CreatedAt = u.CreatedAt
            }).ToList();
        }

        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdWithIncludesAsync(id); // ← we need this in repo

            if (user == null)
                throw new KeyNotFoundException($"User {id} not found");

            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                FullName = $"{user.FirstName} {user.LastName}",
                Role = user.UsersRole
                                  .Select(ur => ur.Role.Name)
                                  .FirstOrDefault() ?? "No Role",
                Permissions = user.UsersRole
                                  .SelectMany(ur => ur.Role.RolePermissions)
                                  .Select(rp => rp.Permission.Code)
                                  .Distinct()
                                  .ToList(),
                CreatedAt = user.CreatedAt
            };
        }

        public async Task UpdateUserRoleAsync(int id, int roleId)
        {
            var user = await _userRepo.GetByIdWithIncludesAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"User {id} not found");

            // Remove old roles
            user.UsersRole.Clear();

            // Add new role
            user.UsersRole.Add(new UsersRole
            {
                UserId = id,
                RoleId = roleId
            });

            await _unitOfWork.SaveAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
                throw new KeyNotFoundException($"User {id} not found");

            _userRepo.Delete(user);
            await _unitOfWork.SaveAsync();
        }
    }
}
