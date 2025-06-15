using apka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Dodaj obs�ug� Razor Pages
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodaj obs�ug� kontroler�w z widokami (opcjonalnie, je�li u�ywasz r�wnie� MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// --- START BLOKU KODU DLA SEEDINGU DANYCH ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();

        if (!context.Kategorie.Any())
        {
            var kategorie = new Kategoria[]
            {
                new Kategoria("Owocowe"),
                new Kategoria("Mleczne"),
                new Kategoria("Warzywne"),
                new Kategoria("Fit")
            };
            context.Kategorie.AddRange(kategorie);
            context.SaveChanges();
        }

        if (!context.Poziomy.Any())
        {
            var poziomy = new Poziom[]
            {
                new Poziom("�atwy"),
                new Poziom("�redni"),
                new Poziom("Trudny"),
                new Poziom("Dla zaawansowanych")
            };
            context.Poziomy.AddRange(poziomy);
            context.SaveChanges();
        }

        if (!context.Autorzy.Any())
        {
            var autorzy = new Autor[]
            {
                new Autor("Anna Gotuje"),
                new Autor("Bartek ShakeMaster"),
                new Autor("Dietetyk Smaku")
            };
            context.Autorzy.AddRange(autorzy);
            context.SaveChanges();
        }

        if (!context.Skladnik.Any())
        {
            var skladniki = new Skladnik[]
            {
                new Skladnik("Truskawka"),
                new Skladnik("Banan"),
                new Skladnik("Czekolada"),
                new Skladnik("Szpinak"),
                new Skladnik("Bia�ko WPC")
            };
            context.Skladnik.AddRange(skladniki);
            context.SaveChanges();
        }

        // Dodanie Produkt�w (shake'�w) - pami�taj o poprawnych IdKategoria, IdPoziom itd.
        if (!context.Produkty.Any())
        {
            var kategoriaOwocowe = context.Kategorie.FirstOrDefault(k => k.Nazwa == "Owocowe");
            var kategoriaMleczne = context.Kategorie.FirstOrDefault(k => k.Nazwa == "Mleczne");

            var poziomLatwy = context.Poziomy.FirstOrDefault(p => p.Nazwa == "�atwy");
            var poziomSredni = context.Poziomy.FirstOrDefault(p => p.Nazwa == "�redni");

            var autorAnna = context.Autorzy.FirstOrDefault(a => a.Nazwa == "Anna Gotuje");
            var autorBartek = context.Autorzy.FirstOrDefault(a => a.Nazwa == "Bartek ShakeMaster");

            var skladnikTruskawka = context.Skladnik.FirstOrDefault(s => s.Nazwa == "Truskawka");
            var skladnikBanan = context.Skladnik.FirstOrDefault(s => s.Nazwa == "Banan");
            var skladnikCzekolada = context.Skladnik.FirstOrDefault(s => s.Nazwa == "Czekolada");

            if (kategoriaOwocowe != null && poziomLatwy != null && autorAnna != null && skladnikTruskawka != null)
            {
                context.Produkty.Add(new Produkt("Shake Truskawkowy", "Pyszny i orze�wiaj�cy shake z truskawek")
                {
                    IdKategoria = kategoriaOwocowe.IdKategoria,
                    IdPoziom = poziomLatwy.IdPoziom,
                    IdAutor = autorAnna.IdAutor,
                    IdSkladnik = skladnikTruskawka.IdSkladnik
                    // Linia z Instrukcje = "..." zosta�a usuni�ta
                });
            }

            if (kategoriaMleczne != null && poziomSredni != null && autorBartek != null && skladnikBanan != null)
            {
                context.Produkty.Add(new Produkt("Shake Bananowy", "Kremowy shake o smaku banana.")
                {
                    IdKategoria = kategoriaMleczne.IdKategoria,
                    IdPoziom = poziomSredni.IdPoziom,
                    IdAutor = autorBartek.IdAutor,
                    IdSkladnik = skladnikBanan.IdSkladnik
                    // Linia z Instrukcje = "..." zosta�a usuni�ta
                });
            }
            if (kategoriaMleczne != null && poziomSredni != null && autorAnna != null && skladnikCzekolada != null)
            {
                context.Produkty.Add(new Produkt("Shake Czekoladowy", "Idealny dla mi�o�nik�w czekolady.")
                {
                    IdKategoria = kategoriaMleczne.IdKategoria,
                    IdPoziom = poziomSredni.IdPoziom,
                    IdAutor = autorAnna.IdAutor,
                    IdSkladnik = skladnikCzekolada.IdSkladnik
                    // Linia z Instrukcje = "..." zosta�a usuni�ta
                });
            }

            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Wyst�pi� b��d podczas seedingu bazy danych.");
    }
}
// --- KONIEC BLOKU KODU DLA SEEDINGU DANYCH ---

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