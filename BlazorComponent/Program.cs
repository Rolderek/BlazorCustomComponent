using BlazorComponent;
using BlazorComponent.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//beregisztráltam a custom elementemet:
builder.RootComponents.RegisterCustomElement<Counter>("my-counter"); 
await builder.Build().RunAsync();
