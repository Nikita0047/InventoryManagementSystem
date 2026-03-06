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
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(p => p.Code)
                   .IsUnique();


            builder.HasData(
                new Permission { Id = 1, Code = "product.read" },
                new Permission { Id = 2, Code = "product.create" },
                new Permission { Id = 3, Code = "product.update" },
                new Permission { Id = 4, Code = "product.delete" },

                new Permission { Id = 5, Code = "stock.read" },
                new Permission { Id = 6, Code = "stock.adjust" },
                new Permission { Id = 7, Code = "stock.transfer" },

                new Permission { Id = 8, Code = "transfer.create" },
                new Permission { Id = 9, Code = "transfer.view" },
                new Permission { Id = 10, Code = "transfer.approve" }
            );
        }
    }
}
