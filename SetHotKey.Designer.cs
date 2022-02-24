namespace MicMute
{
    partial class SetHotKey
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
            this.textBoxHotKey = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxHotKey
            // 
            this.textBoxHotKey.Location = new System.Drawing.Point(12, 29);
            this.textBoxHotKey.Name = "textBoxHotKey";
            this.textBoxHotKey.ReadOnly = true;
            this.textBoxHotKey.Size = new System.Drawing.Size(202, 27);
            this.textBoxHotKey.TabIndex = 0;
            this.textBoxHotKey.Click += new System.EventHandler(this.TextBoxHotKey_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(236, 29);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(54, 29);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // SetHotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 84);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.textBoxHotKey);
            this.KeyPreview = true;
            this.Name = "SetHotKey";
            this.Text = "SetHotKey";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetHotKey_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHotKey;
        private System.Windows.Forms.Button okBtn;
    }
}