using System.ComponentModel.DataAnnotations;

namespace apka.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        [Required]
        public string Nazwa { get; set; }

        // DODANO: Domyślny konstruktor
        public Autor() { }

        public Autor(string nazwa)
        {
            Nazwa = nazwa;
        }
    }
}