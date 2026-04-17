
using InventoryData;
using InventoryRepository.Repository;
using InventoryService.Services.IServices;
using InventoryService.Services.Services;
using Microsoft.EntityFrameworkCore;


namespace InventoryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAuth, AuthService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IStockTransferService, StockTransferService>();
            builder.Services.AddScoped<IStockTransferItemService, StockTransferItemService>();
            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IStockService, StockService>();
            
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("CreateProduct",
                    policy => policy.RequireClaim("permission", "CreateProduct"));

                options.AddPolicy("TransferStock",
                    policy => policy.RequireClaim("permission", "TransferStock"));
            });

            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // cors error handling
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") // your frontend URL
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            app.UseCors("AllowAngular");
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
