namespace WinFormAppTest
{
	partial class Materijali
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
			if(disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUploadFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelAddInstitucija = new System.Windows.Forms.Panel();
            this.textBoxType_Materijal_Add = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPateka_Materijal_Add = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddMaterijal = new System.Windows.Forms.Button();
            this.textBoxSlika_Materijal_Add = new System.Windows.Forms.TextBox();
            this.textBoxOpis_Materijal_Add = new System.Windows.Forms.TextBox();
            this.textBoxNaslov_Materijal_Add = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ftpProgress1 = new WinFormAppTest.FtpUpload(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelAddInstitucija.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Target Folder";
            // 
            // txtDir
            // 
            this.txtDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDir.Location = new System.Drawing.Point(118, 121);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(132, 20);
            this.txtDir.TabIndex = 5;
            this.txtDir.Text = "Materijali";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Password";
            // 
            // btnUpload
            // 
            this.btnUpload.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpload.Location = new System.Drawing.Point(35, 190);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 8;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Host";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(118, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(132, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Tv2010PC";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(118, 67);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(132, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "Administrator";
            // 
            // txtHost
            // 
            this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHost.Location = new System.Drawing.Point(118, 40);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(132, 20);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "ftp://78.157.0.161";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Upload File";
            // 
            // txtUploadFile
            // 
            this.txtUploadFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUploadFile.Location = new System.Drawing.Point(118, 151);
            this.txtUploadFile.Name = "txtUploadFile";
            this.txtUploadFile.Size = new System.Drawing.Size(132, 20);
            this.txtUploadFile.TabIndex = 6;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(256, 151);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 311);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(785, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Ready";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(314, 250);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(72, 20);
            this.lblStatus.TabIndex = 34;
            this.lblStatus.Text = "STATUS";
            // 
            // panelAddInstitucija
            // 
            this.panelAddInstitucija.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panelAddInstitucija.Controls.Add(this.textBoxType_Materijal_Add);
            this.panelAddInstitucija.Controls.Add(this.label12);
            this.panelAddInstitucija.Controls.Add(this.label2);
            this.panelAddInstitucija.Controls.Add(this.textBoxPateka_Materijal_Add);
            this.panelAddInstitucija.Controls.Add(this.label7);
            this.panelAddInstitucija.Controls.Add(this.btnAddMaterijal);
            this.panelAddInstitucija.Controls.Add(this.textBoxSlika_Materijal_Add);
            this.panelAddInstitucija.Controls.Add(this.textBoxOpis_Materijal_Add);
            this.panelAddInstitucija.Controls.Add(this.textBoxNaslov_Materijal_Add);
            this.panelAddInstitucija.Controls.Add(this.label8);
            this.panelAddInstitucija.Controls.Add(this.label9);
            this.panelAddInstitucija.Controls.Add(this.label10);
            this.panelAddInstitucija.Controls.Add(this.label11);
            this.panelAddInstitucija.Location = new System.Drawing.Point(318, 3);
            this.panelAddInstitucija.Name = "panelAddInstitucija";
            this.panelAddInstitucija.Size = new System.Drawing.Size(268, 244);
            this.panelAddInstitucija.TabIndex = 33;
            // 
            // textBoxType_Materijal_Add
            // 
            this.textBoxType_Materijal_Add.Location = new System.Drawing.Point(67, 155);
            this.textBoxType_Materijal_Add.Name = "textBoxType_Materijal_Add";
            this.textBoxType_Materijal_Add.Size = new System.Drawing.Size(169, 20);
            this.textBoxType_Materijal_Add.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Вид ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Додаден Од";
            // 
            // textBoxPateka_Materijal_Add
            // 
            this.textBoxPateka_Materijal_Add.Location = new System.Drawing.Point(67, 125);
            this.textBoxPateka_Materijal_Add.Name = "textBoxPateka_Materijal_Add";
            this.textBoxPateka_Materijal_Add.Size = new System.Drawing.Size(169, 20);
            this.textBoxPateka_Materijal_Add.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Патека";
            // 
            // btnAddMaterijal
            // 
            this.btnAddMaterijal.BackColor = System.Drawing.Color.White;
            this.btnAddMaterijal.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAddMaterijal.FlatAppearance.BorderSize = 2;
            this.btnAddMaterijal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMaterijal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMaterijal.Location = new System.Drawing.Point(179, 200);
            this.btnAddMaterijal.Name = "btnAddMaterijal";
            this.btnAddMaterijal.Size = new System.Drawing.Size(75, 27);
            this.btnAddMaterijal.TabIndex = 7;
            this.btnAddMaterijal.Text = "Потврди";
            this.btnAddMaterijal.UseVisualStyleBackColor = false;
            this.btnAddMaterijal.Click += new System.EventHandler(this.btnAddMaterijal_Click_1);
            // 
            // textBoxSlika_Materijal_Add
            // 
            this.textBoxSlika_Materijal_Add.Location = new System.Drawing.Point(67, 96);
            this.textBoxSlika_Materijal_Add.Name = "textBoxSlika_Materijal_Add";
            this.textBoxSlika_Materijal_Add.Size = new System.Drawing.Size(169, 20);
            this.textBoxSlika_Materijal_Add.TabIndex = 6;
            // 
            // textBoxOpis_Materijal_Add
            // 
            this.textBoxOpis_Materijal_Add.Location = new System.Drawing.Point(67, 70);
            this.textBoxOpis_Materijal_Add.Name = "textBoxOpis_Materijal_Add";
            this.textBoxOpis_Materijal_Add.Size = new System.Drawing.Size(169, 20);
            this.textBoxOpis_Materijal_Add.TabIndex = 5;
            // 
            // textBoxNaslov_Materijal_Add
            // 
            this.textBoxNaslov_Materijal_Add.Location = new System.Drawing.Point(67, 44);
            this.textBoxNaslov_Materijal_Add.Name = "textBoxNaslov_Materijal_Add";
            this.textBoxNaslov_Materijal_Add.Size = new System.Drawing.Size(169, 20);
            this.textBoxNaslov_Materijal_Add.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Слика";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Опис";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Наслов";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Додади Материјал";
            // 
            // ftpProgress1
            // 
            this.ftpProgress1.WorkerReportsProgress = true;
            this.ftpProgress1.WorkerSupportsCancellation = true;
            this.ftpProgress1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ftpProgress1_ProgressChanged);
            this.ftpProgress1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ftpProgress1_RunWorkerCompleted);
            // 
            // Materijali
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 333);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelAddInstitucija);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUploadFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtHost);
            this.Name = "Materijali";
            this.Text = "FTP transfer with progress bar";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelAddInstitucija.ResumeLayout(false);
            this.panelAddInstitucija.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDir;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnUpload;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtUploadFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private FtpUpload ftpProgress1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelAddInstitucija;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPateka_Materijal_Add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddMaterijal;
        private System.Windows.Forms.TextBox textBoxSlika_Materijal_Add;
        private System.Windows.Forms.TextBox textBoxOpis_Materijal_Add;
        private System.Windows.Forms.TextBox textBoxNaslov_Materijal_Add;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxType_Materijal_Add;
        private System.Windows.Forms.Label label12;
	}
}

