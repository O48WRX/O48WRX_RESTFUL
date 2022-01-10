
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class PSUForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.PSU_PRICEBOX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PSU_PERFBOX = new System.Windows.Forms.TextBox();
            this.PSU_Delete = new System.Windows.Forms.Button();
            this.PSU_Update = new System.Windows.Forms.Button();
            this.PSU_Create = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PSU_MODELBOX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PSU_MANUBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PSU_IDBOX = new System.Windows.Forms.TextBox();
            this.PSU_Grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PSU_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(658, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 55;
            this.label5.Text = "Ár:";
            // 
            // PSU_PRICEBOX
            // 
            this.PSU_PRICEBOX.Location = new System.Drawing.Point(658, 252);
            this.PSU_PRICEBOX.Name = "PSU_PRICEBOX";
            this.PSU_PRICEBOX.Size = new System.Drawing.Size(130, 23);
            this.PSU_PRICEBOX.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(658, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "Teljesítmény:";
            // 
            // PSU_PERFBOX
            // 
            this.PSU_PERFBOX.Location = new System.Drawing.Point(658, 209);
            this.PSU_PERFBOX.Name = "PSU_PERFBOX";
            this.PSU_PERFBOX.Size = new System.Drawing.Size(130, 23);
            this.PSU_PERFBOX.TabIndex = 52;
            // 
            // PSU_Delete
            // 
            this.PSU_Delete.Location = new System.Drawing.Point(671, 357);
            this.PSU_Delete.Name = "PSU_Delete";
            this.PSU_Delete.Size = new System.Drawing.Size(105, 32);
            this.PSU_Delete.TabIndex = 51;
            this.PSU_Delete.Text = "Töröl";
            this.PSU_Delete.UseVisualStyleBackColor = true;
            this.PSU_Delete.Click += new System.EventHandler(this.PSU_Delete_Click);
            // 
            // PSU_Update
            // 
            this.PSU_Update.Location = new System.Drawing.Point(671, 319);
            this.PSU_Update.Name = "PSU_Update";
            this.PSU_Update.Size = new System.Drawing.Size(105, 32);
            this.PSU_Update.TabIndex = 50;
            this.PSU_Update.Text = "Szerkeszt";
            this.PSU_Update.UseVisualStyleBackColor = true;
            this.PSU_Update.Click += new System.EventHandler(this.PSU_Update_Click);
            // 
            // PSU_Create
            // 
            this.PSU_Create.Location = new System.Drawing.Point(671, 281);
            this.PSU_Create.Name = "PSU_Create";
            this.PSU_Create.Size = new System.Drawing.Size(105, 32);
            this.PSU_Create.TabIndex = 49;
            this.PSU_Create.Text = "Létrehoz";
            this.PSU_Create.UseVisualStyleBackColor = true;
            this.PSU_Create.Click += new System.EventHandler(this.PSU_Create_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(658, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 48;
            this.label3.Text = "Modell:";
            // 
            // PSU_MODELBOX
            // 
            this.PSU_MODELBOX.Location = new System.Drawing.Point(658, 165);
            this.PSU_MODELBOX.Name = "PSU_MODELBOX";
            this.PSU_MODELBOX.Size = new System.Drawing.Size(130, 23);
            this.PSU_MODELBOX.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "Gyártó:";
            // 
            // PSU_MANUBOX
            // 
            this.PSU_MANUBOX.Location = new System.Drawing.Point(658, 121);
            this.PSU_MANUBOX.Name = "PSU_MANUBOX";
            this.PSU_MANUBOX.Size = new System.Drawing.Size(130, 23);
            this.PSU_MANUBOX.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "Azonosító:";
            // 
            // PSU_IDBOX
            // 
            this.PSU_IDBOX.Location = new System.Drawing.Point(658, 77);
            this.PSU_IDBOX.Name = "PSU_IDBOX";
            this.PSU_IDBOX.Size = new System.Drawing.Size(130, 23);
            this.PSU_IDBOX.TabIndex = 43;
            // 
            // PSU_Grid
            // 
            this.PSU_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PSU_Grid.Location = new System.Drawing.Point(12, 12);
            this.PSU_Grid.Name = "PSU_Grid";
            this.PSU_Grid.RowTemplate.Height = 25;
            this.PSU_Grid.Size = new System.Drawing.Size(530, 515);
            this.PSU_Grid.TabIndex = 42;
            this.PSU_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PSU_Grid_CellClick);
            // 
            // PSUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 542);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PSU_PRICEBOX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PSU_PERFBOX);
            this.Controls.Add(this.PSU_Delete);
            this.Controls.Add(this.PSU_Update);
            this.Controls.Add(this.PSU_Create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PSU_MODELBOX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PSU_MANUBOX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PSU_IDBOX);
            this.Controls.Add(this.PSU_Grid);
            this.Name = "PSUForm";
            this.Text = "PSUForm";
            ((System.ComponentModel.ISupportInitialize)(this.PSU_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PSU_PRICEBOX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PSU_PERFBOX;
        private System.Windows.Forms.Button PSU_Delete;
        private System.Windows.Forms.Button PSU_Update;
        private System.Windows.Forms.Button PSU_Create;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PSU_MODELBOX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PSU_MANUBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PSU_IDBOX;
        private System.Windows.Forms.DataGridView PSU_Grid;
    }
}