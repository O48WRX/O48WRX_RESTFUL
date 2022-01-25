
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class PHPGridForm
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
            this.PHPFORM_GRID = new System.Windows.Forms.DataGridView();
            this.PHPFORM_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PHPFORM_GRID)).BeginInit();
            this.SuspendLayout();
            // 
            // PHPFORM_GRID
            // 
            this.PHPFORM_GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PHPFORM_GRID.Location = new System.Drawing.Point(12, 12);
            this.PHPFORM_GRID.Name = "PHPFORM_GRID";
            this.PHPFORM_GRID.RowTemplate.Height = 25;
            this.PHPFORM_GRID.Size = new System.Drawing.Size(685, 467);
            this.PHPFORM_GRID.TabIndex = 0;
            // 
            // PHPFORM_Back
            // 
            this.PHPFORM_Back.Location = new System.Drawing.Point(723, 206);
            this.PHPFORM_Back.Name = "PHPFORM_Back";
            this.PHPFORM_Back.Size = new System.Drawing.Size(102, 43);
            this.PHPFORM_Back.TabIndex = 1;
            this.PHPFORM_Back.Text = "Vissza";
            this.PHPFORM_Back.UseVisualStyleBackColor = true;
            this.PHPFORM_Back.Click += new System.EventHandler(this.PHPFORM_Back_Click);
            // 
            // PHPGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 491);
            this.Controls.Add(this.PHPFORM_Back);
            this.Controls.Add(this.PHPFORM_GRID);
            this.Name = "PHPGridForm";
            this.Text = "PHPGridForm";
            ((System.ComponentModel.ISupportInitialize)(this.PHPFORM_GRID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PHPFORM_GRID;
        private System.Windows.Forms.Button PHPFORM_Back;
    }
}