﻿namespace P04AplikacjaZawodnicy
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
            this.btnWczytaj = new System.Windows.Forms.Button();
            this.dgvDane = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWczytaj
            // 
            this.btnWczytaj.Location = new System.Drawing.Point(12, 12);
            this.btnWczytaj.Name = "btnWczytaj";
            this.btnWczytaj.Size = new System.Drawing.Size(108, 23);
            this.btnWczytaj.TabIndex = 0;
            this.btnWczytaj.Text = "Wczytaj";
            this.btnWczytaj.UseVisualStyleBackColor = true;
            this.btnWczytaj.Click += new System.EventHandler(this.btnWczytaj_Click);
            // 
            // dgvDane
            // 
            this.dgvDane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDane.Location = new System.Drawing.Point(12, 41);
            this.dgvDane.Name = "dgvDane";
            this.dgvDane.Size = new System.Drawing.Size(431, 397);
            this.dgvDane.TabIndex = 1;
            this.dgvDane.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDane_CellEndEdit);
   
            this.dgvDane.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDane_UserDeletingRow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 450);
            this.Controls.Add(this.dgvDane);
            this.Controls.Add(this.btnWczytaj);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWczytaj;
        private System.Windows.Forms.DataGridView dgvDane;
    }
}

