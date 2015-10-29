namespace WinFormAppTest
{
    partial class DelZaPredmetPoNasokaForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxInstitucija_Add = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cBoxNasokiIzbor = new System.Windows.Forms.ComboBox();
            this.cBoxUstanoviIzbor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxOblastiIzborAdd = new System.Windows.Forms.ComboBox();
            this.panelInfoPredmetNasoka = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.listBoxPostoeckiPredmeti = new System.Windows.Forms.ListBox();
            this.panelInfoNasoka = new System.Windows.Forms.Panel();
            this.txtBoxNasokaOpis_Pregled = new System.Windows.Forms.TextBox();
            this.lblNasokaIme = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDodadiDelZaPredmetPoNasoka = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxDelovi = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxIzborPredmetPoNasoka = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panelInfoPredmetNasoka.SuspendLayout();
            this.panelInfoNasoka.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = " Избор на Насока";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBoxInstitucija_Add);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cBoxNasokiIzbor);
            this.panel1.Controls.Add(this.cBoxUstanoviIzbor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cBoxOblastiIzborAdd);
            this.panel1.Location = new System.Drawing.Point(21, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 155);
            this.panel1.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(298, 9);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(142, 73);
            this.textBox1.TabIndex = 18;
            this.textBox1.Text = "Во овој дел се избира насока. Насоката ни е главен елемент во кои ги врзуваме пре" +
                "дметите. Избери Насока";
            // 
            // comboBoxInstitucija_Add
            // 
            this.comboBoxInstitucija_Add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstitucija_Add.FormattingEnabled = true;
            this.comboBoxInstitucija_Add.Location = new System.Drawing.Point(98, 9);
            this.comboBoxInstitucija_Add.Name = "comboBoxInstitucija_Add";
            this.comboBoxInstitucija_Add.Size = new System.Drawing.Size(169, 21);
            this.comboBoxInstitucija_Add.TabIndex = 11;
            this.comboBoxInstitucija_Add.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstitucija_Add_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Институција";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Установа";
            // 
            // cBoxNasokiIzbor
            // 
            this.cBoxNasokiIzbor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxNasokiIzbor.FormattingEnabled = true;
            this.cBoxNasokiIzbor.Location = new System.Drawing.Point(98, 122);
            this.cBoxNasokiIzbor.Name = "cBoxNasokiIzbor";
            this.cBoxNasokiIzbor.Size = new System.Drawing.Size(169, 21);
            this.cBoxNasokiIzbor.TabIndex = 17;
            this.cBoxNasokiIzbor.SelectedIndexChanged += new System.EventHandler(this.cBoxNasokiIzbor_SelectedIndexChanged);
            // 
            // cBoxUstanoviIzbor
            // 
            this.cBoxUstanoviIzbor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUstanoviIzbor.FormattingEnabled = true;
            this.cBoxUstanoviIzbor.Location = new System.Drawing.Point(98, 47);
            this.cBoxUstanoviIzbor.Name = "cBoxUstanoviIzbor";
            this.cBoxUstanoviIzbor.Size = new System.Drawing.Size(169, 21);
            this.cBoxUstanoviIzbor.TabIndex = 13;
            this.cBoxUstanoviIzbor.SelectedIndexChanged += new System.EventHandler(this.cBoxUstanoviIzbor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Насока";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Област";
            // 
            // cBoxOblastiIzborAdd
            // 
            this.cBoxOblastiIzborAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxOblastiIzborAdd.FormattingEnabled = true;
            this.cBoxOblastiIzborAdd.Location = new System.Drawing.Point(98, 84);
            this.cBoxOblastiIzborAdd.Name = "cBoxOblastiIzborAdd";
            this.cBoxOblastiIzborAdd.Size = new System.Drawing.Size(169, 21);
            this.cBoxOblastiIzborAdd.TabIndex = 15;
            this.cBoxOblastiIzborAdd.SelectedIndexChanged += new System.EventHandler(this.cBoxOblastiIzborAdd_SelectedIndexChanged);
            // 
            // panelInfoPredmetNasoka
            // 
            this.panelInfoPredmetNasoka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfoPredmetNasoka.Controls.Add(this.label14);
            this.panelInfoPredmetNasoka.Controls.Add(this.listBoxPostoeckiPredmeti);
            this.panelInfoPredmetNasoka.Location = new System.Drawing.Point(226, 201);
            this.panelInfoPredmetNasoka.Name = "panelInfoPredmetNasoka";
            this.panelInfoPredmetNasoka.Size = new System.Drawing.Size(243, 132);
            this.panelInfoPredmetNasoka.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Инфо Предмети по Насока";
            // 
            // listBoxPostoeckiPredmeti
            // 
            this.listBoxPostoeckiPredmeti.Enabled = false;
            this.listBoxPostoeckiPredmeti.FormattingEnabled = true;
            this.listBoxPostoeckiPredmeti.Location = new System.Drawing.Point(7, 20);
            this.listBoxPostoeckiPredmeti.Name = "listBoxPostoeckiPredmeti";
            this.listBoxPostoeckiPredmeti.Size = new System.Drawing.Size(214, 108);
            this.listBoxPostoeckiPredmeti.TabIndex = 1;
            // 
            // panelInfoNasoka
            // 
            this.panelInfoNasoka.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfoNasoka.Controls.Add(this.txtBoxNasokaOpis_Pregled);
            this.panelInfoNasoka.Controls.Add(this.lblNasokaIme);
            this.panelInfoNasoka.Controls.Add(this.label4);
            this.panelInfoNasoka.Location = new System.Drawing.Point(21, 201);
            this.panelInfoNasoka.Name = "panelInfoNasoka";
            this.panelInfoNasoka.Size = new System.Drawing.Size(199, 132);
            this.panelInfoNasoka.TabIndex = 23;
            // 
            // txtBoxNasokaOpis_Pregled
            // 
            this.txtBoxNasokaOpis_Pregled.Location = new System.Drawing.Point(5, 48);
            this.txtBoxNasokaOpis_Pregled.Multiline = true;
            this.txtBoxNasokaOpis_Pregled.Name = "txtBoxNasokaOpis_Pregled";
            this.txtBoxNasokaOpis_Pregled.ReadOnly = true;
            this.txtBoxNasokaOpis_Pregled.Size = new System.Drawing.Size(187, 71);
            this.txtBoxNasokaOpis_Pregled.TabIndex = 2;
            // 
            // lblNasokaIme
            // 
            this.lblNasokaIme.AutoSize = true;
            this.lblNasokaIme.Location = new System.Drawing.Point(9, 29);
            this.lblNasokaIme.Name = "lblNasokaIme";
            this.lblNasokaIme.Size = new System.Drawing.Size(0, 13);
            this.lblNasokaIme.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Инфо за Насока";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 548);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 13);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "STATUS";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnDodadiDelZaPredmetPoNasoka);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.listBoxDelovi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cBoxIzborPredmetPoNasoka);
            this.panel2.Location = new System.Drawing.Point(268, 339);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 206);
            this.panel2.TabIndex = 26;
            // 
            // btnDodadiDelZaPredmetPoNasoka
            // 
            this.btnDodadiDelZaPredmetPoNasoka.Location = new System.Drawing.Point(106, 172);
            this.btnDodadiDelZaPredmetPoNasoka.Name = "btnDodadiDelZaPredmetPoNasoka";
            this.btnDodadiDelZaPredmetPoNasoka.Size = new System.Drawing.Size(75, 23);
            this.btnDodadiDelZaPredmetPoNasoka.TabIndex = 4;
            this.btnDodadiDelZaPredmetPoNasoka.Text = "Додади";
            this.btnDodadiDelZaPredmetPoNasoka.UseVisualStyleBackColor = true;
            this.btnDodadiDelZaPredmetPoNasoka.Click += new System.EventHandler(this.btnDodadiDelZaPredmetPoNasoka_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Избери Дел(Реализација)";
            // 
            // listBoxDelovi
            // 
            this.listBoxDelovi.FormattingEnabled = true;
            this.listBoxDelovi.Location = new System.Drawing.Point(6, 69);
            this.listBoxDelovi.Name = "listBoxDelovi";
            this.listBoxDelovi.Size = new System.Drawing.Size(175, 95);
            this.listBoxDelovi.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Изберете Предмет";
            // 
            // cBoxIzborPredmetPoNasoka
            // 
            this.cBoxIzborPredmetPoNasoka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxIzborPredmetPoNasoka.FormattingEnabled = true;
            this.cBoxIzborPredmetPoNasoka.Location = new System.Drawing.Point(6, 21);
            this.cBoxIzborPredmetPoNasoka.Name = "cBoxIzborPredmetPoNasoka";
            this.cBoxIzborPredmetPoNasoka.Size = new System.Drawing.Size(175, 21);
            this.cBoxIzborPredmetPoNasoka.TabIndex = 0;
            // 
            // DelZaPredmetPoNasokaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 583);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelInfoPredmetNasoka);
            this.Controls.Add(this.panelInfoNasoka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "DelZaPredmetPoNasokaForm";
            this.Text = "DelZaPredmetPoNasokaForm";
            this.Load += new System.EventHandler(this.DelZaPredmetPoNasokaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelInfoPredmetNasoka.ResumeLayout(false);
            this.panelInfoPredmetNasoka.PerformLayout();
            this.panelInfoNasoka.ResumeLayout(false);
            this.panelInfoNasoka.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxInstitucija_Add;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cBoxNasokiIzbor;
        private System.Windows.Forms.ComboBox cBoxUstanoviIzbor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxOblastiIzborAdd;
        private System.Windows.Forms.Panel panelInfoPredmetNasoka;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBoxPostoeckiPredmeti;
        private System.Windows.Forms.Panel panelInfoNasoka;
        private System.Windows.Forms.TextBox txtBoxNasokaOpis_Pregled;
        private System.Windows.Forms.Label lblNasokaIme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cBoxIzborPredmetPoNasoka;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxDelovi;
        private System.Windows.Forms.Button btnDodadiDelZaPredmetPoNasoka;

    }
}