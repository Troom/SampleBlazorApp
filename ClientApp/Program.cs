using Blazored.LocalStorage;
using ClientApp;
using ClientApp.Helper;
using ClientApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IOrderDataService, OrderDataService>(option =>
                                                    option.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddScoped<ApplicationState>(); //Currenly unused.Maybe for new orders or bin

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
