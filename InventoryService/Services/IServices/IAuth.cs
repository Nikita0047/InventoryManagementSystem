using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Services.IServices
{
    public interface IAuth
    {
        Task<AuthResponse> SignUpAsync(SignUp request);
        Task<AuthResponse> SignInAsync(SignIn request);
    }
}
