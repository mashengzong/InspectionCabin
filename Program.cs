using InspectionCabin.Properties;
using SampleProcessingSystem.Properties;
using SampleProcessingSystem.Utils;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SampleProcessingSystem
{
    static class Program
    {
        /// <summary>
        /// 该函数设置由不同线程产生的窗口的显示状态 
        /// </summary> 
        /// <param name="hWnd">窗口句柄</param> 
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表</param> 
        /// <returns>如果窗口原来可见，返回值为非零；如果窗口原来被隐藏，返回值为零</returns>                     
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        private const int SW_MAX = 3;

        /// <summary> 
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。  
        /// </summary> 
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param> 
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns> 
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] strArray = "1,2,3,4".Split(',');//条码数据
            int a=strArray.Length;
            //这里判断是否已经有实例在运行
            Process instance = RunningInstance();
            if (instance != null) //进程中已经有一个实例在运行
            {
                HandleRunningInstance(instance);
            }
            else
            {
                WinSleepCtr.PreventForCurrentThread();// 阻止系统睡眠，阻止屏幕关闭。

                #region 读取配置文件数据
                IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");

                GetDataUtils.Cur_Lang = ini.ReadString("Language", "Language", "zh-CN");

                GetDataUtils.FBServerIP = ini.ReadString("FBServer", "ServerIP", "");
                GetDataUtils.FBServerPort = ini.ReadInt("FBServer", "ServerPort"); 
                GetDataUtils.FB_IsAutoConn = ini.ReadBool("FBServer", "IsAutoConn");

                GetDataUtils.TQServerIP = ini.ReadString("TQServer", "ServerIP", "");
                GetDataUtils.TQServerPort = ini.ReadInt("TQServer", "ServerPort");
                GetDataUtils.TQ_IsAutoConn = ini.ReadBool("TQServer", "IsAutoConn");

                GetDataUtils.ONEServerIP = ini.ReadString("ONEServer", "ServerIP", "");
                GetDataUtils.ONEServerPort = ini.ReadInt("ONEServer", "ServerPort");
                GetDataUtils.ONE_IsAutoConn = ini.ReadBool("ONEServer", "IsAutoConn");

                GetDataUtils.TWOServerIP = ini.ReadString("TWOServer", "ServerIP", "");
                GetDataUtils.TWOServerPort = ini.ReadInt("TWOServer", "ServerPort");
                GetDataUtils.TWO_IsAutoConn = ini.ReadBool("TWOServer", "IsAutoConn");


                GetDataUtils.TWOServerIP = ini.ReadString("TWOServer", "ServerIP", "");
                GetDataUtils.TWOServerPort = ini.ReadInt("TWOServer", "ServerPort");
                GetDataUtils.TWO_IsAutoConn = ini.ReadBool("TWOServer", "IsAutoConn");


                GetDataUtils.ONESELFServerIP = ini.ReadString("ONESELFServer", "ServerIP", "");
                GetDataUtils.ONESELFServerPort = ini.ReadInt("ONESELFServer", "ServerPort");
                GetDataUtils.ONESELFServer_IsAutoConn = ini.ReadBool("ONESELFServer", "IsAutoConn");



                GetDataUtils.ONESELFClientIP = ini.ReadString("ONESELFClient", "ServerIP", "");
                GetDataUtils.ONESELFClientPort = ini.ReadInt("ONESELFClient", "ServerPort");
                GetDataUtils.ONESELFClient_IsAutoConn = ini.ReadBool("ONESELFClient", "IsAutoConn");


                GetDataUtils.IsServerIP = ini.ReadBool("Settings", "IsServer");
                GetDataUtils.TiQuAutoShuntdown = ini.ReadBool("Settings", "TiQuAutoShuntdown");
                GetDataUtils.DefaultOpenLight = ini.ReadBool("Settings", "DefaultOpenLight");
                GetDataUtils.DefaultOpenFiliter = ini.ReadBool("Settings", "DefaultOpenFiliter");
                GetDataUtils.DefaultScanBarcode = ini.ReadBool("Settings", "DefaultScanBarcode");
                GetDataUtils.IsProbeMode = ini.ReadBool("Settings", "IsProbeMode");
                GetDataUtils.DetectionTube = ini.ReadBool("Settings", "DetectionTube");
                GetDataUtils.TestTogether = ini.ReadBool("Settings", "TestTogether");
                GetDataUtils.AutoRun = ini.ReadBool("Settings", "AutoRun");
                GetDataUtils.AddSNumber = ini.ReadInt("Settings", "AddSNumber");

                AutoRun autoRun = new AutoRun();
                autoRun.SetMeAutoStart(GetDataUtils.AutoRun);//开机自启动
                #endregion

                #region 读取机械位
                IniFile ini2 = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsPos/InsPos.ini");


                #region 封膜舱 [FMPos]

                Pos.YB_JB_X1 = ini2.ReadInt("FMPos", "YB_JB_X1", 0);
                Pos.YB_JB_X2 = ini2.ReadInt("FMPos", "YB_JB_X2", 0);
                Pos.FMB_X = ini2.ReadInt("FMPos", "FMB_X", 0);
                Pos.PCR1_X = ini2.ReadInt("FMPos", "PCR1_X", 0);
                Pos.PCR2_X = ini2.ReadInt("FMPos", "PCR2_X", 0);
                Pos.PCR3_X = ini2.ReadInt("FMPos", "PCR3_X", 0);
                Pos.PCR4_X = ini2.ReadInt("FMPos", "PCR4_X", 0);
                Pos.YB_CB_X = ini2.ReadInt("FMPos", "YB_CB_X", 0);


                Pos.YB_JB_Y1 = ini2.ReadInt("FMPos", "YB_JB_Y1", 0);
                Pos.YB_JB_Y2 = ini2.ReadInt("FMPos", "YB_JB_Y2", 0);
                Pos.FMB_Y = ini2.ReadInt("FMPos", "FMB_Y", 0);
                Pos.PCR1_Y = ini2.ReadInt("FMPos", "PCR1_Y", 0);
                Pos.PCR2_Y = ini2.ReadInt("FMPos", "PCR2_Y", 0);
                Pos.PCR3_Y = ini2.ReadInt("FMPos", "PCR3_Y", 0);
                Pos.PCR4_Y = ini2.ReadInt("FMPos", "PCR4_Y", 0);
                Pos.YB_CB_Y = ini2.ReadInt("FMPos", "YB_CB_Y", 0);
                #endregion

                #region 1号检测舱 [ONEPos]

                Pos.ONE_YB_JB_X = ini2.ReadInt("ONEPos", "ONE_YB_JB_X", 0);
                Pos.ONE_YB_CB_X = ini2.ReadInt("ONEPos", "ONE_YB_CB_X", 0);
                Pos.ONE_LXJ_X = ini2.ReadInt("ONEPos", "ONE_LXJ_X", 0);
                Pos.ONE_PCR1_BW_X = ini2.ReadInt("ONEPos", "ONE_PCR1_BW_X", 0);
                Pos.ONE_PCR2_BW_X = ini2.ReadInt("ONEPos", "ONE_PCR2_BW_X", 0);
                Pos.ONE_PCR_HSBW_X = ini2.ReadInt("ONEPos", "ONE_PCR_HSBW_X", 0);

                Pos.ONE_YB_JB_Y = ini2.ReadInt("ONEPos", "ONE_YB_JB_Y", 0);
                Pos.ONE_YB_CB_Y = ini2.ReadInt("ONEPos", "ONE_YB_CB_Y", 0);
                Pos.ONE_LXJ_Y = ini2.ReadInt("ONEPos", "ONE_LXJ_Y", 0);
                Pos.ONE_PCR1_BW_Y = ini2.ReadInt("ONEPos", "ONE_PCR1_BW_Y", 0);
                Pos.ONE_PCR2_BW_Y = ini2.ReadInt("ONEPos", "ONE_PCR2_BW_Y", 0);
                Pos.ONE_PCR_HSBW_Y = ini2.ReadInt("ONEPos", "ONE_PCR_HSBW_Y", 0);

                #endregion

                #region 2号检测舱 [ONEPos]

                Pos.TWO_YB_JB_X = ini2.ReadInt("TWOPos", "TWO_YB_JB_X", 0);
                Pos.TWO_YB_CB_X = ini2.ReadInt("TWOPos", "TWO_YB_CB_X", 0);
                Pos.TWO_LXJ_X = ini2.ReadInt("TWOPos", "TWO_LXJ_X", 0);
                Pos.TWO_PCR1_BW_X = ini2.ReadInt("TWOPos", "TWO_PCR1_BW_X", 0);
                Pos.TWO_PCR2_BW_X = ini2.ReadInt("TWOPos", "TWO_PCR2_BW_X", 0);
                Pos.TWO_PCR_HSBW_X = ini2.ReadInt("TWOPos", "TWO_PCR_HSBW_X", 0);

                Pos.TWO_YB_JB_Y = ini2.ReadInt("TWOPos", "TWO_YB_JB_Y", 0);
                Pos.TWO_YB_CB_Y = ini2.ReadInt("TWOPos", "TWO_YB_CB_Y", 0);
                Pos.TWO_LXJ_Y = ini2.ReadInt("TWOPos", "TWO_LXJ_Y", 0);
                Pos.TWO_PCR1_BW_Y = ini2.ReadInt("TWOPos", "TWO_PCR1_BW_Y", 0);
                Pos.TWO_PCR2_BW_Y = ini2.ReadInt("TWOPos", "TWO_PCR2_BW_Y", 0);
                Pos.TWO_PCR_HSBW_Y = ini2.ReadInt("TWOPos", "TWO_PCR_HSBW_Y", 0);

                #endregion

                #endregion


                Maticsoft.BLL.tTipInfo bll_tTipInfo = new Maticsoft.BLL.tTipInfo();
                GetDataUtils.TipType = bll_tTipInfo.GetModel(97);//97存储tip类型


                if (GetDataUtils.Cur_Lang == "zh-CN")
                {
                    UILocalizeHelper.SetCH();
                }
                else
                {
                    UILocalizeHelper.SetEN();
                }
                GetDataUtils.Language = new ResourceManager("SampleProcessingSystem.Properties.Language_" + GetDataUtils.Cur_Lang, typeof(Resources).Assembly);
                LanguageHelper.SetAllLang(GetDataUtils.Cur_Lang);//设置语言

                try
                {
                    //处理未捕获的异常   
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    //处理UI线程异常   
                    Application.ThreadException += Application_ThreadException;
                    //处理非UI线程异常   
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    //只能启动一个应用程序
                    var aProcessName = Process.GetCurrentProcess().ProcessName;
                    //if ((Process.GetProcessesByName(aProcessName)).GetUpperBound(0) > 0)
                    //{
                    //    MessageBox.Show("已经运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //}
                    //else
                    //{
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmMainWindow());
                    //}
                }
                catch (Exception ex)
                {
                    log4netHelper.Error("Application_ThreadException", ex);
                    MessageBox.Show("Application_ThreadException" + ex);
                }

            }
        }

        #region 在进程中查找是否已经有实例在运行
        //确保程序只运行一个实例
        public static Process RunningInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] Processes = Process.GetProcessesByName(currentProcess.ProcessName);
            //遍历与当前进程名称相同的进程列表
            foreach (Process process in Processes)
            {
                //如果实例已经存在,则忽略当前进程
                if (process.Id != currentProcess.Id)
                {
                    //保证要打开的进程 同 已经存在的进程来自同一个文件路径
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
                    {
                        //返回另一个进程实例
                        return process;
                    }
                }
            }
            return null; //找不到其他进程实例，返回nulL。         
        }
        #endregion


        #region 调用Win32API,进程中已经有一个实例在运行,激活其窗口并显示在最前端
        private static void HandleRunningInstance(Process instance)
        {
            //MessageBox.Show("已经在运行!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ShowWindowAsync(instance.MainWindowHandle, SW_MAX);//调用API函数,正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle);//将窗口放置在最前端 
        }
        #endregion

        ///<summary>
        ///  处理UI线程异常 
        ///</summary>
        ///<param name="sender"> </param>
        ///<param name="e"> </param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (ex != null)
            {
                log4netHelper.Error("ThreadException", ex);
            }

            MessageBox.Show("ThreadException" + ex);
        }

        /// <summary>
        /// 处理非UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                log4netHelper.Error("UnhandledException", ex);
            }

            MessageBox.Show("UnhandledException" + ex);
        }
    }
}
