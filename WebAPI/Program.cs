
using CoreBusiness;
using Infrastructure.Interfaces;
using Infrastructure.Plugin.Datastore.SQLServer;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebAPI")));

            builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Application Services
            builder.Services.AddScoped<IAdministrativeDivisionService, AdministrativeDivisionService>();
            builder.Services.AddScoped<IAdministrativeDivisionTypeService, AdministrativeDivisionTypeService>();
            builder.Services.AddScoped<IBagService, BagService>();
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IGuestService, GuestService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<ILogService, LogService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            //builder.Services.AddScoped<ITempUserRoleService, TempUserRoleService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

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
