using Gvn.IceCream.MAUI.Pages;
using Gvn.IceCream.MAUI.Services;
using Gvn.IceCream.MAUI.ViewModels;
using Microsoft.Extensions.Logging;
using Refit;
#if ANDROID
using System.Net.Security;
using Xamarin.Android.Net;
#elif IOS
using Security;
#endif
namespace Gvn.IceCream.MAUI
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<AuthViewModel>()
                            .AddTransient<SignupPage>()
                            .AddTransient<SigningPage>();
            ConfigureRefit(builder.Services);
            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {
            var refitSettings = new RefitSettings
            {
                HttpMessageHandlerFactory = () =>
                {
#if ANDROID
                    return new AndroidMessageHandler
                    {
                        ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
                        {
                            return certificate?.Issuer=="CN=localhost"||sslPolicyErrors==SslPolicyErrors.None;
                        }
                    };
#elif IOS
                    return new NSUrlSessionHandler
                    {
                        TrustOverrideForUrl=(NSUrlSessionHandler sender,string url,SecTrust trust)=>
                                        url.StartsWith("https://localhost")
                    };
#endif
                    return null;
                }
            };
            services.AddRefitClient<IAuthApi>(refitSettings).ConfigureHttpClient(httpClient =>
            {
                var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7241" :
                                                                         "https://localhost:7241";
                httpClient.BaseAddress = new Uri(baseUrl);
            });
        }
    }
}
