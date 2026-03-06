using InventoryModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService
{
   public interface IAuth
    {
        Task<AuthResponse> SignUpAsync(SignUp request);  // Changed to AuthResponse
        Task<AuthResponse> SignInAsync(SignIn request);  // Changed to AuthResponse
        

    }
}
