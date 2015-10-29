namespace WinFormAppTest
{
    partial class NasokaForm
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
            this.panelAddNasoka = new System.Windows.Forms.Panel();
            this.btnDodadiNasoka = new System.Windows.Forms.Button();
            this.textBoxOpis_Nasoka_Add = new System.Windows.Forms.TextBox();
            this.textBoxIme_Nasoka_Add = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cBoxNasokiIzborEdit = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxID_Nasoka_Edit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnIzmeniNasoka = new System.Windows.Forms.Button();
            this.textBoxOpis_Nasoka_Edit = new System.Windows.Forms.TextBox();
            this.textBoxIme_Nasoka_Edit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPregledNasoki = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPregledIzborNasoki = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cBoxNasokiIzborAdd = new System.Windows.Forms.ComboBox();
            this.panelAddNasoka.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAddNasoka
            // 
            this.panelAddNasoka.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelAddNasoka.Controls.Add(this.cBoxNasokiIzborAdd);
            this.panelAddNasoka.Controls.Add(this.label13);
            this.panelAddNasoka.Controls.Add(this.btnDodadiNasoka);
            this.panelAddNasoka.Controls.Add(this.textBoxOpis_Nasoka_Add);
            this.panelAddNasoka.Controls.Add(this.textBoxIme_Nasoka_Add);
            this.panelAddNasoka.Controls.Add(this.label4);
            this.panelAddNasoka.Controls.Add(this.label2);
            this.panelAddNasoka.Controls.Add(this.label1);
            this.panelAddNasoka.Location = new System.Drawing.Point(12, 12);
            this.panelAddNasoka.Name = "panelAddNasoka";
            this.panelAddNasoka.Size = new System.Drawing.Size(253, 178);
            this.panelAddNasoka.TabIndex = 1;
            // 
            // btnDodadiNasoka
            // 
            this.btnDodadiNasoka.Location = new System.Drawing.Point(150, 138);
            this.btnDodadiNasoka.Name = "btnDodadiNasoka";
            this.btnDodadiNasoka.Size = new System.Drawing.Size(88, 35);
            this.btnDodadiNasoka.TabIndex = 7;
            this.btnDodadiNasoka.Text = "Додади";
            this.btnDodadiNasoka.UseVisualStyleBackColor = true;
            this.btnDodadiNasoka.Click += new System.EventHandler(this.btnDodadiNasoka_Click);
            // 
            // textBoxOpis_Nasoka_Add
            // 
            this.textBoxOpis_Nasoka_Add.Location = new System.Drawing.Point(91, 58);
            this.textBoxOpis_Nasoka_Add.Multiline = true;
            this.textBoxOpis_Nasoka_Add.Name = "textBoxOpis_Nasoka_Add";
            this.textBoxOpis_Nasoka_Add.Size = new System.Drawing.Size(135, 45);
            this.textBoxOpis_Nasoka_Add.TabIndex = 5;
            // 
            // textBoxIme_Nasoka_Add
            // 
            this.textBoxIme_Nasoka_Add.Location = new System.Drawing.Point(91, 26);
            this.textBoxIme_Nasoka_Add.Name = "textBoxIme_Nasoka_Add";
            this.textBoxIme_Nasoka_Add.Size = new System.Drawing.Size(135, 20);
            this.textBoxIme_Nasoka_Add.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Опис";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Име";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Додади Насока";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 222);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "STATUS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.cBoxNasokiIzborEdit);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textBoxID_Nasoka_Edit);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnIzmeniNasoka);
            this.panel2.Controls.Add(this.textBoxOpis_Nasoka_Edit);
            this.panel2.Controls.Add(this.textBoxIme_Nasoka_Edit);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(305, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 215);
            this.panel2.TabIndex = 7;
            // 
            // cBoxNasokiIzborEdit
            // 
            this.cBoxNasokiIzborEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxNasokiIzborEdit.FormattingEnabled = true;
            this.cBoxNasokiIzborEdit.Location = new System.Drawing.Point(96, 142);
            this.cBoxNasokiIzborEdit.Name = "cBoxNasokiIzborEdit";
            this.cBoxNasokiIzborEdit.Size = new System.Drawing.Size(135, 21);
            this.cBoxNasokiIzborEdit.TabIndex = 11;
            this.cBoxNasokiIzborEdit.SelectedIndexChanged += new System.EventHandler(this.cBoxNasokiIzborAdd_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 147);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Област";
            // 
            // textBoxID_Nasoka_Edit
            // 
            this.textBoxID_Nasoka_Edit.Location = new System.Drawing.Point(94, 25);
            this.textBoxID_Nasoka_Edit.Name = "textBoxID_Nasoka_Edit";
            this.textBoxID_Nasoka_Edit.Size = new System.Drawing.Size(40, 20);
            this.textBoxID_Nasoka_Edit.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "ID";
            // 
            // btnIzmeniNasoka
            // 
            this.btnIzmeniNasoka.Location = new System.Drawing.Point(155, 171);
            this.btnIzmeniNasoka.Name = "btnIzmeniNasoka";
            this.btnIzmeniNasoka.Size = new System.Drawing.Size(88, 35);
            this.btnIzmeniNasoka.TabIndex = 7;
            this.btnIzmeniNasoka.Text = "Измени";
            this.btnIzmeniNasoka.UseVisualStyleBackColor = true;
            this.btnIzmeniNasoka.Click += new System.EventHandler(this.btnIzmeniNasoka_Click);
            // 
            // textBoxOpis_Nasoka_Edit
            // 
            this.textBoxOpis_Nasoka_Edit.Location = new System.Drawing.Point(94, 83);
            this.textBoxOpis_Nasoka_Edit.Multiline = true;
            this.textBoxOpis_Nasoka_Edit.Name = "textBoxOpis_Nasoka_Edit";
            this.textBoxOpis_Nasoka_Edit.Size = new System.Drawing.Size(135, 47);
            this.textBoxOpis_Nasoka_Edit.TabIndex = 5;
            // 
            // textBoxIme_Nasoka_Edit
            // 
            this.textBoxIme_Nasoka_Edit.Location = new System.Drawing.Point(94, 51);
            this.textBoxIme_Nasoka_Edit.Name = "textBoxIme_Nasoka_Edit";
            this.textBoxIme_Nasoka_Edit.Size = new System.Drawing.Size(135, 20);
            this.textBoxIme_Nasoka_Edit.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Oпис";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Име";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Измени Насока";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Насоки Преглед";
            // 
            // panelPregledNasoki
            // 
            this.panelPregledNasoki.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPregledNasoki.Location = new System.Drawing.Point(9, 265);
            this.panelPregledNasoki.Name = "panelPregledNasoki";
            this.panelPregledNasoki.Size = new System.Drawing.Size(479, 170);
            this.panelPregledNasoki.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Насоки Избор Преглед";
            // 
            // panelPregledIzborNasoki
            // 
            this.panelPregledIzborNasoki.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPregledIzborNasoki.Location = new System.Drawing.Point(12, 464);
            this.panelPregledIzborNasoki.Name = "panelPregledIzborNasoki";
            this.panelPregledIzborNasoki.Size = new System.Drawing.Size(479, 170);
            this.panelPregledIzborNasoki.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Област";
            // 
            // cBoxNasokiIzborAdd
            // 
            this.cBoxNasokiIzborAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxNasokiIzborAdd.FormattingEnabled = true;
            this.cBoxNasokiIzborAdd.Location = new System.Drawing.Point(91, 112);
            this.cBoxNasokiIzborAdd.Name = "cBoxNasokiIzborAdd";
            this.cBoxNasokiIzborAdd.Size = new System.Drawing.Size(135, 21);
            this.cBoxNasokiIzborAdd.TabIndex = 9;
            this.cBoxNasokiIzborAdd.SelectedIndexChanged += new System.EventHandler(this.cBoxNasokiIzborAdd_SelectedIndexChanged);
            // 
            // NasokaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 637);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelPregledIzborNasoki);
            this.Controls.Add(this.panelPregledNasoki);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelAddNasoka);
            this.Name = "NasokaForm";
            this.Text = "NasokaForm";
            this.Load += new System.EventHandler(this.NasokaForm_Load);
            this.panelAddNasoka.ResumeLayout(false);
            this.panelAddNasoka.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAddNasoka;
        private System.Windows.Forms.Button btnDodadiNasoka;
        private System.Windows.Forms.TextBox textBoxOpis_Nasoka_Add;
        private System.Windows.Forms.TextBox textBoxIme_Nasoka_Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cBoxNasokiIzborEdit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxID_Nasoka_Edit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnIzmeniNasoka;
        private System.Windows.Forms.TextBox textBoxOpis_Nasoka_Edit;
        private System.Windows.Forms.TextBox textBoxIme_Nasoka_Edit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelPregledNasoki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelPregledIzborNasoki;
        private System.Windows.Forms.ComboBox cBoxNasokiIzborAdd;
        private System.Windows.Forms.Label label13;
    }
}