﻿namespace FormApp
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 695);
            this.Controls.Add(this.EnumOneChoice);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox EnumOneChoice;
    }
}

