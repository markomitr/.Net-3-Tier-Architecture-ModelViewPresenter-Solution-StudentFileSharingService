namespace WinFormAppTest
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
            this.txtBoxUserID = new System.Windows.Forms.TextBox();
            this.txtBoxLozinka = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblPoraka = new System.Windows.Forms.Label();
            this.lsBoxKor = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxNovUserID = new System.Windows.Forms.TextBox();
            this.txtBoxNovLozinka = new System.Windows.Forms.TextBox();
            this.txtBoxNovEmail = new System.Windows.Forms.TextBox();
            this.btnNovKor = new System.Windows.Forms.Button();
            this.lblPorakaNovKor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxUserID
            // 
            this.txtBoxUserID.Location = new System.Drawing.Point(15, 20);
            this.txtBoxUserID.Name = "txtBoxUserID";
            this.txtBoxUserID.Size = new System.Drawing.Size(141, 20);
            this.txtBoxUserID.TabIndex = 0;
            // 
            // txtBoxLozinka
            // 
            this.txtBoxLozinka.Location = new System.Drawing.Point(15, 63);
            this.txtBoxLozinka.Name = "txtBoxLozinka";
            this.txtBoxLozinka.Size = new System.Drawing.Size(141, 20);
            this.txtBoxLozinka.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(108, 90);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 28);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Logiraj";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblPoraka
            // 
            this.lblPoraka.AutoSize = true;
            this.lblPoraka.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPoraka.Location = new System.Drawing.Point(12, 119);
            this.lblPoraka.Name = "lblPoraka";
            this.lblPoraka.Size = new System.Drawing.Size(0, 13);
            this.lblPoraka.TabIndex = 3;
            // 
            // lsBoxKor
            // 
            this.lsBoxKor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsBoxKor.FormattingEnabled = true;
            this.lsBoxKor.ItemHeight = 15;
            this.lsBoxKor.Location = new System.Drawing.Point(8, 164);
            this.lsBoxKor.Name = "lsBoxKor";
            this.lsBoxKor.Size = new System.Drawing.Size(383, 94);
            this.lsBoxKor.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBoxUserID);
            this.panel1.Controls.Add(this.txtBoxLozinka);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.lblPoraka);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 146);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblPorakaNovKor);
            this.panel2.Controls.Add(this.btnNovKor);
            this.panel2.Controls.Add(this.txtBoxNovEmail);
            this.panel2.Controls.Add(this.txtBoxNovLozinka);
            this.panel2.Controls.Add(this.txtBoxNovUserID);
            this.panel2.Location = new System.Drawing.Point(237, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 146);
            this.panel2.TabIndex = 6;
            // 
            // txtBoxNovUserID
            // 
            this.txtBoxNovUserID.Location = new System.Drawing.Point(4, 20);
            this.txtBoxNovUserID.Name = "txtBoxNovUserID";
            this.txtBoxNovUserID.Size = new System.Drawing.Size(141, 20);
            this.txtBoxNovUserID.TabIndex = 0;
            // 
            // txtBoxNovLozinka
            // 
            this.txtBoxNovLozinka.Location = new System.Drawing.Point(3, 62);
            this.txtBoxNovLozinka.Name = "txtBoxNovLozinka";
            this.txtBoxNovLozinka.Size = new System.Drawing.Size(141, 20);
            this.txtBoxNovLozinka.TabIndex = 1;
            // 
            // txtBoxNovEmail
            // 
            this.txtBoxNovEmail.Location = new System.Drawing.Point(4, 98);
            this.txtBoxNovEmail.Name = "txtBoxNovEmail";
            this.txtBoxNovEmail.Size = new System.Drawing.Size(141, 20);
            this.txtBoxNovEmail.TabIndex = 2;
            // 
            // btnNovKor
            // 
            this.btnNovKor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovKor.Location = new System.Drawing.Point(176, 17);
            this.btnNovKor.Name = "btnNovKor";
            this.btnNovKor.Size = new System.Drawing.Size(129, 57);
            this.btnNovKor.TabIndex = 3;
            this.btnNovKor.Text = "Nov Korisnik";
            this.btnNovKor.UseVisualStyleBackColor = true;
            this.btnNovKor.Click += new System.EventHandler(this.btnNovKor_Click);
            // 
            // lblPorakaNovKor
            // 
            this.lblPorakaNovKor.AutoSize = true;
            this.lblPorakaNovKor.Location = new System.Drawing.Point(154, 101);
            this.lblPorakaNovKor.Name = "lblPorakaNovKor";
            this.lblPorakaNovKor.Size = new System.Drawing.Size(0, 13);
            this.lblPorakaNovKor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "UserID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pass";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "UserID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Pass";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "e-Mail";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(413, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 92);
            this.button1.TabIndex = 7;
            this.button1.Text = "Lista Korisnici";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(577, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lsBoxKor);
            this.Name = "Form1";
            this.Text = "Korisnici";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxUserID;
        private System.Windows.Forms.TextBox txtBoxLozinka;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblPoraka;
        private System.Windows.Forms.ListBox lsBoxKor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNovKor;
        private System.Windows.Forms.TextBox txtBoxNovEmail;
        private System.Windows.Forms.TextBox txtBoxNovLozinka;
        private System.Windows.Forms.TextBox txtBoxNovUserID;
        private System.Windows.Forms.Label lblPorakaNovKor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

