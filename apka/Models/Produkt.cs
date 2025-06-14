using System.ComponentModel.DataAnnotations;

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
        
        public Produkt(string nazwa, string opis)
        {
            Nazwa = nazwa;
            Opis = opis;

        }
    }
}
