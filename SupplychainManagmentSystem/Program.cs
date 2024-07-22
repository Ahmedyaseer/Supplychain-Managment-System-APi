
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supplychain_Core.Helper;
using Supplychain_Core.Services.AuthService;
using Supplychain_Core.Services.CustomerService;
using Supplychain_Core.Services.ItemService;
using Supplychain_Core.Services.OrderSupplyService;
using Supplychain_Core.Services.PickingListService;
using Supplychain_Core.Services.SupplierService;
using Supplychain_Core.Services.WarehouseService;
using Supplychain_Data.SeedData;
using Supplychain_Data.SystemContext;
using System.Text;

namespace SupplychainManagmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
            var jwtSettings = builder.Configuration.GetSection("JWTSettings").Get<JWTSettings>();


            string connectionString = builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddDbContext<SystemDbContext>(options=>
            options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                

            }).AddEntityFrameworkStores<SystemDbContext>();

            // JWT Services Config
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o=>
            {
                o.SaveToken = true; // in HttpContext
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    SaveSigninToken = true,
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidateLifetime = true,
                };
            });
            


            builder.Services.AddScoped<IWarehouseService, WarehouseService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<ISupplierService, SupplierService>();    
            builder.Services.AddScoped<ICustomerService, CustomerService>();  
            builder.Services.AddScoped<IOrderSupplyService, OrderSupplyService>();
            builder.Services.AddScoped<IPickingListService, PickingListService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            SeedData.Seed(app);

            app.Run();
        }
    }
}
