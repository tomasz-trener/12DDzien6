using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Core.Domains
{
    public class Trener
    {
        public int Id;
        public string Imie;
        public string Nazwisko;
        public DateTime? DataUrodzenia;

        public string WartoscWyswietlana { 
            get 
            {
                if (Id > 0)
                    return Imie + " " + Nazwisko;
                else
                    return "Brak";
            } 
        }
    }
}
