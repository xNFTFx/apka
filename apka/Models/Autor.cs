namespace apka.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public Autor(string nazwa)
        {
            Nazwa = nazwa;
        }
    }
}
