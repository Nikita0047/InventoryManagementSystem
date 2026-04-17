using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.Auth
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; // Admin, Manager, User

        public ICollection<UsersRole> UsersRole { get; set; } = new List<UsersRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
