using InventoryModels.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryData
{
    public class UserConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.Id);
           
   
          builder.ToTable("users");

            builder.HasMany(u => u.UsersRole)
                   .WithOne(ur => ur.User)
                   .HasForeignKey(ur => ur.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                 new Users
                 {
                     Id = 1,
                     FirstName = "Nikita",
                     LastName = "Kumari",
                     Email = "Nikita11@example.com",
                    
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                     CreatedAt = new DateTime(2026, 01, 01)
                 }
            );
        }
    }
}
