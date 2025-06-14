namespace apka.Models
{
    public class Alerge
    {
        [Key]
        public int IdAlergen { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public Alerge(string nazwa)
        {
            Nazwa = nazwa;
        }
        
        public Alerge() { } // Default constructor for EF Core
    }
}
