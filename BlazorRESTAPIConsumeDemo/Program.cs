using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorRESTAPIConsumeDemo;
using BlazorRESTAPIConsumeDemo.Services; //Added by Mo



public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); //Comment by Mo

            // Register HttpClient and ApiService
            builder.Services.AddScoped(sp => new HttpClient()); //Added by Mo
            builder.Services.AddScoped<ApiService>(); //Added by Mo

            await builder.Build().RunAsync();
        }
}

