
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class ProcessorForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.PROC_CLOCKBOX = new System.Windows.Forms.TextBox();
            this.PROC_Delete = new System.Windows.Forms.Button();
            this.PROC_Update = new System.Windows.Forms.Button();
            this.PROC_Create = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PROC_MODELBOX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PROC_MANUBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PROC_IDBOX = new System.Windows.Forms.TextBox();
            this.PROC_GRID = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.PROC_PRICEBOX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PROC_GRID)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Órajel:";
            // 
            // PROC_CLOCKBOX
            // 
            this.PROC_CLOCKBOX.Location = new System.Drawing.Point(656, 229);
            this.PROC_CLOCKBOX.Name = "PROC_CLOCKBOX";
            this.PROC_CLOCKBOX.Size = new System.Drawing.Size(130, 23);
            this.PROC_CLOCKBOX.TabIndex = 22;
            // 
            // PROC_Delete
            // 
            this.PROC_Delete.Location = new System.Drawing.Point(669, 388);
            this.PROC_Delete.Name = "PROC_Delete";
            this.PROC_Delete.Size = new System.Drawing.Size(105, 32);
            this.PROC_Delete.TabIndex = 21;
            this.PROC_Delete.Text = "Töröl";
            this.PROC_Delete.UseVisualStyleBackColor = true;
            this.PROC_Delete.Click += new System.EventHandler(this.PROC_Delete_Click);
            // 
            // PROC_Update
            // 
            this.PROC_Update.Location = new System.Drawing.Point(669, 350);
            this.PROC_Update.Name = "PROC_Update";
            this.PROC_Update.Size = new System.Drawing.Size(105, 32);
            this.PROC_Update.TabIndex = 20;
            this.PROC_Update.Text = "Szerkeszt";
            this.PROC_Update.UseVisualStyleBackColor = true;
            this.PROC_Update.Click += new System.EventHandler(this.PROC_Update_Click);
            // 
            // PROC_Create
            // 
            this.PROC_Create.Location = new System.Drawing.Point(669, 312);
            this.PROC_Create.Name = "PROC_Create";
            this.PROC_Create.Size = new System.Drawing.Size(105, 32);
            this.PROC_Create.TabIndex = 19;
            this.PROC_Create.Text = "Létrehoz";
            this.PROC_Create.UseVisualStyleBackColor = true;
            this.PROC_Create.Click += new System.EventHandler(this.PROC_Create_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Modell:";
            // 
            // PROC_MODELBOX
            // 
            this.PROC_MODELBOX.Location = new System.Drawing.Point(656, 185);
            this.PROC_MODELBOX.Name = "PROC_MODELBOX";
            this.PROC_MODELBOX.Size = new System.Drawing.Size(130, 23);
            this.PROC_MODELBOX.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Gyártó:";
            // 
            // PROC_MANUBOX
            // 
            this.PROC_MANUBOX.Location = new System.Drawing.Point(656, 141);
            this.PROC_MANUBOX.Name = "PROC_MANUBOX";
            this.PROC_MANUBOX.Size = new System.Drawing.Size(130, 23);
            this.PROC_MANUBOX.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Azonosító:";
            // 
            // PROC_IDBOX
            // 
            this.PROC_IDBOX.Location = new System.Drawing.Point(656, 97);
            this.PROC_IDBOX.Name = "PROC_IDBOX";
            this.PROC_IDBOX.Size = new System.Drawing.Size(130, 23);
            this.PROC_IDBOX.TabIndex = 13;
            // 
            // PROC_GRID
            // 
            this.PROC_GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PROC_GRID.Location = new System.Drawing.Point(22, 12);
            this.PROC_GRID.Name = "PROC_GRID";
            this.PROC_GRID.RowTemplate.Height = 25;
            this.PROC_GRID.Size = new System.Drawing.Size(530, 515);
            this.PROC_GRID.TabIndex = 12;
            this.PROC_GRID.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PROC_GRID_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(656, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Ár:";
            // 
            // PROC_PRICEBOX
            // 
            this.PROC_PRICEBOX.Location = new System.Drawing.Point(656, 273);
            this.PROC_PRICEBOX.Name = "PROC_PRICEBOX";
            this.PROC_PRICEBOX.Size = new System.Drawing.Size(130, 23);
            this.PROC_PRICEBOX.TabIndex = 24;
            // 
            // ProcessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 540);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PROC_PRICEBOX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PROC_CLOCKBOX);
            this.Controls.Add(this.PROC_Delete);
            this.Controls.Add(this.PROC_Update);
            this.Controls.Add(this.PROC_Create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PROC_MODELBOX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PROC_MANUBOX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PROC_IDBOX);
            this.Controls.Add(this.PROC_GRID);
            this.Name = "ProcessorForm";
            this.Text = "ProcessorForm";
            ((System.ComponentModel.ISupportInitialize)(this.PROC_GRID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PROC_CLOCKBOX;
        private System.Windows.Forms.Button PROC_Delete;
        private System.Windows.Forms.Button PROC_Update;
        private System.Windows.Forms.Button PROC_Create;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PROC_MODELBOX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PROC_MANUBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PROC_IDBOX;
        private System.Windows.Forms.DataGridView PROC_GRID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PROC_PRICEBOX;
    }
}