using _29_TCP异步通信之服务器_界面;
using InspectionCabin.Pages.RubPage;
using InspectionCabin.Pages.UVDisinfectionPage;
using SampleProcessingSystem.Model;
using SampleProcessingSystem.Pages.Alarm_information;
using SampleProcessingSystem.Pages.InstrumentManage;
using SampleProcessingSystem.Pages.SystemExitPage;
using SampleProcessingSystem.Utils;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace SampleProcessingSystem
{
    public partial class FrmMainWindow : UIForm
    {
        SocketClientUtilsFB client_FB = new SocketClientUtilsFB();//分杯仓
        SocketClientUtilsTQ client_TQ = new SocketClientUtilsTQ();//提取仓
        SocketClientUtilsTWOJC client_TWOJC = new SocketClientUtilsTWOJC();//二号检测仓
        SocketClientUtilsONEJC client_ONEJC = new SocketClientUtilsONEJC();//一号检测仓
        SocketClientUtilsONESELF client_ONESELF = new SocketClientUtilsONESELF();//检测仓客户端

        public FrmMainWindow()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            uiTabControl1.TabPages.Clear();
            AddPage(new FrmSystemFrontPage());
            SelectPage(1000);
            timer1.Start();
            FrmInstrumentSettings.UpdateRunIPEvent += TcpClient;
        }

        Net server = new Net();
        /// <summary>
        /// 监听检测客户端部分的命令
        /// </summary>
        public void TcpClient()
        {
            server = new Net();
            server.Connnect(GetDataUtils.ONESELFServerIP);//开启监听
            Net.serverConnectSuccess += new Net.ConnectSuccess<IPEndPoint>(show);
            Net.serverReceiveSuccess += new Net.receiveSuccess<string>(ReceiveShow);
        }

        //检测客户端联机成功
        private void show(IPEndPoint boject1)
        {

        }
        private void ReceiveShow(string str)
        {
            switch (str.Substring(0, 4))
            {
                default:
                    break;
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

        //FrmRunning frmRunning = new FrmRunning();
        //FrmRunningDemo frmRunningdemo = new FrmRunningDemo();
        private void RunTest(Model.TestProgram testProgram)
        {
            uiTabControl1.Visible = false;
            uiTabControl1.TabPages.Clear();
            SelectPage(1009);
            uiTabControl1.Visible = true;
        }

        /// <summary>
        /// 分杯仓连接成功事件
        /// </summary>
        /// <param name="str"></param>
        void connectShow_FB(string str)
        {
            if (str == "未联机")
            {
                uiLabel1.ForeColor = Color.Red;
                uiLabel1.Text = "未联机";
            }
            else
            {
                uiLabel1.ForeColor = Color.FromArgb(80, 160, 255);
                uiLabel1.Text = "已联机";
            }
        }

        /// <summary>
        /// 提取仓连接成功事件
        /// </summary>
        /// <param name="str"></param>
        void connectShow_TQ(string str)
        {
            if (str == "未联机")
            {
                uiLabel2.ForeColor = Color.Red;
                uiLabel2.Text = "未联机";
            }
            else
            {
                uiLabel2.ForeColor = Color.FromArgb(80, 160, 255);
                uiLabel2.Text = "已联机";
            }
        }

        /// <summary>
        /// 一号检测仓连接成功事件
        /// </summary>
        /// <param name="str"></param>
        void connectShow_ONEJC(string str)
        {
            if (str == "未联机")
            {
                uiLabel3.ForeColor = Color.Red;
                uiLabel3.Text = "未联机";
            }
            else
            {
                uiLabel3.ForeColor = Color.FromArgb(80, 160, 255);
                uiLabel3.Text = "已联机";
            }
        }

        /// <summary>
        /// 二号检测仓连接成功事件
        /// </summary>
        /// <param name="str"></param>
        void connectShow_TWOJC(string str)
        {
            if (str == "未联机")
            {
                uiLabel4.ForeColor = Color.Red;
                uiLabel4.Text = "未联机";
            }
            else
            {
                uiLabel4.ForeColor = Color.FromArgb(80, 160, 255);
                uiLabel4.Text = "已联机";
            }
        }

        /// <summary>
        /// 检测仓客户端连接成功事件
        /// </summary>
        /// <param name="str"></param>
        void connectShow_ONESELF(string str)
        {
            if (str == "未联机")
            {
                uiLabel4.ForeColor = Color.Red;
                uiLabel4.Text = "未联机";
            }
            else
            {
                uiLabel4.ForeColor = Color.FromArgb(80, 160, 255);
                uiLabel4.Text = "已联机";
            }
        }

        int recCount = 0;
        /// <summary>
        /// 接收数据处理
        /// </summary>
        /// <param name="str"></param>
        void receiveShow(ReceiveData data)
        {
            if (GetDataUtils.CurStatus == 4) return;

            switch (data.RecFlag)
            {

                default:
                    break;
            }
        }

        private bool IsTuozhen = false;
        private bool IsFirstConnect = false;
        private bool IsFirstRunning = false;//首次运行
        private System.Timers.Timer timer = new System.Timers.Timer(20000);//创建定时器，设置间隔时间为1000毫秒；

        private void frmMainWindow_Load(object sender, EventArgs e)
        {
            SocketClientUtilsFB.ClientConnectSuccess += new SocketClientUtilsFB.ConnectSuccess<string>(connectShow_FB);
            client_FB = new SocketClientUtilsFB();

            if (GetDataUtils.FB_IsAutoConn)//自动连接分杯仓软件
            {
                client_FB.StartClient();
            }

            SocketClientUtilsTQ.ClientConnectSuccess += new SocketClientUtilsTQ.ConnectSuccess<string>(connectShow_TQ);
            client_TQ = new SocketClientUtilsTQ();

            if (GetDataUtils.TQ_IsAutoConn)//自动连接提取仓软件
            {
                client_TQ.StartClient();
            }

            SocketClientUtilsONEJC.ClientConnectSuccess += new SocketClientUtilsONEJC.ConnectSuccess<string>(connectShow_ONEJC);
            client_ONEJC = new SocketClientUtilsONEJC();

            if (GetDataUtils.ONE_IsAutoConn)//自动连接一号检测仓软件
            {
                client_ONEJC.StartClient();
            }

            SocketClientUtilsTWOJC.ClientConnectSuccess += new SocketClientUtilsTWOJC.ConnectSuccess<string>(connectShow_TWOJC);
            client_TWOJC = new SocketClientUtilsTWOJC();

            if (GetDataUtils.TWO_IsAutoConn)//自动连接二号检测仓软件
            {
                client_TWOJC.StartClient();
            }

            SocketClientUtilsONESELF.ClientConnectSuccess += new SocketClientUtilsONESELF.ConnectSuccess<string>(connectShow_ONESELF);
            client_ONESELF = new SocketClientUtilsONESELF();

            if (GetDataUtils.ONESELFClient_IsAutoConn)//自动连接检测仓客户端软件
            {
                client_ONESELF.StartClient();
            }
        }



        /// <summary>
        /// 十六进制转换字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }


        FrmSystemFrontPage frmSystemFront = new FrmSystemFrontPage();
        FrmAboutPage frmAboutPage = new FrmAboutPage();
        FrmInstrumentSettings frmInstrumentSettings = new FrmInstrumentSettings();

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmExit frm = new FrmExit();
            frm.Render();
            frm.ShowDialogWithMask();
            if (frm.isExit == 1)//退出软件
            {
                try
                {
                    System.Environment.Exit(0);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (frm.isExit == 2)//退出并关机
            {
                try
                {
                    System.Environment.Exit(0);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            frm.Dispose();
        }

        private void uiHeaderButton3_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new FrmInstrumentSettings());
            SelectPage(1004);
        }

        private void uiHeaderButton4_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new FrmUVDisinfection());
            SelectPage(1005);
        }

        private void uiHeaderButton5_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new FrmAboutPage());
            SelectPage(1006);
        }

        private void uiHeaderButton1_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new FrmRun());
            SelectPage(1007);

        }

        private void uiHeaderButton0_Click(object sender, EventArgs e)
        {
            uiTabControl1.TabPages.Clear();
            AddPage(new FrmSystemFrontPage());
            SelectPage(1000);
            
        }
    }
}