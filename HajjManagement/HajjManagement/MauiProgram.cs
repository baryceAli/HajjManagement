using CoreBusiness;
using HajjManagement.Services;
using HajjManagement.Shared.Services;
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

            var APIBaseUri = config.GetValue<string>("APIBaseUri") ?? "https://localhost:7154/";

            builder.Services.AddHttpClient<IGenericAPIService<AdministrativeDivision>, GenericAPIService<AdministrativeDivision>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/AdministrativeDivision/");
            });

            builder.Services.AddHttpClient<IGenericAPIService<AdministrativeDivisionType>, GenericAPIService<AdministrativeDivisionType>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/AdministrativeDivisionType/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Bag>, GenericAPIService<Bag>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/bag/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Contract>, GenericAPIService<Contract>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/Contract/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Country>, GenericAPIService<Country>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/Country/");
            });

            builder.Services.AddHttpClient<IGenericAPIService<Guest>, GenericAPIService<Guest>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/Guest/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Hotel>, GenericAPIService<Hotel>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/Hotel/");
            });


            builder.Services.AddHttpClient<IGenericAPIService<Log>, GenericAPIService<Log>>(client =>
            {
                client.BaseAddress = new Uri($"{APIBaseUri}/api/Log/");
            });


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
