using Sunny.UI;

namespace SampleProcessingSystem
{
    partial class FrmSystemFrontPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemFrontPage));
            this.uiTableLayoutPanel3 = new Sunny.UI.UITableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel3
            // 
            resources.ApplyResources(this.uiTableLayoutPanel3, "uiTableLayoutPanel3");
            this.uiTableLayoutPanel3.Controls.Add(this.pictureBox1, 1, 1);
            this.uiTableLayoutPanel3.Controls.Add(this.uiLabel2, 2, 2);
            this.uiTableLayoutPanel3.Controls.Add(this.uiLabel1, 2, 1);
            this.uiTableLayoutPanel3.Name = "uiTableLayoutPanel3";
            this.uiTableLayoutPanel3.TagString = null;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.uiTableLayoutPanel3.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.TabStop = false;
            // 
            // uiLabel2
            // 
            resources.ApplyResources(this.uiLabel2, "uiLabel2");
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.StyleCustomMode = true;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            resources.ApplyResources(this.uiLabel1, "uiLabel1");
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.StyleCustomMode = true;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FrmSystemFrontPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uiTableLayoutPanel3);
            this.Name = "FrmSystemFrontPage";
            this.PageIndex = 1000;
            this.uiTableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UITableLayoutPanel uiTableLayoutPanel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UILabel uiLabel1;
        private UILabel uiLabel2;
    }
}