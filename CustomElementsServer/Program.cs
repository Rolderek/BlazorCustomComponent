var builder = WebApplication.CreateBuilder(args);
//minden oldal a neten elérheti ezeket a file-okat:
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.MapGet("/", () => "This is the server supplying our Custom element"); //minimal api


app.UseStaticFiles(new StaticFileOptions { ServeUnknownFileTypes = true });


app.Run();
