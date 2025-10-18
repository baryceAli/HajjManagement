using CoreBusiness;
using CoreBusiness.Dtos;
using HajjManagement.Shared.Services;
using HajjManagement.Shared.Services.Custom;
using HajjManagement.Shared.Utilities;
using HajjManagement.Web.Components;
using HajjManagement.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

namespace HajjManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //var builder = WebApplication.CreateBuilder(args);

            var APIBaseUri = builder.Configuration.GetValue<string>("APIBaseUri") ?? "https://localhost:7154/";

            builder.Services.AddHttpClient("GenericApiClient", client =>
            {
                client.BaseAddress = new Uri(APIBaseUri);
            });

            builder.Services.AddScoped(typeof(IGenericAPIService<>), typeof(GenericAPIService<>));

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.Configure<CircuitOptions>(options =>
            {
                options.DetailedErrors = true;
            });

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<ICountryStructureCustomService, CountryStructureCustomService>();
            builder.Services.AddScoped<IAdministrativeDivisionCustomService,AdministrativeDivisionCustomService>();
            builder.Services.AddScoped<IUserCustomService, UserCustomService>();
            // Add device-specific services used by the HajjManagement.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(typeof(HajjManagement.Shared._Imports).Assembly);

            app.Run();
        }
    }
}
