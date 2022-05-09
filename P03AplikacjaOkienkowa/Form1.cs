using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P03AplikacjaOkienkowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chbWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtUzytkownik.Enabled = !chbWindowsAuth.Checked;
            txtHaslo.Enabled = !chbWindowsAuth.Checked;
        }

        private void btnWyslij_Click(object sender, EventArgs e)
        {
            PolaczenieZBaza pzb;
            if (chbWindowsAuth.Checked)
                pzb = new PolaczenieZBaza(txtAdresSerwera.Text,txtNazwaBazy.Text);
            else
                pzb = new PolaczenieZBaza(txtAdresSerwera.Text, txtNazwaBazy.Text, txtUzytkownik.Text, txtHaslo.Text);

            object[][] wynik=  pzb.WykonajPolecenieSQL(txtPolecenieSQL.Text);

            dgvDane.Rows.Clear();
            dgvDane.ColumnCount = wynik[0].Length;

            for (int i = 0; i < wynik.Length; i++)
                dgvDane.Rows.Add(wynik[i]);

        }
    }
}
