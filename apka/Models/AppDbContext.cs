using Microsoft.EntityFrameworkCore; 
using System.ComponentModel.DataAnnotations;

namespace apka.Models
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Poziom> Poziomy { get; set; }
        public DbSet<Autor> Autorzy { get; set; }
        public DbSet<Skladnik> Skladnik { get; set; }
    }
}