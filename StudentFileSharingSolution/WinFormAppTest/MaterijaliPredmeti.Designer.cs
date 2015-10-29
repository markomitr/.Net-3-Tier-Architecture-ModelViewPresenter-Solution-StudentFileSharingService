namespace WinFormAppTest
{
    partial class MaterijaliPredmeti
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxMaterijaliPredmet = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnMaterijalPredmetAdd = new System.Windows.Forms.Button();
            this.listBoxMaterijaliPregled = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.listBoxDeloviNasoka = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.listBoxPredmeti = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 21);
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
            this.panel1.Location = new System.Drawing.Point(9, 42);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.listBoxMaterijaliPredmet);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.btnMaterijalPredmetAdd);
            this.panel2.Controls.Add(this.listBoxMaterijaliPregled);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.listBoxDeloviNasoka);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.listBoxPredmeti);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(9, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(898, 394);
            this.panel2.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Материјали за Предмет/Дел";
            // 
            // listBoxMaterijaliPredmet
            // 
            this.listBoxMaterijaliPredmet.FormattingEnabled = true;
            this.listBoxMaterijaliPredmet.Location = new System.Drawing.Point(209, 228);
            this.listBoxMaterijaliPredmet.Name = "listBoxMaterijaliPredmet";
            this.listBoxMaterijaliPredmet.Size = new System.Drawing.Size(369, 147);
            this.listBoxMaterijaliPredmet.TabIndex = 32;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 381);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 13);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "STATUS";
            // 
            // btnMaterijalPredmetAdd
            // 
            this.btnMaterijalPredmetAdd.BackColor = System.Drawing.Color.White;
            this.btnMaterijalPredmetAdd.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnMaterijalPredmetAdd.FlatAppearance.BorderSize = 2;
            this.btnMaterijalPredmetAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterijalPredmetAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterijalPredmetAdd.Location = new System.Drawing.Point(789, 153);
            this.btnMaterijalPredmetAdd.Name = "btnMaterijalPredmetAdd";
            this.btnMaterijalPredmetAdd.Size = new System.Drawing.Size(92, 47);
            this.btnMaterijalPredmetAdd.TabIndex = 31;
            this.btnMaterijalPredmetAdd.Text = "Додади Материјал";
            this.btnMaterijalPredmetAdd.UseVisualStyleBackColor = false;
            this.btnMaterijalPredmetAdd.Click += new System.EventHandler(this.btnMaterijalPredmetAdd_Click);
            // 
            // listBoxMaterijaliPregled
            // 
            this.listBoxMaterijaliPregled.FormattingEnabled = true;
            this.listBoxMaterijaliPregled.Location = new System.Drawing.Point(414, 53);
            this.listBoxMaterijaliPregled.Name = "listBoxMaterijaliPregled";
            this.listBoxMaterijaliPregled.Size = new System.Drawing.Size(369, 147);
            this.listBoxMaterijaliPregled.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(411, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Избeри Материјал";
            // 
            // listBoxDeloviNasoka
            // 
            this.listBoxDeloviNasoka.FormattingEnabled = true;
            this.listBoxDeloviNasoka.Location = new System.Drawing.Point(209, 53);
            this.listBoxDeloviNasoka.Name = "listBoxDeloviNasoka";
            this.listBoxDeloviNasoka.Size = new System.Drawing.Size(187, 147);
            this.listBoxDeloviNasoka.TabIndex = 28;
            this.listBoxDeloviNasoka.SelectedIndexChanged += new System.EventHandler(this.listBoxDeloviNasoka_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(209, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Избeри Дел";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Избeри Предмет";
            // 
            // listBoxPredmeti
            // 
            this.listBoxPredmeti.FormattingEnabled = true;
            this.listBoxPredmeti.Location = new System.Drawing.Point(16, 53);
            this.listBoxPredmeti.Name = "listBoxPredmeti";
            this.listBoxPredmeti.Size = new System.Drawing.Size(187, 147);
            this.listBoxPredmeti.TabIndex = 25;
            this.listBoxPredmeti.SelectedIndexChanged += new System.EventHandler(this.listBoxPredmetiMaterijal_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Додади Материјал на Предмет";
            // 
            // MaterijaliPredmeti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 609);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "MaterijaliPredmeti";
            this.Text = "MaterijaliPredmeti";
            this.Load += new System.EventHandler(this.MaterijaliPredmeti_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListBox listBoxDeloviNasoka;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBoxPredmeti;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox listBoxMaterijaliPregled;
        private System.Windows.Forms.Button btnMaterijalPredmetAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxMaterijaliPredmet;

    }
}