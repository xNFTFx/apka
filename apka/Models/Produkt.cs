using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Kategoria")]
        public int IdKategoria { get; set; }
        [ForeignKey("Poziom")]
        public int IdPoziom { get; set; }
        [ForeignKey("Autor")]
        public int IdAutor { get; set; }
        [ForeignKey("Skladnik")]
        public int IdSkladnik { get; set; }

        public Produkt(string nazwa, string opis)
        {
            Nazwa = nazwa;
            Opis = opis;

        }
    }
}
