using CoreBusiness;
using HajjManagement.Services;
using HajjManagement.Shared.Services;
using HajjManagement.Shared.Services.Custom;
using HajjManagement.Shared.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace HajjManagement
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Load appsettings.json manually
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("HajjManagement.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream!)
                .Build();

            var APIBaseUri = config.GetValue<string>("APIBaseUri") ?? "https://localhost:7154";
            builder.Services.AddHttpClient("GenericApiClient", client =>
            {
                client.BaseAddress = new Uri(APIBaseUri);
            });

            builder.Services.AddScoped(typeof(IGenericAPIService<>), typeof(GenericAPIService<>));


            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddScoped<ICountryStructureCustomService, CountryStructureCustomService>();
            builder.Services.AddScoped<IAdministrativeDivisionCustomService, AdministrativeDivisionCustomService>();
            builder.Services.AddScoped<IUserCustomService, UserCustomService>();
            // Add device-specific services used by the HajjManagement.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
