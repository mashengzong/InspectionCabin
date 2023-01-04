using Sunny.UI;
using System.Windows.Forms;

namespace SampleProcessingSystem.CustomControl
{
    public partial class InsLayout : UIUserControl
    {
        public InsLayout()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        #region 防止窗体闪烁，放在主窗体任意位置
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED  
                return cp;
            }
        }
        #endregion
    }
}
