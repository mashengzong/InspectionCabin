
namespace SampleProcessingSystem.Pages.SystemExitPage
{
    partial class FrmExit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExit));
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.uiTableLayoutPanel1.SuspendLayout();
            this.uiTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTableLayoutPanel1
            // 
            resources.ApplyResources(this.uiTableLayoutPanel1, "uiTableLayoutPanel1");
            this.uiTableLayoutPanel1.Controls.Add(this.uiTableLayoutPanel2, 0, 1);
            this.uiTableLayoutPanel1.Controls.Add(this.uiCheckBox1, 0, 2);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiTableLayoutPanel2
            // 
            resources.ApplyResources(this.uiTableLayoutPanel2, "uiTableLayoutPanel2");
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton1, 0, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton2, 1, 0);
            this.uiTableLayoutPanel2.Controls.Add(this.uiSymbolButton3, 2, 0);
            this.uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            this.uiTableLayoutPanel2.TagString = null;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiSymbolButton1, "uiSymbolButton1");
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Symbol = 61579;
            this.uiSymbolButton1.SymbolSize = 25;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiSymbolButton2, "uiSymbolButton2");
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Symbol = 57358;
            this.uiSymbolButton2.SymbolSize = 25;
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton2.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // uiSymbolButton3
            // 
            this.uiSymbolButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiSymbolButton3, "uiSymbolButton3");
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.Symbol = 62164;
            this.uiSymbolButton3.SymbolSize = 25;
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton3.Click += new System.EventHandler(this.uiSymbolButton3_Click);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.ImageSize = 20;
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiCheckBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FrmExit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uiTableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExit";
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            this.uiTableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private Sunny.UI.UICheckBox uiCheckBox1;
    }
}