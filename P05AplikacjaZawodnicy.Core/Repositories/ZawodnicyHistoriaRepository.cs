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
    enum TypOperacjiBazodanowej
    {
        Dodanie =1,
        Edycja =2,
        Usuwanie =3
    }
    internal class ZawodnicyHistoriaRepository
    { 
        public void DodajHistorieZawodnika(Zawodnik z, TypOperacjiBazodanowej typOperacjiBazodanowej, int idUzytkownika = 0)
        {
            string szablon = @"insert into zawodnicyHistoria
                ( [id_trenera], imie, nazwisko,kraj,data_ur,waga,wzrost,idUzytkownika,typOperacji , id_zawodnika)
                values (null,'{0}','{1}','{2}',{3},{4},{5},{6},{7},{8})";

            string sql = string.Format(szablon,
                z.Imie, z.Nazwisko, z.Kraj, z.DataUrodzenia == null ? "null" : "'" + z.DataUrodzenia.Value.ToString("yyyyMMdd") + "'", z.Wzrost, z.Waga,
                idUzytkownika, (int)typOperacjiBazodanowej, z.Id
                );

            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajPolecenieSQL(sql);   
        }

       
    }
}
