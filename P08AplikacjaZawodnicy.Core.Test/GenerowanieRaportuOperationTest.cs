using Microsoft.VisualStudio.TestTools.UnitTesting;
using P05AplikacjaZawodnicy.Core.Domains;
using P05AplikacjaZawodnicy.Core.Operations;
using System;
using System.IO;

namespace P08AplikacjaZawodnicy.Core.Test
{
    [TestClass]
    public class GenerowanieRaportuOperationTest
    {
        [TestMethod]
        public void GenerujRaportWszystkichZawodnikow()
        {
            GenerowanieRaportuOperation zro = new GenerowanieRaportuOperation();

            // testy jednostke testuja jak najmniejszy kawalek kodu 

            Zawodnik[] zawodnicy = new Zawodnik[3] 
            {
                new Zawodnik() { Imie ="Jan", Kraj = "POL"},
                new Zawodnik() { Imie ="Jan", Nazwisko="Kowalsi", Kraj = "POL"},
                new Zawodnik() { Imie ="Jan",Nazwisko="Kowalsi", Kraj = "GER"},
            };

          //  Guid.NewGuid().ToString()
            zro.GenerujRaport(zawodnicy,"Raport1.pdf");

            bool wynik= File.Exists("Raport1.pdf");

            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void GenerujRaportTylkoPolacy()
        {
            GenerowanieRaportuOperation zro = new GenerowanieRaportuOperation();

            // testy jednostke testuja jak najmniejszy kawalek kodu 

            Zawodnik[] zawodnicy = new Zawodnik[3]
            {
                new Zawodnik() { Imie ="pJan", Kraj = "POL"},
                new Zawodnik() { Imie ="pJan", Nazwisko="Kowalsi", Kraj = "POL"},
                new Zawodnik() { Imie ="pJan",Nazwisko="Kowalsi", Kraj = "POL"},
            };
            zro.GenerujRaport(zawodnicy, "Raport2.pdf");
            bool wynik = File.Exists("Raport2.pdf");

            Assert.IsTrue(wynik);
        }

        [TestMethod]
        public void GenerujRaportTylkoNiemcy()
        {
            GenerowanieRaportuOperation zro = new GenerowanieRaportuOperation();

            // testy jednostke testuja jak najmniejszy kawalek kodu 

            Zawodnik[] zawodnicy = new Zawodnik[3]
            {
                new Zawodnik() { Imie ="gJan", Kraj = "GER"},
                new Zawodnik() { Imie ="gJan", Nazwisko="Kowalsi", Kraj = "GER"},
                new Zawodnik() { Imie ="gJan",Nazwisko="Kowalsi", Kraj = "GER"},
            };
            zro.GenerujRaport(zawodnicy, "Raport3.pdf");
            bool wynik = File.Exists("Raport4.pdf");

            Assert.IsTrue(wynik);
        }
    }
}
