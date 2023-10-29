using System.Text.Json;
using System.Text.Json.Serialization;
using ObiletCase.UI.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
var environmentName = builder.Environment.EnvironmentName;

builder.Configuration
    .SetBasePath(currentDirectory)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.Services.AddControllersWithViews()
.AddRazorRuntimeCompilation()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    });

builder.Services.AddConfigureHttpClient(builder.Configuration)
                .AddConfigureService(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

// app.UseExceptionHandlingMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Journey}/{action=Index}/{id?}");

app.Run();
