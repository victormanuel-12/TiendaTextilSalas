using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using proyectoTienda.Data;
using proyectoTienda.Servicios;
using Microsoft.AspNetCore.Identity.UI.Services;
using proyectoTienda.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
  options.IdleTimeout = TimeSpan.FromSeconds(300);
  options.Cookie.HttpOnly = true;
  options.Cookie.IsEssential = true;
});
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>() 
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICarritoService, CarritoService>();


builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables(); // 
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICarritoService, CarritoService>();
// ...existing code...
builder.Services.AddTransient<IEmailSender, EmailSender>();

// ...existing code...

builder.Services.AddControllers();
builder.Services.AddHttpClient(); // <- Aquí

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseMigrationsEndPoint();
}
else
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}
app.UseSession();

// En Program.cs, después de builder.Build()
var smtpSettings = app.Services.GetRequiredService<IConfiguration>().GetSection("SmtpSettings");
Console.WriteLine($"SMTP Config: {smtpSettings["Host"]}:{smtpSettings["Port"]}");
Console.WriteLine($"Usuario: {smtpSettings["UserName"]}");
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
