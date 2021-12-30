
namespace O48WRX_RESTFULCLIENT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.F1_REG = new System.Windows.Forms.Button();
            this.F1_LOGIN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.F1_PASSWORDBOX = new System.Windows.Forms.TextBox();
            this.F1_NAMEBOX = new System.Windows.Forms.TextBox();
            this.F1_HIDEPW = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.F1_HIDEPW);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.F1_REG);
            this.groupBox1.Controls.Add(this.F1_LOGIN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.F1_PASSWORDBOX);
            this.groupBox1.Controls.Add(this.F1_NAMEBOX);
            this.groupBox1.Location = new System.Drawing.Point(50, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Új vagy itt? Regisztrálj!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "Számítástechnikai bolt";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // F1_REG
            // 
            this.F1_REG.Location = new System.Drawing.Point(104, 269);
            this.F1_REG.Name = "F1_REG";
            this.F1_REG.Size = new System.Drawing.Size(152, 36);
            this.F1_REG.TabIndex = 4;
            this.F1_REG.Text = "Regisztráció";
            this.F1_REG.UseVisualStyleBackColor = true;
            this.F1_REG.Click += new System.EventHandler(this.F1_REG_Click);
            // 
            // F1_LOGIN
            // 
            this.F1_LOGIN.Location = new System.Drawing.Point(104, 189);
            this.F1_LOGIN.Name = "F1_LOGIN";
            this.F1_LOGIN.Size = new System.Drawing.Size(152, 36);
            this.F1_LOGIN.TabIndex = 1;
            this.F1_LOGIN.Text = "Belépés";
            this.F1_LOGIN.UseVisualStyleBackColor = true;
            this.F1_LOGIN.Click += new System.EventHandler(this.F1_LOGIN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jelszó";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Felhasználónév";
            // 
            // F1_PASSWORDBOX
            // 
            this.F1_PASSWORDBOX.Location = new System.Drawing.Point(104, 160);
            this.F1_PASSWORDBOX.Name = "F1_PASSWORDBOX";
            this.F1_PASSWORDBOX.Size = new System.Drawing.Size(152, 23);
            this.F1_PASSWORDBOX.TabIndex = 1;
            // 
            // F1_NAMEBOX
            // 
            this.F1_NAMEBOX.Location = new System.Drawing.Point(104, 131);
            this.F1_NAMEBOX.Name = "F1_NAMEBOX";
            this.F1_NAMEBOX.Size = new System.Drawing.Size(152, 23);
            this.F1_NAMEBOX.TabIndex = 0;
            // 
            // F1_HIDEPW
            // 
            this.F1_HIDEPW.Image = ((System.Drawing.Image)(resources.GetObject("F1_HIDEPW.Image")));
            this.F1_HIDEPW.Location = new System.Drawing.Point(22, 159);
            this.F1_HIDEPW.Name = "F1_HIDEPW";
            this.F1_HIDEPW.Size = new System.Drawing.Size(24, 24);
            this.F1_HIDEPW.TabIndex = 7;
            this.F1_HIDEPW.UseVisualStyleBackColor = true;
            this.F1_HIDEPW.Click += new System.EventHandler(this.F1_HIDEPW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 408);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button F1_REG;
        private System.Windows.Forms.Button F1_LOGIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox F1_PASSWORDBOX;
        private System.Windows.Forms.TextBox F1_NAMEBOX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button F1_HIDEPW;
    }
}

