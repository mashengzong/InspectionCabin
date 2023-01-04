using Sunny.UI;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MoranControl
{
    public partial class DeepControl : UIUserControl
    {
        public DeepControl()
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

        public int[,] colors = new int[8, 12];

        public new int[,] fillColor
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

        private readonly Font font = new Font("微软雅黑", 5, FontStyle.Bold);
        private readonly Brush brush = new SolidBrush(Color.FromArgb(80, 160, 255));
        private readonly Pen pen1 = new Pen(Color.White, 1);
        private readonly Rectangle rect1 = new Rectangle(0, 0, 145, 100);
        private readonly Rectangle rect = new Rectangle(9, 9, 133, 88);// 要实现 圆角化的 矩形
        /// <summary>
        ///   画布大小  x280 y180  留出上和左位置来 各40把 还剩 x240 y140   
        ///   240/12=20  宽
        ///   140/8=17.5 高
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // 使用双缓冲
            this.DoubleBuffered = true;
            base.OnPaint(e);
            using (Graphics graphics = e.Graphics)
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                for (int i = 0; i < 12; i++)
                {
                    graphics.DrawString((i + 1).ToString(), font, brush, (float)(11 + i * 11), 0);
                }

                for (int i = 0; i < colors.GetLength(1); i++)
                {
                    for (int j = 0; j < colors.GetLength(0); j++)
                    {
                        Color color = Color.White;//原容器填充颜色
                        switch (colors[j, i])
                        {
                            //空
                            case 0:
                                color = Color.Gainsboro;
                                break;
                            //有   
                            case 1:
                                color = Color.LightSkyBlue;
                                break;
                            //加样异常   
                            case 2:
                                color = Color.Red;
                                break;
                            default:
                                color = Color.Gainsboro;//原容器填充颜色
                                break;
                        }

                        //黑线
                        using (Brush brush1 = new SolidBrush(color))
                        {
                            float x = 11 + (float)(i * 11);
                            float y = 11 + (float)(j * 11);
                            float width = 10;
                            float height = 10;
                            graphics.DrawRectangle(pen1, x, y, width, height);
                            graphics.FillRectangle(brush1, x, y, width, height);  //绘制圆形
                        }
                    }
                }

                graphics.DrawString("A", font, brush, 1, 13);
                graphics.DrawString("B", font, brush, 1, 24);
                graphics.DrawString("C", font, brush, 1, 35);
                graphics.DrawString("D", font, brush, 1, 46);
                graphics.DrawString("E", font, brush, 1, 57);
                graphics.DrawString("F", font, brush, 1, 68);
                graphics.DrawString("G", font, brush, 1, 79);
                graphics.DrawString("H", font, brush, 1, 90);

                // 圆角半径
                int cRadius = 5;

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

                // 指定图形路径， 有一系列 直线/曲线 组成
                using (GraphicsPath myPath = new GraphicsPath())
                {
                    myPath.StartFigure();
                    myPath.AddArc(new Rectangle(new Point(rect.X, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 180, 90);
                    myPath.AddLine(new Point(rect.X + cRadius, rect.Y), new Point(rect.Right - cRadius, rect.Y));
                    myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Y), new Size(2 * cRadius, 2 * cRadius)), 270, 90);
                    myPath.AddLine(new Point(rect.Right, rect.Y + cRadius), new Point(rect.Right, rect.Bottom - cRadius));
                    myPath.AddArc(new Rectangle(new Point(rect.Right - 2 * cRadius, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 0, 90);
                    myPath.AddLine(new Point(rect.Right - cRadius, rect.Bottom), new Point(rect.X + cRadius, rect.Bottom));
                    myPath.AddArc(new Rectangle(new Point(rect.X, rect.Bottom - 2 * cRadius), new Size(2 * cRadius, 2 * cRadius)), 90, 90);
                    myPath.AddLine(new Point(rect.X, rect.Bottom - cRadius), new Point(rect.X, rect.Y + cRadius));
                    myPath.CloseFigure();
                    graphics.DrawPath(new Pen(Color.AliceBlue, 1), myPath);
                }
            }

        }
    }
}
