namespace WinFormAppTest
{
    partial class PredmetForm
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
            this.btnDodadiPredmet = new System.Windows.Forms.Button();
            this.textBoxIme_Predmet_Add = new System.Windows.Forms.TextBox();
            this.textBoxOpis_Predmet_Add = new System.Windows.Forms.TextBox();
            this.panelAddNasoka = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelPregledPredmeti = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxID_Predmet_Edit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnIzmeniPredmet = new System.Windows.Forms.Button();
            this.textBoxOpis_Predmet_Edit = new System.Windows.Forms.TextBox();
            this.textBoxIme_Predmet_Edit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelPregledPredmetiSoIzbor = new System.Windows.Forms.Panel();
            this.panelAddNasoka.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDodadiPredmet
            // 
            this.btnDodadiPredmet.Location = new System.Drawing.Point(138, 123);
            this.btnDodadiPredmet.Name = "btnDodadiPredmet";
            this.btnDodadiPredmet.Size = new System.Drawing.Size(88, 35);
            this.btnDodadiPredmet.TabIndex = 7;
            this.btnDodadiPredmet.Text = "Додади";
            this.btnDodadiPredmet.UseVisualStyleBackColor = true;
            this.btnDodadiPredmet.Click += new System.EventHandler(this.btnDodadiPredmet_Click);
            // 
            // textBoxIme_Predmet_Add
            // 
            this.textBoxIme_Predmet_Add.Location = new System.Drawing.Point(91, 26);
            this.textBoxIme_Predmet_Add.Name = "textBoxIme_Predmet_Add";
            this.textBoxIme_Predmet_Add.Size = new System.Drawing.Size(135, 20);
            this.textBoxIme_Predmet_Add.TabIndex = 4;
            // 
            // textBoxOpis_Predmet_Add
            // 
            this.textBoxOpis_Predmet_Add.Location = new System.Drawing.Point(91, 58);
            this.textBoxOpis_Predmet_Add.Multiline = true;
            this.textBoxOpis_Predmet_Add.Name = "textBoxOpis_Predmet_Add";
            this.textBoxOpis_Predmet_Add.Size = new System.Drawing.Size(135, 45);
            this.textBoxOpis_Predmet_Add.TabIndex = 5;
            // 
            // panelAddNasoka
            // 
            this.panelAddNasoka.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelAddNasoka.Controls.Add(this.btnDodadiPredmet);
            this.panelAddNasoka.Controls.Add(this.textBoxOpis_Predmet_Add);
            this.panelAddNasoka.Controls.Add(this.textBoxIme_Predmet_Add);
            this.panelAddNasoka.Controls.Add(this.label4);
            this.panelAddNasoka.Controls.Add(this.label2);
            this.panelAddNasoka.Controls.Add(this.label1);
            this.panelAddNasoka.Location = new System.Drawing.Point(12, 12);
            this.panelAddNasoka.Name = "panelAddNasoka";
            this.panelAddNasoka.Size = new System.Drawing.Size(253, 172);
            this.panelAddNasoka.TabIndex = 2;
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
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Додади Предмет";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 196);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "STATUS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Предмети Преглед";
            // 
            // panelPregledPredmeti
            // 
            this.panelPregledPredmeti.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPregledPredmeti.Location = new System.Drawing.Point(9, 250);
            this.panelPregledPredmeti.Name = "panelPregledPredmeti";
            this.panelPregledPredmeti.Size = new System.Drawing.Size(596, 170);
            this.panelPregledPredmeti.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.textBoxID_Predmet_Edit);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnIzmeniPredmet);
            this.panel1.Controls.Add(this.textBoxOpis_Predmet_Edit);
            this.panel1.Controls.Add(this.textBoxIme_Predmet_Edit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(352, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 182);
            this.panel1.TabIndex = 8;
            // 
            // textBoxID_Predmet_Edit
            // 
            this.textBoxID_Predmet_Edit.Location = new System.Drawing.Point(91, 20);
            this.textBoxID_Predmet_Edit.Name = "textBoxID_Predmet_Edit";
            this.textBoxID_Predmet_Edit.Size = new System.Drawing.Size(40, 20);
            this.textBoxID_Predmet_Edit.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "ID";
            // 
            // btnIzmeniPredmet
            // 
            this.btnIzmeniPredmet.Location = new System.Drawing.Point(138, 137);
            this.btnIzmeniPredmet.Name = "btnIzmeniPredmet";
            this.btnIzmeniPredmet.Size = new System.Drawing.Size(88, 35);
            this.btnIzmeniPredmet.TabIndex = 7;
            this.btnIzmeniPredmet.Text = "Измени";
            this.btnIzmeniPredmet.UseVisualStyleBackColor = true;
            this.btnIzmeniPredmet.Click += new System.EventHandler(this.btnIzmeniPredmet_Click);
            // 
            // textBoxOpis_Predmet_Edit
            // 
            this.textBoxOpis_Predmet_Edit.Location = new System.Drawing.Point(91, 82);
            this.textBoxOpis_Predmet_Edit.Multiline = true;
            this.textBoxOpis_Predmet_Edit.Name = "textBoxOpis_Predmet_Edit";
            this.textBoxOpis_Predmet_Edit.Size = new System.Drawing.Size(135, 45);
            this.textBoxOpis_Predmet_Edit.TabIndex = 5;
            // 
            // textBoxIme_Predmet_Edit
            // 
            this.textBoxIme_Predmet_Edit.Location = new System.Drawing.Point(91, 50);
            this.textBoxIme_Predmet_Edit.Name = "textBoxIme_Predmet_Edit";
            this.textBoxIme_Predmet_Edit.Size = new System.Drawing.Size(135, 20);
            this.textBoxIme_Predmet_Edit.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Опис";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Име";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Измени Предмет";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 423);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Предмети Преглед Избор";
            // 
            // panelPregledPredmetiSoIzbor
            // 
            this.panelPregledPredmetiSoIzbor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPregledPredmetiSoIzbor.Location = new System.Drawing.Point(6, 441);
            this.panelPregledPredmetiSoIzbor.Name = "panelPregledPredmetiSoIzbor";
            this.panelPregledPredmetiSoIzbor.Size = new System.Drawing.Size(596, 170);
            this.panelPregledPredmetiSoIzbor.TabIndex = 9;
            // 
            // PredmetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 630);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panelPregledPredmetiSoIzbor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelPregledPredmeti);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelAddNasoka);
            this.Name = "PredmetForm";
            this.Text = "PredmetForm";
            this.Load += new System.EventHandler(this.PredmetForm_Load);
            this.panelAddNasoka.ResumeLayout(false);
            this.panelAddNasoka.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodadiPredmet;
        private System.Windows.Forms.TextBox textBoxIme_Predmet_Add;
        private System.Windows.Forms.TextBox textBoxOpis_Predmet_Add;
        private System.Windows.Forms.Panel panelAddNasoka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelPregledPredmeti;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIzmeniPredmet;
        private System.Windows.Forms.TextBox textBoxOpis_Predmet_Edit;
        private System.Windows.Forms.TextBox textBoxIme_Predmet_Edit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxID_Predmet_Edit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelPregledPredmetiSoIzbor;
    }
}