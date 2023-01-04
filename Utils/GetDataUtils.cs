using System.Resources;

namespace SampleProcessingSystem.Utils
{
    public static class GetDataUtils
    {
        #region 配置文件数据

        /// <summary>
        /// 当前软件语言
        /// </summary>
        public static string Cur_Lang = "zh-CN";
        /// <summary>
        /// 分杯舱IP地址
        /// </summary>
        public static bool IsServerIP = false;
        /// <summary>
        /// 分杯舱IP地址
        /// </summary>
        public static string FBServerIP = "";
        /// <summary>
        /// 分杯舱端口号
        /// </summary>
        public static int FBServerPort = 0;
        /// <summary>
        /// 是否自动连接分杯舱控制软件服务器
        /// </summary>
        public static bool FB_IsAutoConn = false;
        /// <summary>
        /// 提取舱控制软件IP地址
        /// </summary>
        public static string TQServerIP = "";
        /// <summary>
        /// 提取舱控制软件端口号
        /// </summary>
        public static int TQServerPort = 0;
        /// <summary>
        /// 是否自动连接提取舱控制软件服务器
        /// </summary>
        public static bool TQ_IsAutoConn = false;
        /// <summary>
        /// 1号检测舱控制软件IP地址
        /// </summary>
        public static string ONEServerIP = "";
        /// <summary>
        /// 1号检测舱控制软件端口号
        /// </summary>
        public static int ONEServerPort = 0;
        /// <summary>
        /// 是否自动连接一号检测舱控制软件服务器
        /// </summary>
        public static bool ONE_IsAutoConn = false;
        /// <summary>
        /// 2号检测舱控制软件IP地址
        /// </summary>
        public static string TWOServerIP = "";
        /// <summary>
        /// 2号检测舱控制软件端口号
        /// </summary>
        public static int TWOServerPort = 0;
        /// <summary>
        /// 是否自动连接二号检测舱控制软件服务器
        /// </summary>
        public static bool TWO_IsAutoConn = false;

        /// <summary>
        /// 检测软件服务器IP地址
        /// </summary>
        public static string ONESELFServerIP = "";
        /// <summary>
        /// 检测软件服务器端口号
        /// </summary>
        public static int ONESELFServerPort = 0;
        /// <summary>
        /// 是否自动打开检测软件服务器
        /// </summary>
        public static bool ONESELFServer_IsAutoConn = false;

        /// <summary>
        /// 检测软件客户端IP地址
        /// </summary>
        public static string ONESELFClientIP = "";
        /// <summary>
        /// 检测软件客户端端口号
        /// </summary>
        public static int ONESELFClientPort = 0;
        /// <summary>
        /// 是否自动打开检测软件客户端
        /// </summary>
        public static bool ONESELFClient_IsAutoConn = false;

        /// <summary>
        /// 提取舱同步关机
        /// </summary>
        public static bool TiQuAutoShuntdown = false;
        /// <summary>
        /// 默认打开照明灯
        /// </summary>
        public static bool DefaultOpenLight = true;
        /// <summary>
        /// 默认打开过滤器
        /// </summary>
        public static bool DefaultOpenFiliter = true;
        /// <summary>
        /// 默认进行条码扫描
        /// </summary>
        public static bool DefaultScanBarcode = false;
        /// <summary>
        /// 探液模式
        /// </summary>
        public static bool IsProbeMode = false;
        /// <summary>
        /// 关盖是否检测样本管
        /// </summary>
        public static bool DetectionTube = false;
        /// <summary>
        /// 分杯提取一起运行
        /// </summary>
        public static bool TestTogether = true;
        /// <summary>
        /// 开机自启动
        /// </summary>
        public static bool AutoRun = true;
        /// <summary>
        /// 整板加样个数
        /// </summary>
        public static int AddSNumber = 96;
        #endregion

        #region 静态变量全局调用

        /// <summary>
        /// 当前软件语言包
        /// </summary>
        public static ResourceManager Language;
        public static Maticsoft.Model.tTipInfo TipType = new Maticsoft.Model.tTipInfo();
        /// <summary> 
        /// 0.初始状态  1.运行界面  2.紫外灯界面  3.关于界面  4.仪器管理界面  5.运行界面  6.弹窗的终止运行界面
        /// </summary>
        public static int CurStatus = 0;
        /// <summary>
        /// 打开照明灯
        /// </summary>
        public static bool IsOpenLight = false;
        /// <summary>
        /// 打开过滤器
        /// </summary>
        public static bool IsOpenFiliter = false;
        /// <summary>
        /// 打开紫外灯
        /// </summary>
        public static bool IsOpenUV = false;
        /// <summary>
        /// 当前操作的菜单
        /// </summary>
        public static int CurPageIndex = 0;
        /// <summary>
        /// 是否正在进行上下位机通信
        /// </summary>
        public static bool IsCommunications = false;
        /// <summary>
        /// 终止运行
        /// </summary>
        public static bool ResetFlag = false;
        /// <summary>
        /// 整板测试完成
        /// </summary>
        public static bool SampleTestFinish = false;
        /// <summary>
        /// 取针XY轴复位
        /// </summary>
        public static bool TipError = false;
        /// <summary>
        /// 重设特定高度
        /// </summary>
        public static bool Re_SuctioPos = false;
        
        #endregion
    }
}
