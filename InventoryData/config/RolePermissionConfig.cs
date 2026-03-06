using InventoryModels.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryData.config
{
    public class RolePermissionConfig : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.HasOne(rp => rp.Role)
                   .WithMany(r => r.RolePermissions)
                   .HasForeignKey(rp => rp.RoleId);

            builder.HasOne(rp => rp.Permission)
                   .WithMany(p => p.RolePermissions)
                   .HasForeignKey(rp => rp.PermissionId);

            builder.HasData(
              new RolePermission { RoleId = 2, PermissionId = 2 }, // product.create
              new RolePermission { RoleId = 2, PermissionId = 3 }, // product.update
              new RolePermission { RoleId = 2, PermissionId = 6 }, // stock.adjust
              new RolePermission { RoleId = 2, PermissionId = 7 }, // stock.transfer
              new RolePermission { RoleId = 2, PermissionId = 8 }  // transfer.create
            );
        }


    }
}
