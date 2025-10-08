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

            var APIBaseUri = builder.Configuration.GetValue<string>("APIBaseUri") ?? "https://localhost:7154/";

            builder.Services.AddHttpClient<IGenericAPIService<AdministrativeDivision>, GenericAPIService<AdministrativeDivision>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/AdministrativeDivision/");
            });

            builder.Services.AddHttpClient<IGenericAPIService<CountryStructure>, GenericAPIService<CountryStructure>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/CountryStructure/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Bag>, GenericAPIService<Bag>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/bag/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Contract>, GenericAPIService<Contract>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/Contract/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Country>, GenericAPIService<Country>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/Country/");
            });

            builder.Services.AddHttpClient<IGenericAPIService<Guest>, GenericAPIService<Guest>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/Guest/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Hotel>, GenericAPIService<Hotel>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/Hotel/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Log>, GenericAPIService<Log>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/Log/");
            });

            builder.Services.AddHttpClient<IGenericAPIService<User>, GenericAPIService<User>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/User/");
            });
            builder.Services.AddHttpClient<IGenericAPIService<Role>, GenericAPIService<Role>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/Role/");
            });
            builder.Services.AddHttpClient<IGenericAPIService<LoginDto>, GenericAPIService<LoginDto>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/v1/User/login/");
            });


            //builder.Services.AddHttpClient<IGenericAPIService<TempUserRole>, GenericAPIService<TempUserRole>>(client =>
            //{
            //    client.BaseAddress = new Uri($"{APIBaseUri}/api/UserRole/");
            //});


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
