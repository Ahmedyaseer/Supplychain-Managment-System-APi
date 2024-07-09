
using Microsoft.EntityFrameworkCore;
using Supplychain_Core.CustomerService;
using Supplychain_Core.ItemService;
using Supplychain_Core.OrderSupplyService;
using Supplychain_Core.PickingListService;
using Supplychain_Core.SupplierService;
using Supplychain_Core.WearhouseService;
using Supplychain_Data.SeedData;
using Supplychain_Data.SystemContext;

namespace SupplychainManagmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<SystemDbContext>(options=>
            options.UseSqlServer(connectionString));


            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();    
            builder.Services.AddScoped<ICustomerService, CustomerService>();  
            builder.Services.AddScoped<IOrderSupplyService, OrderSupplyService>();
            builder.Services.AddScoped<IPickingListService, PickingListService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            SeedData.Seed(app);

            app.Run();
        }
    }
}
