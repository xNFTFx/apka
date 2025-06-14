using System.ComponentModel.DataAnnotations;

namespace apka.Models
{
    public class Kategoria
    {
        [Key]
        public int IdKategoria { get; set; }
        [Required]
        public string Nazwa { get; set; }

        // DODANO: Domyślny konstruktor
        public Kategoria() { }

        public Kategoria(string nazwa)
        {
            Nazwa = nazwa;
        }
    }
}