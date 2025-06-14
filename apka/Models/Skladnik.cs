using System.ComponentModel.DataAnnotations;

namespace apka.Models
{
    public class Skladnik
    {
        [Key]
        public int IdSkladnik { get; set; }
        [Required]
        public string Nazwa { get; set; }

        // DODANO: Domyślny konstruktor
        public Skladnik() { }

        public Skladnik(string nazwa)
        {
            Nazwa = nazwa;
        }
    }
}