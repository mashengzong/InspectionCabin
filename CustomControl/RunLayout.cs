using Sunny.UI;
using System.Windows.Forms;

namespace SampleProcessingSystem.CustomControl
{
    public partial class RunLayout : UIUserControl
    {
        public RunLayout()
        {
            this.SetStyle(ControlStyles.UserPaint//使用自定义的绘制方式
    | ControlStyles.ResizeRedraw//当控件大小发生变化时就重新绘制
    | ControlStyles.SupportsTransparentBackColor//则控件接受 alpha 组件数小于 255 个的 BackColor 来模拟透明度
    | ControlStyles.AllPaintingInWmPaint//则控件忽略窗口消息 WM_ERASEBKGND 以减少闪烁,禁止擦除背景
    | ControlStyles.OptimizedDoubleBuffer//则控件将首先绘制到缓冲区而不是直接绘制到屏幕，这可以减少闪烁
    | ControlStyles.DoubleBuffer// 双缓冲
    , true);
            InitializeComponent();
            this.DoubleBuffered = true;
            //asc.controllInitializeSize(this);
        }

        //1.声明自适应类实例
        //AutoSizeFormUtils asc = new AutoSizeFormUtils();

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parms = base.CreateParams;
        //        parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN
        //        return parms;
        //    }
        //}

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

        //private void RunLayout_SizeChanged(object sender, EventArgs e)
        //{
        //    //asc.controlAutoSize(this);
        //}

        //private void RunLayout_Load(object sender, EventArgs e)
        //{
        //    //this.SizeChanged += RunLayout_SizeChanged;
        //}
    }
}
