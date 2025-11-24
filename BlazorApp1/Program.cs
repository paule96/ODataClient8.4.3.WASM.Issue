using BlazorApp1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(s =>
    new NS.Container(
            // direct hostname of URM API
            new Uri($"https://localhost:7248/odata/")
     )
    {
        MergeOption = Microsoft.OData.Client.MergeOption.NoTracking
    }
);
await builder.Build().RunAsync();
