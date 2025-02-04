using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using ProCar.Models;
using ProCar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33))));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/admin/login");
builder.Services.AddAuthorization();

builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICarTypeService, CarTypeService>();
builder.Services.AddScoped<ICarsService, CarsService>();
builder.Services.AddSingleton<IBotMessageService, BotMessageService>();

builder.Services.AddScoped<IServerUploadService, ServerUploadService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

var webRootProvider = new PhysicalFileProvider(builder.Environment.WebRootPath);
var newPathProvider = new PhysicalFileProvider(Path.Join(builder.Environment.ContentRootPath, "Data", "imgs"));

var compositeProvider = new CompositeFileProvider(webRootProvider,
                                                  newPathProvider);

// Update the default provider.
app.Environment.WebRootFileProvider = compositeProvider;

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

IHostEnvironment? env = app.Services.GetService<IHostEnvironment>();


app.UseFileServer(new FileServerOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env!.ContentRootPath, "Data")),
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

