using P05AplikacjaZawodnicy.Core.Domains;
using P05AplikacjaZawodnicy.Core.Errors;
using P05AplikacjaZawodnicy.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Core.Repositories
{
    public class TrenerzyRepository
    {

        public Trener[] PodajTrenerow(string wartosc = null)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();

            string sql = "SELECT id_trenera, imie_t, nazwisko_t, data_ur_t, FROM trenerzy";
            if (wartosc != null)
                sql += " where imie_t like @wartosc or nazwisko_t like @wartosc";

            object[][] wynik = pzb.WykonajPolecenieSQL(sql, new System.Data.SqlClient.SqlParameter() { ParameterName = "@wartosc", Value = "%" + wartosc + "%" });

            // transformacja object[][] na Zawodnik[] 
            return TransformujTrenerow(wynik); 
        }
    
        private Trener[] TransformujTrenerow(object [][] wynik)
        {
            Trener[] trenerzy = new Trener[wynik.Length];

            for (int i = 0; i < wynik.Length; i++)
            {
                Trener ityTrener = new Trener();
                ityTrener.Id = (int)wynik[i][0];

                ityTrener.Imie = (string)wynik[i][1];
                ityTrener.Nazwisko = (string)wynik[i][2];
    
                if (wynik[i][3] != DBNull.Value)
                    ityTrener.DataUrodzenia = (DateTime)wynik[i][3];

                trenerzy[i] = ityTrener;
            }
            return trenerzy;
        }


        public int EdytujTrenera(Trener t, Uzytkownik zalogowany)
        {
            string szablon = @"update trenerzy set imie_t = '{0}', nazwisko_t = '{1}', data_ur={2} output inserted.id_trenera where id_trenera = {3}";

            string sql =
                string.Format(szablon, t.Imie, t.Nazwisko, t.DataUrodzenia == null ? "null" : "'" + t.DataUrodzenia.Value.ToString("yyyyMMdd") + "'", t.Id);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            object[][] wynik = pzb.WykonajPolecenieSQL(sql);

          //  ZawodnicyHistoriaRepository zhr = new ZawodnicyHistoriaRepository();
          //  zhr.DodajHistorieZawodnika(z,TypOperacjiBazodanowej.Edycja, zalogowany.Id);

            if (wynik.Count() == 0)
                throw new RowNotExistingException("Edycja rekordu, który nie istnieje");

            return (int)wynik[0][0];
        }

        public int DodajTrenera(Trener t, Uzytkownik zalogowany)
        {
            string szablon = @"insert into trenerzy
                output inserted.id_trenera
                values ('{0}','{1}','{2}')";

            string sql = string.Format(szablon, t.Imie, t.Nazwisko, t.DataUrodzenia == null ? "null" : "'" + t.DataUrodzenia.Value.ToString("yyyyMMdd") + "'");

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            object[][] wynik = pzb.WykonajPolecenieSQL(sql);
            int idNowoDodanegoZawodnika = (int)wynik[0][0];
            t.Id = idNowoDodanegoZawodnika;

            //ZawodnicyHistoriaRepository zhr = new ZawodnicyHistoriaRepository();
            //zhr.DodajHistorieZawodnika(z, TypOperacjiBazodanowej.Dodanie, zalogowany.Id);

            return idNowoDodanegoZawodnika;
        }
         
        public void UsunTrenera(Trener t, Uzytkownik zalogowany)
        {
            string szablon = "delete trenerzy where id_trenera = {0}";

            string sql = string.Format(szablon, t.Id);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajPolecenieSQL(sql);

            //ZawodnicyHistoriaRepository zhr = new ZawodnicyHistoriaRepository();
            //zhr.DodajHistorieZawodnika(t, TypOperacjiBazodanowej.Usuwanie, zalogowany.Id);
        }    
    }
}
