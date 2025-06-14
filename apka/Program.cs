using apka.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dodaj obs�ug� Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj obs�ug� kontroler�w z widokami (opcjonalnie, je�li u�ywasz r�wnie� MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Konfiguracja potoku ��da� HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapowanie Razor Pages
app.MapRazorPages();

// Mapowanie tras kontroler�w (opcjonalnie, je�li u�ywasz r�wnie� MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
