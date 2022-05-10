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
    public class ZawodnicyRepository
    {

        public Zawodnik[] PodajZawodnikow(string wartosc = null)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();

            string sql = "SELECT id_zawodnika, id_trenera, imie, nazwisko, kraj, data_ur, wzrost, waga FROM zawodnicy";
            if (wartosc != null)
                sql += " where kraj like @wartosc or imie like @wartosc or nazwisko like @wartosc";

            object[][] wynik = pzb.WykonajPolecenieSQL(sql, new System.Data.SqlClient.SqlParameter() { ParameterName = "@wartosc", Value = "%" + wartosc + "%" });

            // transformacja object[][] na Zawodnik[] 
            return TransformujZawodnikow(wynik);
        }

        public Zawodnik[] PodajZawodnikowPoKraju(string kraj = null, int strona=1, int ile=5, string sortowanie="id_zawodnika")  
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();

            string sql = $@"SELECT id_zawodnika, id_trenera, imie, nazwisko, kraj, data_ur, wzrost, waga FROM zawodnicy
                           ORDER BY {sortowanie}
                           OFFSET     {(strona-1)*ile} ROWS       -- skip 10 rows
                           FETCH NEXT {ile} ROWS ONLY; -- take 10 rows";
            if (kraj != null)
                sql += " where kraj like @wartosc";
            object[][] wynik = pzb.WykonajPolecenieSQL(sql, new System.Data.SqlClient.SqlParameter() { ParameterName = "@wartosc", Value = "%" + kraj + "%" });

            // transformacja object[][] na Zawodnik[] 
            return TransformujZawodnikow(wynik);
        }

        private Zawodnik[] TransformujZawodnikow(object [][] wynik)
        {
            Zawodnik[] zawodnicy = new Zawodnik[wynik.Length];

            for (int i = 0; i < wynik.Length; i++)
            {
                Zawodnik ityZawodnik = new Zawodnik();
                ityZawodnik.Id = (int)wynik[i][0];

                if (wynik[i][1] != DBNull.Value) // null w c# to nie to samo co null w bazie. W bazie null jest oznaczony jako DBNull.Value
                    ityZawodnik.Id_trenera = (int)wynik[i][1];

                ityZawodnik.Imie = (string)wynik[i][2];
                ityZawodnik.Nazwisko = (string)wynik[i][3];
                ityZawodnik.Kraj = (string)wynik[i][4];
                if (wynik[i][5] != DBNull.Value)
                    ityZawodnik.DataUrodzenia = (DateTime)wynik[i][5];

                ityZawodnik.Wzrost = (int)wynik[i][6];
                ityZawodnik.Waga = (int)wynik[i][7];

                zawodnicy[i] = ityZawodnik;
            }
            return zawodnicy;
        }


        public int EdytujZawodnika(Zawodnik z)
        {
            string szablon = @"update zawodnicy set imie = '{0}', nazwisko = '{1}', kraj = '{2}', data_ur={3}, wzrost={4}, waga={5}                               output inserted.id_zawodnika                             where id_zawodnika = {6}";

            string sql =
                string.Format(szablon, z.Imie, z.Nazwisko, z.Kraj, z.DataUrodzenia == null ? "null" : "'" + z.DataUrodzenia.Value.ToString("yyyyMMdd") + "'", z.Wzrost, z.Waga, z.Id);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            object[][] wynik = pzb.WykonajPolecenieSQL(sql);

            if (wynik.Count() == 0)
                throw new RowNotExistingException("Edycja rekordu, który nie istnieje");

            return (int)wynik[0][0];
        }

        public int DodajZawodnika(Zawodnik z)
        {
            string szablon = @"insert into zawodnicy
                output inserted.id_zawodnika
                values (null,'{0}','{1}','{2}',{3},{4},{5})";

            string sql = string.Format(szablon, z.Imie, z.Nazwisko, z.Kraj, z.DataUrodzenia == null ? "null" : "'" + z.DataUrodzenia.Value.ToString("yyyyMMdd") + "'", z.Wzrost, z.Waga);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            object[][] wynik = pzb.WykonajPolecenieSQL(sql);
            return (int)wynik[0][0];
        }

        public void UsunZawodnika(Zawodnik z)
        {
            string szablon = "delete zawodnicy where id_zawodnika = {0}";

            string sql = string.Format(szablon, z.Id);

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajPolecenieSQL(sql);
        }

        public string[] PodajKraje()
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            var wynik= pzb.WykonajPolecenieSQL("select distinct kraj from zawodnicy");

            string[] kraje = new string[wynik.Length];
            for (int i = 0; i < kraje.Length; i++)
                kraje[i] = (string)wynik[i][0];

            return kraje;
        }
    }
}
