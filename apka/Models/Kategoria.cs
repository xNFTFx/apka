using System.ComponentModel.DataAnnotations;
namespace apka.Models
{
    public class Kategoria
    {
        [Key]
        public int IdKategoria { get; set; }
        [Required]
        public string Nazwa { get; set; }

        public Kategoria(string nazwa)
        {
            Nazwa = nazwa;
        }

        public Kategoria() { } // Default constructor for EF Core
    }

}
