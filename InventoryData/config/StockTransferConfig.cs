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
    public class StockTransferConfig : IEntityTypeConfiguration<StockTransfer>
    {
        public void Configure(EntityTypeBuilder<StockTransfer> builder)
        {

            builder.ToTable("StockTransfers", t =>
            {
                t.HasCheckConstraint(
                    "CK_StockTransfer_From_To_Different",
                    "[FromWarehouseId] <> [ToWarehouseId]"
                );
            });

            builder.HasKey(st => st.Id);

            builder.Property(st => st.TransferDate)
                   .IsRequired();

            builder.HasOne<Warehouse>()
                   .WithMany()
                   .HasForeignKey(st => st.FromWarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Warehouse>()
                   .WithMany()
                   .HasForeignKey(st => st.ToWarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(st => st.Items)
                   .WithOne(i => i.StockTransfer)
                   .HasForeignKey(i => i.StockTransferId)
                   .OnDelete(DeleteBehavior.Cascade);

            // ✅ SAMPLE DATA (3 records)
            builder.HasData(
                new StockTransfer
                {
                    Id = 1,
                    FromWarehouseId = 1,
                    ToWarehouseId = 2,
                    TransferDate = new DateTime(2025, 01, 10)
                },
                new StockTransfer
                {
                    Id = 2,
                    FromWarehouseId = 2,
                    ToWarehouseId = 3,
                    TransferDate = new DateTime(2025, 01, 15)
                },
                new StockTransfer
                {
                    Id = 3,
                    FromWarehouseId = 3,
                    ToWarehouseId = 1,
                    TransferDate = new DateTime(2025, 01, 20)
                }
            );
        }
    }
}
