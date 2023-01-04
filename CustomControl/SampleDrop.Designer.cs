
namespace SampleProcessingSystem.CustomControl
{
    partial class SampleDrop
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            this.SuspendLayout();
            // 
            // uiMarkLabel1
            // 
            this.uiMarkLabel1.Angle = 270;
            this.uiMarkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiMarkLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.uiMarkLabel1.Location = new System.Drawing.Point(6, 23);
            this.uiMarkLabel1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.uiMarkLabel1.MarkSize = 2;
            this.uiMarkLabel1.Name = "uiMarkLabel1";
            this.uiMarkLabel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel1.Size = new System.Drawing.Size(20, 132);
            this.uiMarkLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiMarkLabel1.TabIndex = 0;
            this.uiMarkLabel1.Text = "弃管位";
            this.uiMarkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiMarkLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // SampleDrop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.uiMarkLabel1);
            this.Name = "SampleDrop";
            this.RectSize = 2;
            this.Size = new System.Drawing.Size(33, 179);
            this.Style = Sunny.UI.UIStyle.Custom;
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIMarkLabel uiMarkLabel1;
    }
}
