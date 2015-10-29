namespace WinFormAppTest
{
    partial class UpdateKorForma
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxUserID = new System.Windows.Forms.TextBox();
            this.btnPromeniUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxIme = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserID";
            // 
            // txtBoxUserID
            // 
            this.txtBoxUserID.Location = new System.Drawing.Point(93, 41);
            this.txtBoxUserID.Name = "txtBoxUserID";
            this.txtBoxUserID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUserID.TabIndex = 1;
            // 
            // btnPromeniUser
            // 
            this.btnPromeniUser.Location = new System.Drawing.Point(118, 152);
            this.btnPromeniUser.Name = "btnPromeniUser";
            this.btnPromeniUser.Size = new System.Drawing.Size(75, 23);
            this.btnPromeniUser.TabIndex = 2;
            this.btnPromeniUser.Text = "Promeni";
            this.btnPromeniUser.UseVisualStyleBackColor = true;
            this.btnPromeniUser.Click += new System.EventHandler(this.btnPromeniUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ime";
            // 
            // txtBoxIme
            // 
            this.txtBoxIme.Location = new System.Drawing.Point(93, 78);
            this.txtBoxIme.Name = "txtBoxIme";
            this.txtBoxIme.Size = new System.Drawing.Size(100, 20);
            this.txtBoxIme.TabIndex = 5;
            // 
            // UpdateKorForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtBoxIme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPromeniUser);
            this.Controls.Add(this.txtBoxUserID);
            this.Controls.Add(this.label1);
            this.Name = "UpdateKorForma";
            this.Text = "UpdateKorForma";
            this.Load += new System.EventHandler(this.UpdateKorForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxUserID;
        private System.Windows.Forms.Button btnPromeniUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxIme;
    }
}