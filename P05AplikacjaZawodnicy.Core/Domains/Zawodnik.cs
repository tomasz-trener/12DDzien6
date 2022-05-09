using System;

namespace P05AplikacjaZawodnicy.Core.Domains
{
    public class Zawodnik
    {
        public int Id;
        public int? Id_trenera;
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Kraj { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public int Wzrost { get; set; }
        public int Waga { get; set; }

       
    }
}