using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations; // Tak naprawdê niepotrzebne tutaj, ale nie zaszkodzi

namespace apka.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Poziom> Poziomy { get; set; }
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Skladnik> Skladnik { get; set; } // Zostawiamy 'Skladnik' jako nazwê DbSet.
    }
}