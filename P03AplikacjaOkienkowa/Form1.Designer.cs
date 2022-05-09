namespace P03AplikacjaOkienkowa
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPolecenieSQL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAdresSerwera = new System.Windows.Forms.TextBox();
            this.txtNazwaBazy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUzytkownik = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHaslo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbWindowsAuth = new System.Windows.Forms.CheckBox();
            this.dgvDane = new System.Windows.Forms.DataGridView();
            this.btnWyslij = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPolecenieSQL
            // 
            this.txtPolecenieSQL.Location = new System.Drawing.Point(13, 89);
            this.txtPolecenieSQL.Name = "txtPolecenieSQL";
            this.txtPolecenieSQL.Size = new System.Drawing.Size(561, 20);
            this.txtPolecenieSQL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Polecenie SQL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Adres Serwera";
            // 
            // txtAdresSerwera
            // 
            this.txtAdresSerwera.Location = new System.Drawing.Point(12, 25);
            this.txtAdresSerwera.Name = "txtAdresSerwera";
            this.txtAdresSerwera.Size = new System.Drawing.Size(136, 20);
            this.txtAdresSerwera.TabIndex = 3;
            // 
            // txtNazwaBazy
            // 
            this.txtNazwaBazy.Location = new System.Drawing.Point(154, 25);
            this.txtNazwaBazy.Name = "txtNazwaBazy";
            this.txtNazwaBazy.Size = new System.Drawing.Size(136, 20);
            this.txtNazwaBazy.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nazwa bazy danych";
            // 
            // txtUzytkownik
            // 
            this.txtUzytkownik.Location = new System.Drawing.Point(296, 25);
            this.txtUzytkownik.Name = "txtUzytkownik";
            this.txtUzytkownik.Size = new System.Drawing.Size(136, 20);
            this.txtUzytkownik.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Uzytownik";
            // 
            // txtHaslo
            // 
            this.txtHaslo.Location = new System.Drawing.Point(438, 25);
            this.txtHaslo.Name = "txtHaslo";
            this.txtHaslo.Size = new System.Drawing.Size(136, 20);
            this.txtHaslo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(438, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Haslo";
            // 
            // chbWindowsAuth
            // 
            this.chbWindowsAuth.AutoSize = true;
            this.chbWindowsAuth.Location = new System.Drawing.Point(299, 52);
            this.chbWindowsAuth.Name = "chbWindowsAuth";
            this.chbWindowsAuth.Size = new System.Drawing.Size(140, 17);
            this.chbWindowsAuth.TabIndex = 10;
            this.chbWindowsAuth.Text = "Windows authentication";
            this.chbWindowsAuth.UseVisualStyleBackColor = true;
            this.chbWindowsAuth.CheckedChanged += new System.EventHandler(this.chbWindowsAuth_CheckedChanged);
            // 
            // dgvDane
            // 
            this.dgvDane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDane.Location = new System.Drawing.Point(12, 115);
            this.dgvDane.Name = "dgvDane";
            this.dgvDane.Size = new System.Drawing.Size(562, 368);
            this.dgvDane.TabIndex = 11;
            // 
            // btnWyslij
            // 
            this.btnWyslij.Location = new System.Drawing.Point(499, 65);
            this.btnWyslij.Name = "btnWyslij";
            this.btnWyslij.Size = new System.Drawing.Size(75, 23);
            this.btnWyslij.TabIndex = 12;
            this.btnWyslij.Text = "Wyślij";
            this.btnWyslij.UseVisualStyleBackColor = true;
            this.btnWyslij.Click += new System.EventHandler(this.btnWyslij_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 486);
            this.Controls.Add(this.btnWyslij);
            this.Controls.Add(this.dgvDane);
            this.Controls.Add(this.chbWindowsAuth);
            this.Controls.Add(this.txtHaslo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUzytkownik);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNazwaBazy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAdresSerwera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPolecenieSQL);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPolecenieSQL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAdresSerwera;
        private System.Windows.Forms.TextBox txtNazwaBazy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUzytkownik;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHaslo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbWindowsAuth;
        private System.Windows.Forms.DataGridView dgvDane;
        private System.Windows.Forms.Button btnWyslij;
    }
}

