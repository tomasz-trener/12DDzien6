using P05AplikacjaZawodnicy.Core.Domains;
using P05AplikacjaZawodnicy.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Core.Repositories
{
    public class UzytkownicyRepository
    {
        public Uzytkownik Zaloguj(string nazwa, string haslo)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            string sql = "SELECT id, imie, nazwisko, nazwaUzytkownika, haslo from uzytkownicy where nazwaUzytkownika ='{0}' and haslo = '{1}' ";
            object[][] wynik =  pzb.WykonajPolecenieSQL(string.Format(sql,nazwa,haslo));

            if (wynik.Length == 0)
                return null;

            Uzytkownik u = new Uzytkownik();
            u.Id = (int)wynik[0][0];
            u.Imie = (string)wynik[0][1];
            u.Nazwisko = (string)wynik[0][2];
            u.NazwaUzytkownika = (string)wynik[0][3];
            u.Haslo = (string)wynik[0][4];

            return u;

        }
    }
}
