using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ProCar.Models;
using ProCar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"!!!!{connectionString}!!!!!");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
//new MySqlServerVersion(new Version())
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33))));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/admin/login");
builder.Services.AddAuthorization();

builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICarTypeService, CarTypeService>();
builder.Services.AddScoped<ICarsService, CarsService>();
builder.Services.AddSingleton<IBotMessageService, BotMessageService>();

builder.Services.AddScoped<IServerUploadService, ServerUploadService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

IHostEnvironment? env = app.Services.GetService<IHostEnvironment>();

//var aasd = env.ContentRootPath;
//Console.WriteLine(aasd+" <--- !!!!");

//app.UseFileServer(new FileServerOptions()
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(env.ContentRootPath, "node_modules")),
//    RequestPath = "/node_modules",
//    EnableDirectoryBrowsing = false
//});

app.UseFileServer(new FileServerOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env.ContentRootPath, "Data")),
    RequestPath = "/Data",
    EnableDirectoryBrowsing = false
});

// Migrations
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

app.Run();

