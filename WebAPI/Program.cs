
using CoreBusiness;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Plugin.Datastore.SQLServer;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Util;

namespace WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //

            var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebAPI")));


            builder.Services.AddIdentity<CoreBusiness.User, CoreBusiness.Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //builder.Services.AddIdentity<User, Role>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();


            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Application Services
            builder.Services.AddScoped<IAdministrativeDivisionService, AdministrativeDivisionService>();
            //builder.Services.AddScoped<IAdministrativeDivisionTypeService, AdministrativeDivisionTypeService>();
            builder.Services.AddScoped<IBagService, BagService>();
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IGuestService, GuestService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<ILogService, LogService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            builder.Services.AddScoped<AuthService>();

            //builder.Services.AddScoped<ITempUserRoleService, TempUserRoleService>();
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await db.Database.MigrateAsync();   // make sure schema exists

                var services = scope.ServiceProvider;
                await SeedData.SeedRolesAsync(services);
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
