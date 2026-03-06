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
    public class StockTransferItemConfig : IEntityTypeConfiguration<StockTransferItem>
    {
        public void Configure(EntityTypeBuilder<StockTransferItem> builder)
        {
            builder.ToTable("StockTransferItems", t =>
            {
                t.HasCheckConstraint(
                    "CK_StockTransferItem_Quantity_Positive",
                    "[Quantity] > 0"
                );
            });

            builder.HasKey(sti => sti.Id);

            builder.Property(sti => sti.Quantity)
                   .IsRequired();

            // Relationship → StockTransfer (parent)
            builder.HasOne(sti => sti.StockTransfer)
                   .WithMany(st => st.Items)
                   .HasForeignKey(sti => sti.StockTransferId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relationship → Product
            builder.HasOne(sti => sti.Product)
                   .WithMany()
                   .HasForeignKey(sti => sti.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Prevent same product appearing twice in same transfer
            builder.HasIndex(sti => new { sti.StockTransferId, sti.ProductId })
                   .IsUnique();

            // ✅ SAMPLE DATA (3 records)
            builder.HasData(
                new StockTransferItem
                {
                    Id = 1,
                    StockTransferId = 1, // Transfer: 1 → 2
                    ProductId = 1,       // Laptop
                    Quantity = 5
                },
                new StockTransferItem
                {
                    Id = 2,
                    StockTransferId = 2, // Transfer: 2 → 3
                    ProductId = 3,       // Office Chair
                    Quantity = 3
                },
                new StockTransferItem
                {
                    Id = 3,
                    StockTransferId = 3, // Transfer: 3 → 1
                    ProductId = 2,       // Rice Bag 25kg
                    Quantity = 20
                }
            );
        }
    }
}
