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
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks", t =>
            {
                t.HasCheckConstraint(
                    "CK_Stock_Quantity_NonNegative",
                    "[Quantity] >= 0"
                );
            });

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Quantity)
                   .IsRequired();

            // Prevent duplicate stock rows for same Product + Warehouse
            builder.HasIndex(s => new { s.ProductId, s.WarehouseId })
                   .IsUnique();

            builder.HasOne(s => s.Product)
                   .WithMany(p => p.Stocks)
                   .HasForeignKey(s => s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Warehouse)
                   .WithMany(w => w.Stocks)
                   .HasForeignKey(s => s.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData
            (
                new Stock
                {
                Id = 1,
                ProductId = 1,   // Laptop
                WarehouseId = 1, // Central Warehouse
                Quantity = 50
                },
                new Stock
                {
                Id = 2,
                ProductId = 2,   // Smartphone
                WarehouseId = 1, // Central Warehouse
                Quantity = 120
                },
                new Stock
                {
                Id = 3,
                ProductId = 3,   // Office Chair
                WarehouseId = 2, // North Distribution Center
                Quantity = 30
                }
               
            );
        }
    }
}
