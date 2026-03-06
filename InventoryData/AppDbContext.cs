using InventoryData.config;
using InventoryModels.Auth;
using InventoryModels.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryData
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       public DbSet<Users> Users { get; set; }
       public DbSet<Category> Categories { get; set; }

       public DbSet<Product> Products { get; set; }

       public DbSet<Warehouse> Warehouses { get; set; }
       public DbSet<Stock> Stocks { get; set; }

       public DbSet<StockTransfer> stockTransfers { get; set; }
        
        public DbSet<StockTransferItem> stockTransferItems {  get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UsersRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new WarehouseConfig());
            modelBuilder.ApplyConfiguration(new StockConfig());
            modelBuilder.ApplyConfiguration(new StockTransferConfig());
            modelBuilder.ApplyConfiguration(new StockTransferItemConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            modelBuilder.ApplyConfiguration(new RolePermissionConfig());
             modelBuilder.ApplyConfiguration(new UsersRolConfig());
        }
    }
}
