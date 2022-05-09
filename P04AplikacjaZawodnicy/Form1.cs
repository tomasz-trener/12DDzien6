using P05AplikacjaZawodnicy.Core;
using P05AplikacjaZawodnicy.Core.Domains;
using P05AplikacjaZawodnicy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P04AplikacjaZawodnicy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            // Wersja1 : gdy nie korzyystmy z repoziytorium tylko bezposrednio w widoku odowlummy sie do bazy
            // co jest niepoprawne z punkwu widzenia architketury 
            //PolaczenieZBaza pzb = new PolaczenieZBaza();
            //object[][] wynik = pzb.WykonajPolecenieSQL("select * from zawodnicy");

            //dgvDane.Rows.Clear();
            //dgvDane.ColumnCount = wynik[0].Length;

            //for (int i = 0; i < wynik.Length; i++)
            //    dgvDane.Rows.Add(wynik[i]);

            ZawodnicyRepository zr = new ZawodnicyRepository();
            Zawodnik[] zawodnicy= zr.PodajZawodnikow();

            dgvDane.DataSource = zawodnicy; // dgv widzi domyslnie wszystkie wlasciwosci 
            


        }
    }
}
