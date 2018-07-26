namespace FormApp
{
    partial class Main
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
            this.EnumOneChoice = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BitslotLinkLabel = new BitslotLinkLabel();
            this.SuspendLayout();
            // 
            // EnumOneChoice
            // 
            this.EnumOneChoice.Location = new System.Drawing.Point(82, 35);
            this.EnumOneChoice.Name = "EnumOneChoice";
            this.EnumOneChoice.Size = new System.Drawing.Size(693, 156);
            this.EnumOneChoice.TabIndex = 0;
            this.EnumOneChoice.TabStop = false;
            this.EnumOneChoice.Text = "EnumOneChoice";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BitslotLinkLabel
            // 
            this.BitslotLinkLabel.AutoSize = true;
            this.BitslotLinkLabel.Location = new System.Drawing.Point(121, 321);
            this.BitslotLinkLabel.Name = "BitslotLinkLabel";
            this.BitslotLinkLabel.Size = new System.Drawing.Size(53, 17);
            this.BitslotLinkLabel.TabIndex = 2;
            this.BitslotLinkLabel.TabStop = true;
            this.BitslotLinkLabel.Text = "Default";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 695);
            this.Controls.Add(this.BitslotLinkLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EnumOneChoice);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox EnumOneChoice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel BitslotLinkLabel;
    }
}

