using BlazorComponent;
using BlazorComponent.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.RegisterCustomElement<Counter>("my-blazor-counter"); //beregisztráltam a custom elementemet
await builder.Build().RunAsync();
