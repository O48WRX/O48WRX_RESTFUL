
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class Users
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
            this.USERS_Grid = new System.Windows.Forms.DataGridView();
            this.USERS_IDBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.USERS_NameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.USERS_PwBox = new System.Windows.Forms.TextBox();
            this.USERS_Create = new System.Windows.Forms.Button();
            this.USERS_Update = new System.Windows.Forms.Button();
            this.USERS_Delete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.USERS_IsAdmin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.USERS_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // USERS_Grid
            // 
            this.USERS_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.USERS_Grid.Location = new System.Drawing.Point(12, 12);
            this.USERS_Grid.Name = "USERS_Grid";
            this.USERS_Grid.RowTemplate.Height = 25;
            this.USERS_Grid.Size = new System.Drawing.Size(530, 515);
            this.USERS_Grid.TabIndex = 0;
            this.USERS_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.USERS_Grid_CellClick);
            // 
            // USERS_IDBOX
            // 
            this.USERS_IDBOX.Location = new System.Drawing.Point(643, 64);
            this.USERS_IDBOX.Name = "USERS_IDBOX";
            this.USERS_IDBOX.Size = new System.Drawing.Size(130, 23);
            this.USERS_IDBOX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Azonosító:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Felhasználónév:";
            // 
            // USERS_NameBox
            // 
            this.USERS_NameBox.Location = new System.Drawing.Point(643, 118);
            this.USERS_NameBox.Name = "USERS_NameBox";
            this.USERS_NameBox.Size = new System.Drawing.Size(130, 23);
            this.USERS_NameBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(643, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jelszó:";
            // 
            // USERS_PwBox
            // 
            this.USERS_PwBox.Location = new System.Drawing.Point(643, 175);
            this.USERS_PwBox.Name = "USERS_PwBox";
            this.USERS_PwBox.Size = new System.Drawing.Size(130, 23);
            this.USERS_PwBox.TabIndex = 5;
            // 
            // USERS_Create
            // 
            this.USERS_Create.Location = new System.Drawing.Point(655, 275);
            this.USERS_Create.Name = "USERS_Create";
            this.USERS_Create.Size = new System.Drawing.Size(105, 32);
            this.USERS_Create.TabIndex = 7;
            this.USERS_Create.Text = "Létrehoz";
            this.USERS_Create.UseVisualStyleBackColor = true;
            this.USERS_Create.Click += new System.EventHandler(this.USERS_Create_Click);
            // 
            // USERS_Update
            // 
            this.USERS_Update.Location = new System.Drawing.Point(655, 313);
            this.USERS_Update.Name = "USERS_Update";
            this.USERS_Update.Size = new System.Drawing.Size(105, 32);
            this.USERS_Update.TabIndex = 8;
            this.USERS_Update.Text = "Szerkeszt";
            this.USERS_Update.UseVisualStyleBackColor = true;
            // 
            // USERS_Delete
            // 
            this.USERS_Delete.Location = new System.Drawing.Point(655, 351);
            this.USERS_Delete.Name = "USERS_Delete";
            this.USERS_Delete.Size = new System.Drawing.Size(105, 32);
            this.USERS_Delete.TabIndex = 9;
            this.USERS_Delete.Text = "Töröl";
            this.USERS_Delete.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(643, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Admin-e?";
            // 
            // USERS_IsAdmin
            // 
            this.USERS_IsAdmin.Location = new System.Drawing.Point(643, 231);
            this.USERS_IsAdmin.Name = "USERS_IsAdmin";
            this.USERS_IsAdmin.Size = new System.Drawing.Size(130, 23);
            this.USERS_IsAdmin.TabIndex = 10;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 539);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.USERS_IsAdmin);
            this.Controls.Add(this.USERS_Delete);
            this.Controls.Add(this.USERS_Update);
            this.Controls.Add(this.USERS_Create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.USERS_PwBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.USERS_NameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.USERS_IDBOX);
            this.Controls.Add(this.USERS_Grid);
            this.Name = "Users";
            this.Text = "Users";
            ((System.ComponentModel.ISupportInitialize)(this.USERS_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView USERS_Grid;
        private System.Windows.Forms.TextBox USERS_IDBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox USERS_NameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox USERS_PwBox;
        private System.Windows.Forms.Button USERS_Create;
        private System.Windows.Forms.Button USERS_Update;
        private System.Windows.Forms.Button USERS_Delete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox USERS_IsAdmin;
    }
}