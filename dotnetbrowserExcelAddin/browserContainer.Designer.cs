﻿namespace dotnetbrowserExcelAddin
{
    partial class browserContainer
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
            this.browserView1 = new DotNetBrowser.WinForms.BrowserView();
            this.SuspendLayout();
            // 
            // browserView1
            // 
            this.browserView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserView1.Location = new System.Drawing.Point(0, 0);
            this.browserView1.Name = "browserView1";
            this.browserView1.Size = new System.Drawing.Size(800, 450);
            this.browserView1.TabIndex = 0;
            // 
            // browserContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.browserView1);
            this.Name = "browserContainer";
            this.Text = "browserContainer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.browserContainer_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private DotNetBrowser.WinForms.BrowserView browserView1;
    }
}