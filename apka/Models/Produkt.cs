using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Upewnij się, że to jest!

namespace apka.Models
{
    public class Produkt
    {
        [Key]
        public int IdProdukt { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string Opis { get; set; }

        // Klucze obce
        [ForeignKey("Kategoria")]
        public int IdKategoria { get; set; }
        [ForeignKey("Poziom")]
        public int IdPoziom { get; set; }
        [ForeignKey("Autor")]
        public int IdAutor { get; set; }
        [ForeignKey("Skladnik")]
        public int IdSkladnik { get; set; }

        // Właściwości nawigacyjne
        public virtual Kategoria Kategoria { get; set; }
        public virtual Poziom Poziom { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Skladnik Skladnik { get; set; }

        // Domyślny konstruktor
        public Produkt() { }

        // Konstruktor z parametrami
        public Produkt(string nazwa, string opis)
        {
            Nazwa = nazwa;
            Opis = opis;
        }
    }
}