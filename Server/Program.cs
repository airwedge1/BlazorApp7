using BlazorApp7.Client.Pages;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

var useServerSideBlazor = builder.Configuration.GetValue<bool>("UseServerSideBlazor");

if (useServerSideBlazor)
{
    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();
    builder.Services.AddServerSideBlazor().AddCircuitOptions(o =>
    {
        o.DetailedErrors = true;
    });

    
    builder.Services.AddScoped(sp => {
        var baseAddress = "https://localhost:7025";

        return new HttpClient
        {
            BaseAddress = new Uri(baseAddress)
        };
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapControllers();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
else
{

    // Add services to the container.

    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();


    app.MapRazorPages();
    app.MapControllers();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
