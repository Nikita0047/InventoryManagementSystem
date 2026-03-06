using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.Auth
{
    public class Permission
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!; // product.create, stock.adjust

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
