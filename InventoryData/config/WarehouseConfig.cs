using InventoryModels.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryData.config
{
    public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouses");

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(w => w.Location)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasIndex(w => w.Name)
                   .IsUnique();

            builder.HasMany(w => w.Stocks)
                   .WithOne(s => s.Warehouse)
                   .HasForeignKey(s => s.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Warehouse { Id = 1, Name = "Central Warehouse", Location = "Bangalore" },
                new Warehouse { Id = 2, Name = "North Distribution Center", Location = "Delhi" },
                new Warehouse { Id = 3, Name = "West Storage Hub", Location = "Mumbai" }
            );
        }
    }
}
