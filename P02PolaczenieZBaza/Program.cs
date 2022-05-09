using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02PolaczenieZBaza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            var wynik= pzb.WykonajPolecenieSQL("select * from miasta");

            for (int i = 0; i < wynik.Length; i++)
                Console.WriteLine(string.Join(" ", wynik[i]));

            Console.ReadKey();
        }
    }
}
