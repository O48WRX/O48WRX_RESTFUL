
namespace O48WRX_RESTFULCLIENT.Forms
{
    partial class TokenDialog
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
            this.TD_TokenBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TD_TokenSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kérem adja meg az Adminisztrátori kódot!";
            // 
            // TD_TokenBox
            // 
            this.TD_TokenBox.Location = new System.Drawing.Point(69, 74);
            this.TD_TokenBox.Name = "TD_TokenBox";
            this.TD_TokenBox.Size = new System.Drawing.Size(120, 23);
            this.TD_TokenBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Token:";
            // 
            // TD_TokenSend
            // 
            this.TD_TokenSend.Location = new System.Drawing.Point(69, 127);
            this.TD_TokenSend.Name = "TD_TokenSend";
            this.TD_TokenSend.Size = new System.Drawing.Size(120, 37);
            this.TD_TokenSend.TabIndex = 3;
            this.TD_TokenSend.Text = "Elküld";
            this.TD_TokenSend.UseVisualStyleBackColor = true;
            this.TD_TokenSend.Click += new System.EventHandler(this.TD_TokenSend_Click);
            // 
            // TokenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 189);
            this.Controls.Add(this.TD_TokenSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TD_TokenBox);
            this.Controls.Add(this.label1);
            this.Name = "TokenDialog";
            this.Text = "TokenDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TD_TokenBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TD_TokenSend;
    }
}