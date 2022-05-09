using P05AplikacjaZawodnicy.Core;
using P05AplikacjaZawodnicy.Core.Domains;
using P05AplikacjaZawodnicy.Core.Errors;
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

            // żeby datagridview miał mozliwosc dodwania i usuwania rekordow 
            // musimy dodac warstwe posredniczaca pomiedzy danymi a grdview 
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

            try
            {
                Zawodnik[] zawodnicy = zr.PodajZawodnikow();

                BindingSource bs = new BindingSource();
                bs.AllowNew = true;
                bs.DataSource = zawodnicy.ToList();

                dgvDane.DataSource = bs; // dgv widzi domyslnie wszystkie wlasciwosci 
                dgvDane.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad polaczenia z baza");
            }
            


        }

        private void dgvDane_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int edytowanyWiersz = e.RowIndex;
            Zawodnik zmieniany = (Zawodnik)dgvDane.Rows[edytowanyWiersz].DataBoundItem;

            ZawodnicyRepository zr = new ZawodnicyRepository();

            try
            {
                if (zmieniany.Id > 0)
                    zr.EdytujZawodnika(zmieniany);
                else
                    zmieniany.Id = zr.DodajZawodnika(zmieniany);
            }
            catch (RowNotExistingException ex)
            {
                // MessageBox.Show(ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Edytujsz rekord, ktory nie istnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nieznany błąd", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void dgvDane_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Zawodnik usuwany = (Zawodnik)e.Row.DataBoundItem;

            ZawodnicyRepository zr = new ZawodnicyRepository();
            zr.UsunZawodnika(usuwany);
        }
    }
}
