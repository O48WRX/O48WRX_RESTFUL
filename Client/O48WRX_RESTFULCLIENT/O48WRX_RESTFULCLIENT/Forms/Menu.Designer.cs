
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class Menu
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
            this.MENU_USERS = new System.Windows.Forms.Button();
            this.MENU_PROCESSOR = new System.Windows.Forms.Button();
            this.MENU_VGA = new System.Windows.Forms.Button();
            this.MENU_PSU = new System.Windows.Forms.Button();
            this.MENU_RAM = new System.Windows.Forms.Button();
            this.MENU_MOBO = new System.Windows.Forms.Button();
            this.MENU_ORDERED = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // MENU_USERS
            // 
            this.MENU_USERS.Location = new System.Drawing.Point(186, 103);
            this.MENU_USERS.Name = "MENU_USERS";
            this.MENU_USERS.Size = new System.Drawing.Size(138, 53);
            this.MENU_USERS.TabIndex = 1;
            this.MENU_USERS.Text = "Felhasználók";
            this.MENU_USERS.UseVisualStyleBackColor = true;
            this.MENU_USERS.Click += new System.EventHandler(this.MENU_USERS_Click);
            // 
            // MENU_PROCESSOR
            // 
            this.MENU_PROCESSOR.Location = new System.Drawing.Point(186, 162);
            this.MENU_PROCESSOR.Name = "MENU_PROCESSOR";
            this.MENU_PROCESSOR.Size = new System.Drawing.Size(138, 53);
            this.MENU_PROCESSOR.TabIndex = 2;
            this.MENU_PROCESSOR.Text = "Processzorok";
            this.MENU_PROCESSOR.UseVisualStyleBackColor = true;
            this.MENU_PROCESSOR.Click += new System.EventHandler(this.MENU_PROCESSOR_Click);
            // 
            // MENU_VGA
            // 
            this.MENU_VGA.Location = new System.Drawing.Point(186, 221);
            this.MENU_VGA.Name = "MENU_VGA";
            this.MENU_VGA.Size = new System.Drawing.Size(138, 53);
            this.MENU_VGA.TabIndex = 3;
            this.MENU_VGA.Text = "Videókártyák";
            this.MENU_VGA.UseVisualStyleBackColor = true;
            // 
            // MENU_PSU
            // 
            this.MENU_PSU.Location = new System.Drawing.Point(186, 280);
            this.MENU_PSU.Name = "MENU_PSU";
            this.MENU_PSU.Size = new System.Drawing.Size(138, 53);
            this.MENU_PSU.TabIndex = 4;
            this.MENU_PSU.Text = "Tápegységek";
            this.MENU_PSU.UseVisualStyleBackColor = true;
            // 
            // MENU_RAM
            // 
            this.MENU_RAM.Location = new System.Drawing.Point(186, 339);
            this.MENU_RAM.Name = "MENU_RAM";
            this.MENU_RAM.Size = new System.Drawing.Size(138, 53);
            this.MENU_RAM.TabIndex = 5;
            this.MENU_RAM.Text = "Memória";
            this.MENU_RAM.UseVisualStyleBackColor = true;
            // 
            // MENU_MOBO
            // 
            this.MENU_MOBO.Location = new System.Drawing.Point(186, 398);
            this.MENU_MOBO.Name = "MENU_MOBO";
            this.MENU_MOBO.Size = new System.Drawing.Size(138, 53);
            this.MENU_MOBO.TabIndex = 6;
            this.MENU_MOBO.Text = "Alaplapok";
            this.MENU_MOBO.UseVisualStyleBackColor = true;
            // 
            // MENU_ORDERED
            // 
            this.MENU_ORDERED.Location = new System.Drawing.Point(186, 458);
            this.MENU_ORDERED.Name = "MENU_ORDERED";
            this.MENU_ORDERED.Size = new System.Drawing.Size(138, 53);
            this.MENU_ORDERED.TabIndex = 7;
            this.MENU_ORDERED.Text = "Rendelések";
            this.MENU_ORDERED.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 523);
            this.Controls.Add(this.MENU_ORDERED);
            this.Controls.Add(this.MENU_MOBO);
            this.Controls.Add(this.MENU_RAM);
            this.Controls.Add(this.MENU_PSU);
            this.Controls.Add(this.MENU_VGA);
            this.Controls.Add(this.MENU_PROCESSOR);
            this.Controls.Add(this.MENU_USERS);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MENU_USERS;
        private System.Windows.Forms.Button MENU_PROCESSOR;
        private System.Windows.Forms.Button MENU_VGA;
        private System.Windows.Forms.Button MENU_PSU;
        private System.Windows.Forms.Button MENU_RAM;
        private System.Windows.Forms.Button MENU_MOBO;
        private System.Windows.Forms.Button MENU_ORDERED;
    }
}