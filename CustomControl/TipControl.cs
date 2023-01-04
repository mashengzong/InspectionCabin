using Sunny.UI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MoranControl
{
    public partial class TipControl : UIUserControl
    {
        public TipControl()
        {
            this.SetStyle(ControlStyles.UserPaint//使用自定义的绘制方式
    | ControlStyles.ResizeRedraw//当控件大小发生变化时就重新绘制
    | ControlStyles.SupportsTransparentBackColor//则控件接受 alpha 组件数小于 255 个的 BackColor 来模拟透明度
    | ControlStyles.AllPaintingInWmPaint//则控件忽略窗口消息 WM_ERASEBKGND 以减少闪烁,禁止擦除背景
    | ControlStyles.OptimizedDoubleBuffer//则控件将首先绘制到缓冲区而不是直接绘制到屏幕，这可以减少闪烁
    | ControlStyles.DoubleBuffer// 双缓冲
    , true);
            InitializeComponent();
        }

        //修改控件属性方式？
        //96个获取 即把当前信息看作96个对象

        float x = 0;
        float y = 0;
        float width = 0;
        float height = 0;
        private Color _containerColor = Color.Gainsboro;//原容器填充颜色
        public int[,] colors = new int[8, 12];
        public new virtual int[,] fillColor
        {
            get => colors;
            set
            {
                colors = value;
                this.Refresh();
            }
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

        protected override void OnPaint(PaintEventArgs e)
        {     // 使用双缓冲
            this.DoubleBuffered = true;
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < colors.GetLength(1); i++)
            {
                for (int j = 0; j < colors.GetLength(0); j++)
                {
                    Color color = Color.Gainsboro;//原容器填充颜色
                    switch (colors[j, i])
                    {
                        //无tip
                        case 0:
                            color = Color.Gainsboro;
                            break;
                        //无tip   
                        case 2:
                            color = Color.Red;
                            break;
                        //1000ul
                        case 3:
                            color = Color.FromArgb(192, 192, 255);
                            break;
                        //200ul
                        case 4:
                            color = Color.LightSkyBlue;
                            break;
                        //50ul
                        case 5:
                            color = Color.GreenYellow;
                            break;
                        //丢弃不用
                        case 6:
                            color = Color.NavajoWhite;
                            break;
                        default:
                            color = Color.Gainsboro;//原容器填充颜色
                            break;
                    }

                    //黑线
                    using (Pen pen = new Pen(color, 1))
                    {
                        using (Brush brush1 = new SolidBrush(color))
                        {
                            x = 3 + i * 11;
                            y = 3 + j * 11;
                            width = 10;
                            height = 10;
                            graphics.DrawEllipse(pen, x, y, width, height);
                            graphics.FillEllipse(brush1, x, y, width, height);  //绘制圆形
                        }
                    }
                }
            }
            // 圆角半径
            int cRadius = 5;
            Rectangle rect1 = new Rectangle(0, 0, 137, 93);
            // 指定图形路径， 有一系列 直线/曲线 组成
            using (GraphicsPath myPath1 = new GraphicsPath())
            {
                myPath1.StartFigure();
                myPath1.AddArc(new Rectangle(new Point(rect1.X, rect1.Y), new Size(2 * cRadius, 2 * cRadius)), 180, 90);
                myPath1.AddLine(new Point(rect1.X + cRadius, rect1.Y), new Point(rect1.Right - cRadius, rect1.Y));
                myPath1.AddArc(new Rectangle(new Point(rect1.Right - 2 * cRadius, rect1.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
                myPath1.AddLine(new Point(rect1.Right, rect1.Y + cRadius), new Point(rect1.Right, rect1.Bottom - cRadius));
                myPath1.AddArc(new Rectangle(new Point(rect1.Right - 2 * cRadius, rect1.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 0, 90);
                myPath1.AddLine(new Point(rect1.Right - cRadius, rect1.Bottom), new Point(rect1.X + cRadius, rect1.Bottom));
                myPath1.AddArc(new Rectangle(new Point(rect1.X, rect1.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 90, 90);
                myPath1.AddLine(new Point(rect1.X, rect1.Bottom - cRadius), new Point(rect1.X, rect1.Y + cRadius));
                myPath1.CloseFigure();
                graphics.DrawPath(new Pen(Color.FromArgb(80, 160, 255), 1), myPath1);
            }
        }

        public void updateColor(int i, int j, Color color, TipControl tip)
        {

            x = 3 + i * 11;
            y = 3 + j * 11;
            width = 100;
            height = 100;
            Pen pen1 = new Pen(Color.Blue, 1);  //白线
            Graphics g = Graphics.FromHwnd(tip.Handle);
            Brush brush1 = new SolidBrush(color);//框中显示
            g.DrawLine(pen1, 0, 0, 254, 145);
            //g.DrawEllipse(pen1, x, y, width, height);
            //g.FillEllipse(brush1, x, y, width, height);  //绘制圆形
            this.Invalidate();
        }

    }
}
