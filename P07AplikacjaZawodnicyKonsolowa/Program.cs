using P05AplikacjaZawodnicy.Core.Domains;
using P05AplikacjaZawodnicy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07AplikacjaZawodnicyKonsolowa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZawodnicyRepository zr = new ZawodnicyRepository();
            Zawodnik[] z= zr.PodajZawodnikow();
            foreach (var iz in z)
                Console.WriteLine(iz.Imie + " " + iz.Nazwisko);

            Console.ReadKey();

            //https://github.com/tomasz-trener/12DDzien6
        }
    }
}
