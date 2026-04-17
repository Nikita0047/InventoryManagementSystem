using InventoryModels.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using InventoryModels.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace InventoryData.config
{
    public class UsersRolConfig : IEntityTypeConfiguration<UsersRole>
    {
        public void Configure(EntityTypeBuilder<UsersRole> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasOne(ur => ur.User)
                   .WithMany(u => u.UsersRole)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ur => ur.Role)
                   .WithMany(r => r.UsersRole)
                   .HasForeignKey(ur => ur.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
