namespace WinFormAppTest
{
    partial class OblastForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBoxUstanoviIzbor = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDodadiOblast = new System.Windows.Forms.Button();
            this.textBoxWeb_Oblast = new System.Windows.Forms.TextBox();
            this.textBoxAdresa_Oblast = new System.Windows.Forms.TextBox();
            this.textBoxIme_Oblast = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelPregledOblasti = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPregledOblastiIZbor = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cBoxUstanoviIzborEdit = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxID_Oblast_Edit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnIzmeniOblast = new System.Windows.Forms.Button();
            this.textBoxWeb_Oblast_Edit = new System.Windows.Forms.TextBox();
            this.textBoxAdresa_Oblast_Edit = new System.Windows.Forms.TextBox();
            this.textBoxIme_Oblast_Edit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.cBoxUstanoviIzbor);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnDodadiOblast);
            this.panel1.Controls.Add(this.textBoxWeb_Oblast);
            this.panel1.Controls.Add(this.textBoxAdresa_Oblast);
            this.panel1.Controls.Add(this.textBoxIme_Oblast);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 178);
            this.panel1.TabIndex = 0;
            // 
            // cBoxUstanoviIzbor
            // 
            this.cBoxUstanoviIzbor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUstanoviIzbor.FormattingEnabled = true;
            this.cBoxUstanoviIzbor.Location = new System.Drawing.Point(91, 118);
            this.cBoxUstanoviIzbor.Name = "cBoxUstanoviIzbor";
            this.cBoxUstanoviIzbor.Size = new System.Drawing.Size(135, 21);
            this.cBoxUstanoviIzbor.TabIndex = 9;
            this.cBoxUstanoviIzbor.SelectedIndexChanged += new System.EventHandler(this.cBoxUstanoviIzbor_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Установа";
            // 
            // btnDodadiOblast
            // 
            this.btnDodadiOblast.Location = new System.Drawing.Point(139, 140);
            this.btnDodadiOblast.Name = "btnDodadiOblast";
            this.btnDodadiOblast.Size = new System.Drawing.Size(88, 35);
            this.btnDodadiOblast.TabIndex = 7;
            this.btnDodadiOblast.Text = "Додади";
            this.btnDodadiOblast.UseVisualStyleBackColor = true;
            this.btnDodadiOblast.Click += new System.EventHandler(this.btnDodadiOblast_Click);
            // 
            // textBoxWeb_Oblast
            // 
            this.textBoxWeb_Oblast.Location = new System.Drawing.Point(91, 89);
            this.textBoxWeb_Oblast.Name = "textBoxWeb_Oblast";
            this.textBoxWeb_Oblast.Size = new System.Drawing.Size(135, 20);
            this.textBoxWeb_Oblast.TabIndex = 6;
            // 
            // textBoxAdresa_Oblast
            // 
            this.textBoxAdresa_Oblast.Location = new System.Drawing.Point(91, 58);
            this.textBoxAdresa_Oblast.Name = "textBoxAdresa_Oblast";
            this.textBoxAdresa_Oblast.Size = new System.Drawing.Size(135, 20);
            this.textBoxAdresa_Oblast.TabIndex = 5;
            // 
            // textBoxIme_Oblast
            // 
            this.textBoxIme_Oblast.Location = new System.Drawing.Point(91, 26);
            this.textBoxIme_Oblast.Name = "textBoxIme_Oblast";
            this.textBoxIme_Oblast.Size = new System.Drawing.Size(135, 20);
            this.textBoxIme_Oblast.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Адреса";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Веб Страна";
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
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Додади Област";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 199);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 13);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "STATUS";
            // 
            // panelPregledOblasti
            // 
            this.panelPregledOblasti.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPregledOblasti.Location = new System.Drawing.Point(13, 234);
            this.panelPregledOblasti.Name = "panelPregledOblasti";
            this.panelPregledOblasti.Size = new System.Drawing.Size(479, 170);
            this.panelPregledOblasti.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Области Преглед";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Области Преглед Избор";
            // 
            // panelPregledOblastiIZbor
            // 
            this.panelPregledOblastiIZbor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPregledOblastiIZbor.Location = new System.Drawing.Point(13, 445);
            this.panelPregledOblastiIZbor.Name = "panelPregledOblastiIZbor";
            this.panelPregledOblastiIZbor.Size = new System.Drawing.Size(479, 170);
            this.panelPregledOblastiIZbor.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.cBoxUstanoviIzborEdit);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textBoxID_Oblast_Edit);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnIzmeniOblast);
            this.panel2.Controls.Add(this.textBoxWeb_Oblast_Edit);
            this.panel2.Controls.Add(this.textBoxAdresa_Oblast_Edit);
            this.panel2.Controls.Add(this.textBoxIme_Oblast_Edit);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(295, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 215);
            this.panel2.TabIndex = 6;
            // 
            // cBoxUstanoviIzborEdit
            // 
            this.cBoxUstanoviIzborEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUstanoviIzborEdit.FormattingEnabled = true;
            this.cBoxUstanoviIzborEdit.Location = new System.Drawing.Point(96, 142);
            this.cBoxUstanoviIzborEdit.Name = "cBoxUstanoviIzborEdit";
            this.cBoxUstanoviIzborEdit.Size = new System.Drawing.Size(135, 21);
            this.cBoxUstanoviIzborEdit.TabIndex = 11;
            this.cBoxUstanoviIzborEdit.SelectedIndexChanged += new System.EventHandler(this.cBoxUstanoviIzbor_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 147);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Установа";
            // 
            // textBoxID_Oblast_Edit
            // 
            this.textBoxID_Oblast_Edit.Location = new System.Drawing.Point(94, 25);
            this.textBoxID_Oblast_Edit.Name = "textBoxID_Oblast_Edit";
            this.textBoxID_Oblast_Edit.Size = new System.Drawing.Size(40, 20);
            this.textBoxID_Oblast_Edit.TabIndex = 9;
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
            // btnIzmeniOblast
            // 
            this.btnIzmeniOblast.Location = new System.Drawing.Point(155, 171);
            this.btnIzmeniOblast.Name = "btnIzmeniOblast";
            this.btnIzmeniOblast.Size = new System.Drawing.Size(88, 35);
            this.btnIzmeniOblast.TabIndex = 7;
            this.btnIzmeniOblast.Text = "Измени";
            this.btnIzmeniOblast.UseVisualStyleBackColor = true;
            this.btnIzmeniOblast.Click += new System.EventHandler(this.btnIzmeniOblast_Click);
            // 
            // textBoxWeb_Oblast_Edit
            // 
            this.textBoxWeb_Oblast_Edit.Location = new System.Drawing.Point(94, 114);
            this.textBoxWeb_Oblast_Edit.Name = "textBoxWeb_Oblast_Edit";
            this.textBoxWeb_Oblast_Edit.Size = new System.Drawing.Size(135, 20);
            this.textBoxWeb_Oblast_Edit.TabIndex = 6;
            // 
            // textBoxAdresa_Oblast_Edit
            // 
            this.textBoxAdresa_Oblast_Edit.Location = new System.Drawing.Point(94, 83);
            this.textBoxAdresa_Oblast_Edit.Name = "textBoxAdresa_Oblast_Edit";
            this.textBoxAdresa_Oblast_Edit.Size = new System.Drawing.Size(135, 20);
            this.textBoxAdresa_Oblast_Edit.TabIndex = 5;
            // 
            // textBoxIme_Oblast_Edit
            // 
            this.textBoxIme_Oblast_Edit.Location = new System.Drawing.Point(94, 51);
            this.textBoxIme_Oblast_Edit.Name = "textBoxIme_Oblast_Edit";
            this.textBoxIme_Oblast_Edit.Size = new System.Drawing.Size(135, 20);
            this.textBoxIme_Oblast_Edit.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Адреса";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Веб Страна";
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
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Измени Област";
            // 
            // OblastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 650);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelPregledOblastiIZbor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelPregledOblasti);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Name = "OblastForm";
            this.Text = "OblastForm";
            this.Load += new System.EventHandler(this.OblastForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxWeb_Oblast;
        private System.Windows.Forms.TextBox textBoxAdresa_Oblast;
        private System.Windows.Forms.TextBox textBoxIme_Oblast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodadiOblast;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelPregledOblasti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelPregledOblastiIZbor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnIzmeniOblast;
        private System.Windows.Forms.TextBox textBoxWeb_Oblast_Edit;
        private System.Windows.Forms.TextBox textBoxAdresa_Oblast_Edit;
        private System.Windows.Forms.TextBox textBoxIme_Oblast_Edit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxID_Oblast_Edit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cBoxUstanoviIzbor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cBoxUstanoviIzborEdit;
        private System.Windows.Forms.Label label14;
    }
}