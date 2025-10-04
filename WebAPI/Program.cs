
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using CoreBusiness;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Plugin.Datastore.SQLServer;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Security.Claims;
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
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    // ✅ Map the JWT role claim type to the one ASP.NET expects
                    RoleClaimType =ClaimTypes.Role// "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                };
            });


            // Add services to the container.

            builder.Services.AddControllers();


            // ✅ API Versioning
            // ✅ Versioned API Explorer (needed for Swagger)
            builder.Services
                .AddApiVersioning(options =>
                {
                    // Default API Version if not specified
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;

                    // Report supported versions in response headers
                    options.ReportApiVersions = true;

                    // Use URL segment versioning by default (e.g. /api/v1/...)
                    options.ApiVersionReader = new UrlSegmentApiVersionReader();
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV"; // e.g. v1, v2
                    options.SubstituteApiVersionInUrl = true;
                });

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            // Register ConfigureSwaggerOptions for multiple versions
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // Swagger
            var swaggerEnabled = builder.Configuration.GetValue<bool>("Swagger:Enabled");

            builder.Services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your JWT token."
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });


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


            //builder.Services.AddOpenApi();
            
            //builder.Services.AddSwaggerGen();

            //Application Services
            builder.Services.AddScoped<IAdministrativeDivisionService, AdministrativeDivisionService>();
            //builder.Services.AddScoped<IAdministrativeDivisionTypeService, AdministrativeDivisionTypeService>();
            builder.Services.AddScoped<IBagService, BagService>();
            builder.Services.AddScoped<IContractService, ContractService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<ICountryStructureService, CountryStructureService>();
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



            var apiVersionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            //var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            // ✅ Swagger UI per API version
            swaggerEnabled = true;
            if (swaggerEnabled)
            {
                app.UseSwagger();

                // Get version info from the built DI container

                app.UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant()
                        );
                    }
                });
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
