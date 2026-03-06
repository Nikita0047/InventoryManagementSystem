using InventoryModels.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryData.config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Name)
              .IsRequired()
              .HasMaxLength(100);

            builder.HasIndex(p => p.Name)
                   .IsUnique();

            builder.Property(p => p.SKU)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(p => p.SKU)
                   .IsUnique();

            builder.HasIndex(p => new { p.Name, p.CategoryId })
                  .IsUnique();

            builder.HasOne(p => p.Category)
                  .WithMany(c=>c.Products)
                  .HasForeignKey(p=>p.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Stocks)
                   .WithOne(s=>s.Product)
                   .HasForeignKey(s=>s.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData
            (
                 new Product
                 {
                     Id = 1,
                     Name = "Laptop",
                     SKU = "ELEC-LAP-001",
                     CategoryId = 1 // Electronics
                 },
                new Product
                {
                    Id = 2,
                    Name = "Office Chair",
                    SKU = "FURN-CHAIR-001",
                    CategoryId = 3 // Furniture
                },
                 new Product
                 {
                     Id = 3,
                     Name = "Rice Bag 25kg",
                     SKU = "GROC-RICE-001",
                     CategoryId = 2 // Groceries
                 }
            );


        }
    }
}
