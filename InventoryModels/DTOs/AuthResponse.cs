using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.DTOs
{
    public  class AuthResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public string Role { get; set; }    
        public DateTime ExpiresAt { get; set; }
    }
}
