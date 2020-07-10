using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlannerApp.Shared.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Blazor.FileReader;

namespace PlannerApp.Client
{
  public class Program
    {
        private const string URL = "https://plannerappserver20200228091432.azurewebsites.net";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
           
            builder.Services.AddScoped<AuthenticationService>(s => {
                return new AuthenticationService(URL);
            });

            builder.Services.AddScoped<PlansService>(s => {
                return new PlansService(URL);
            });

            builder.Services.AddFileReaderService(options => {
                options.UseWasmSharedBuffer = true;
            });

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<LocalAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<LocalAuthenticationStateProvider>());

            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
    }
}
