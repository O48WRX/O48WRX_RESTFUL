
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class ORD_INFOForm
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
            this.ORDINFO_GRID = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ORDINFO_GRID)).BeginInit();
            this.SuspendLayout();
            // 
            // ORDINFO_GRID
            // 
            this.ORDINFO_GRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ORDINFO_GRID.Location = new System.Drawing.Point(21, 38);
            this.ORDINFO_GRID.Name = "ORDINFO_GRID";
            this.ORDINFO_GRID.RowTemplate.Height = 25;
            this.ORDINFO_GRID.Size = new System.Drawing.Size(713, 150);
            this.ORDINFO_GRID.TabIndex = 0;
            // 
            // ORD_INFOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 221);
            this.Controls.Add(this.ORDINFO_GRID);
            this.Name = "ORD_INFOForm";
            this.Text = "ORD_INFOForm";
            ((System.ComponentModel.ISupportInitialize)(this.ORDINFO_GRID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ORDINFO_GRID;
    }
}