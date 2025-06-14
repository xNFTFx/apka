﻿using System.ComponentModel.DataAnnotations;

namespace apka.Models
{
    public class Poziom
    {
        [Key]
        public int IdPoziom { get; set; }
        [Required]
        public string Nazwa { get; set; }

        // DODANO: Domyślny konstruktor
        public Poziom() { }

        public Poziom(string nazwa)
        {
            Nazwa = nazwa;
        }
    }
}