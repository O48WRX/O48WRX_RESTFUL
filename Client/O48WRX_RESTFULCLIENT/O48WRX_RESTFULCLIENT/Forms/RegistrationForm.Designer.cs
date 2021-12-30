
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.REGFORM_USERNAME = new System.Windows.Forms.TextBox();
            this.REGFORM_PASSWORD = new System.Windows.Forms.TextBox();
            this.REGFORM_REG = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.REGFORM_HIDEPW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // REGFORM_USERNAME
            // 
            this.REGFORM_USERNAME.Location = new System.Drawing.Point(103, 52);
            this.REGFORM_USERNAME.Name = "REGFORM_USERNAME";
            this.REGFORM_USERNAME.Size = new System.Drawing.Size(132, 23);
            this.REGFORM_USERNAME.TabIndex = 0;
            // 
            // REGFORM_PASSWORD
            // 
            this.REGFORM_PASSWORD.Location = new System.Drawing.Point(103, 93);
            this.REGFORM_PASSWORD.Name = "REGFORM_PASSWORD";
            this.REGFORM_PASSWORD.Size = new System.Drawing.Size(132, 23);
            this.REGFORM_PASSWORD.TabIndex = 1;
            // 
            // REGFORM_REG
            // 
            this.REGFORM_REG.Location = new System.Drawing.Point(66, 157);
            this.REGFORM_REG.Name = "REGFORM_REG";
            this.REGFORM_REG.Size = new System.Drawing.Size(124, 33);
            this.REGFORM_REG.TabIndex = 2;
            this.REGFORM_REG.Text = "Regisztrálj!";
            this.REGFORM_REG.UseVisualStyleBackColor = true;
            this.REGFORM_REG.Click += new System.EventHandler(this.REGFORM_REG_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Felhasználónév:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jelszó:";
            // 
            // REGFORM_HIDEPW
            // 
            this.REGFORM_HIDEPW.Image = ((System.Drawing.Image)(resources.GetObject("REGFORM_HIDEPW.Image")));
            this.REGFORM_HIDEPW.Location = new System.Drawing.Point(27, 92);
            this.REGFORM_HIDEPW.Name = "REGFORM_HIDEPW";
            this.REGFORM_HIDEPW.Size = new System.Drawing.Size(24, 24);
            this.REGFORM_HIDEPW.TabIndex = 5;
            this.REGFORM_HIDEPW.UseVisualStyleBackColor = true;
            this.REGFORM_HIDEPW.Click += new System.EventHandler(this.REGFORM_HIDEPW_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 202);
            this.Controls.Add(this.REGFORM_HIDEPW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.REGFORM_REG);
            this.Controls.Add(this.REGFORM_PASSWORD);
            this.Controls.Add(this.REGFORM_USERNAME);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox REGFORM_USERNAME;
        private System.Windows.Forms.TextBox REGFORM_PASSWORD;
        private System.Windows.Forms.Button REGFORM_REG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button REGFORM_HIDEPW;
    }
}