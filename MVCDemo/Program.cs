using BlazorComponent.Pages;
using Microsoft.AspNetCore.Components.Web;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//milyen componenseket használjon a sajátjaimból:
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options =>
    {
        options.RootComponents.RegisterCustomElement<Counter>("my-counter");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


/*
 * a Views/Shared/_Layout.cshtm file-ba kell ez a script-ek végére:
 * "<script src="_framework/blazor.server.js"></script>"
 * 
 * beregisztráljuk a RazorComponents-eket a builder.Services-en keresztül itt
 * 
 * 
*/