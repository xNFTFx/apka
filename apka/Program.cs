using apka.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dodaj obs³ugê Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj obs³ugê kontrolerów z widokami (opcjonalnie, jeœli u¿ywasz równie¿ MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Konfiguracja potoku ¿¹dañ HTTP
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

// Mapowanie tras kontrolerów (opcjonalnie, jeœli u¿ywasz równie¿ MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
