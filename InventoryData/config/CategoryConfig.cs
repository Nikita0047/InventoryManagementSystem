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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(c => c.Name)
                   .IsUnique();

            builder.HasMany(c => c.Products)
                   .WithOne(p=> p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Electronics"

                },
                new Category
                {
                    Id = 2,
                    Name = "Groceries"
                },
                new Category
                {
                    Id = 3,
                    Name = "Furniture"
                }
            );
        }
    }
}
