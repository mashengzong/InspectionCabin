using SampleProcessingSystem.Model;
using SampleProcessingSystem.Utils;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspectionCabin.Pages.RubPage
{
    public partial class FrmRun : UIPage
    {
        public FrmRun()
        {
            InitializeComponent();
            client_ONEJC = new SocketClientUtilsONEJC();
            client_TWOJC = new SocketClientUtilsTWOJC();
            client_ONESELF = new SocketClientUtilsONESELF();
            client_TQ = new SocketClientUtilsTQ();
            SocketClientUtilsONEJC.ServerReceiveSuccess += new SocketClientUtilsONEJC.receiveSuccess<ReceiveData>(FrmRun_ReceiveSuccess_ONE);
            SocketClientUtilsTWOJC.ServerReceiveSuccess += new SocketClientUtilsTWOJC.receiveSuccess<ReceiveData>(FrmRun_ReceiveSuccess_TWO);
            SocketClientUtilsTQ.ServerReceiveSuccess += new SocketClientUtilsTQ.receiveSuccess<ReceiveData>(FrmRun_ReceiveSuccess_TQ);
            SocketClientUtilsONESELF.ServerReceiveSuccess += new SocketClientUtilsONESELF.receiveSuccess<ReceiveData>(FrmRun_ReceiveSuccess_ONESELF);
        }

        private SocketClientUtilsTQ client_TQ;
        private SocketClientUtilsONEJC client_ONEJC;
        private SocketClientUtilsTWOJC client_TWOJC;
        private SocketClientUtilsONESELF client_ONESELF;


        //接收数据以后信号事件触发及触发函数
        public delegate void receiveSuccess<ReceiveData>(ReceiveData str);   //接收数据委托
        public static event receiveSuccess<ReceiveData> ServerReceiveSuccess;
        public virtual void ReceiveComplete(ReceiveData data)//接收数据信号触发函数
        {
            if (ServerReceiveSuccess != null)
                ServerReceiveSuccess(data);
        }


        /// <summary>
        /// 记录封膜舱四个闲置PCR位置信息 按照从左到右记录，分别是12,34
        /// </summary>
        private List<string> TIdlePCR_List = new List<string>();

        /// <summary>
        /// 记录封膜机是否在占用
        /// </summary>
        private bool is_FM = false;

        /// <summary>
        /// 用于封膜舱存储机械位置
        /// </summary>
        int posx = 0;

        /// <summary>
        /// 用于封膜舱存储机械位置
        /// </summary>
        int posy = 0;

        /// <summary>
        /// 用于一号检测舱存储机械位置
        /// </summary>
        int posx_ONE = 0;

        /// <summary>
        /// 用于一号检测舱存储机械位置
        /// </summary>
        int posy_ONE = 0;

        /// <summary>
        /// 用于二号检测舱存储机械位置
        /// </summary>
        int posx_TWO = 0;

        /// <summary>
        /// 用于二号检测舱存储机械位置
        /// </summary>
        int posy_TWO = 0;

        /// <summary>
        /// 记录封膜舱抓板或者放板的位置 1：移板位1进板位 2：移板位2进板位 3：封膜位 4：PCR1位 5：PCR2位 6：移板位出板位
        /// </summary>
        private int Postion = 0;

        /// <summary>
        /// 记录一号检测舱抓板或者放板的位置 1：移板位进板位 2：离心机 3：PCR1 4：PCR2 5：移板位出板位 6：PCR回收位
        /// </summary>
        private int Postion_ONE = 0;

        /// <summary>
        /// 记录二号检测舱抓板或者放板的位置 1：移板位进板位 2：离心机 3：PCR1 4：PCR2 5：PCR回收位
        /// </summary>
        private int Postion_TWO = 0;

        /// <summary>
        /// 记录封膜舱抓板或者放板状态 true代表抓板   false代表放板
        /// </summary>
        private bool is_BanStste = false;

        /// <summary>
        /// 记录一号检测仓抓板或者放板状态 true代表抓板   false代表放板
        /// </summary>
        private bool is_BanStste_ONE = false;

        /// <summary>
        /// 记录二号检测仓抓板或者放板状态 true代表抓板   false代表放板
        /// </summary>
        private bool is_BanStste_TWO = false;

        /// <summary>
        /// 记录一号检测舱和二号检测仓四个PCR使用信息 按照从左到右记录，分别是12,34
        /// </summary>
        private List<string> Use_PCR_List = new List<string>();

        /// <summary>
        /// 记录一号检测舱和二号检测仓离心机使用信息 按照从左到右记录，分别是1、2
        /// </summary>
        private List<string> Use_LX_List = new List<string>();

        /// <summary>
        ///记录封膜舱是否处于使用状态
        /// </summary>
        private bool FMuse = false;

        /// <summary>
        ///记录一号检测舱是否处于使用状态
        /// </summary>
        private bool ONEuse = false;

        /// <summary>
        ///记录二号检测舱是否处于使用状态
        /// </summary>
        private bool TWOuse = false;

        /// <summary>
        /// 记录封膜舱未完成任务存储信息
        /// 1代表移板位1存在样本板  2代表移板位2存在样本板
        /// </summary>
        private List<string> FM_MoveList = new List<string>();

        /// <summary>
        /// 记录一号检测舱未完成任务存储信息
        /// 1代表PCR1完成封膜抓板未处理  2代表PCR2完成封膜抓板未处理  3代表PCR1完成回收位置抓板未处理  4代表PCR2完成回收位置抓板未处理
        /// </summary>
        private List<string> ONE_MoveList = new List<string>();

        /// <summary>
        /// 记录二号检测舱未完成任务存储信息
        /// 1代表PCR1完成封膜抓板未处理  2代表PCR2完成封膜抓板未处理  3代表PCR1完成回收位置抓板未处理  4代表PCR2完成回收位置抓板未处理
        /// </summary>
        private List<string> TWO_MoveList = new List<string>();

        /// <summary>
        /// 封膜舱任务列表执行，当封膜舱闲置时自动进行任务列表循环执行
        /// </summary>
        private void FM_PerformTasks() {
            if (FM_MoveList.Count > 0)
            {
                FMuse = true;//封膜舱置为忙碌状态
                             //执行列表存储第一个任务
                if (FM_MoveList[0].Equals("1"))
                {
                    //1代表移板位一存在样本板
                    FM_MoveList.Remove("1");//移除任务
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "65_646302", "01")); })).Start();
                }
                else if (FM_MoveList[0].Equals("2"))
                {
                    //2代表移板位二存在样本板
                    FM_MoveList.Remove("2");//移除任务
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "65_646302", "02")); })).Start();
                }
            }
            else
            {
                FMuse = false;//封膜舱置为闲置状态
            }
        }

        /// <summary>
        /// 一号检测舱任务列表执行，当一号检测舱闲置时自动进行任务列表循环执行
        /// </summary>
        private void ONE_PerformTasks() {
            if (!ONEuse)
            {
                //封膜舱空闲状态下
                if (ONE_MoveList[0].Equals("1"))
                {
                    //1代表PCR1封膜舱抓板动作未完成
                    ONE_MoveList.Remove("1");//移除任务
                    FMuse = true;//封膜舱置为忙碌状态
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "13_642708")); })).Start();
                }
                else if (ONE_MoveList[0].Equals("2"))
                {
                    //2代表PCR2封膜舱抓板动作未完成
                    ONE_MoveList.Remove("2");//移除任务
                    FMuse = true;//封膜舱置为忙碌状态
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "13_642708")); })).Start();
                }
                else if (ONE_MoveList[0].Equals("3"))
                {
                    //3代表PCR1完成后未抓板至回收位
                    ONE_MoveList.Remove("3");//移除任务
                    ONEuse = true;//一号检测舱置为忙碌状态
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "PCR1执行完成")); })).Start();
                }
                else if (ONE_MoveList[0].Equals("4"))
                {
                    //4代表PCR2完成后未抓板至回收位
                    ONE_MoveList.Remove("4");//移除任务
                    ONEuse = true;//一号检测舱置为忙碌状态
                    new Thread(new ThreadStart(delegate { ReceiveComplete(new ReceiveData("", "PCR2执行完成")); })).Start();
                }

            }
        }

        /// <summary>
        /// 记录一号检测舱PCR回收位是否处于占用状态
        /// </summary>
        private bool ONE_Recovery = false;

        /// <summary>
        /// 记录二号检测舱PCR回收位是否处于占用状态
        /// </summary>
        private bool TWO_Recovery = false;

        /// <summary>
        /// 提取仓收数处理
        /// </summary>
        /// <param name="data"></param>
        private void FrmRun_ReceiveSuccess_TQ(ReceiveData data)
        {
            if (GetDataUtils.IsServerIP) return;//服务端不接收提取端

            switch (data.RecFlag)
            {
                #region 接收提取仓发送的开始初始化指令  执行整机初始化动作
                case "EA0000":

                    break;
                #endregion

                #region 接收提取仓发送封膜舱一号移板位移动到加样位  直接下发一号移板位移动加样位指令
                case "EA0101":
                    client_ONEJC.SendMessage(" 65 63 01 01 00 00 00 00 00 ");//一号移板位移动加样位
                    break;
                #endregion

                #region 接收提取仓发送封膜舱二号移板位移动到加样位  直接下发二号移板位移动加样位指令
                case "EA0102":
                    client_ONEJC.SendMessage(" 65 63 02 01 00 00 00 00 00 ");//二号移板位移动加样位
                    break;
                #endregion

                #region 接收提取仓发送封膜舱一号移板位放板成功  回复提取仓完成，下发一号移板位移动抓手指令
                case "EA0201":
                    client_TQ.SendMessage(" EB 02 00 ");//回复提取仓接收成功
                    client_ONEJC.SendMessage(" 65 63 02 01 00 00 00 00 00 ");//发送一号移板位移动到抓手位
                    break;
                #endregion

                default:
                    break;
            }
        }

        /// <summary>
        /// 检测软件内部收数处理
        /// </summary>
        /// <param name="data"></param>
        private void FrmRun_ReceiveSuccess_ONESELF(ReceiveData data)
        {
            if (GetDataUtils.IsServerIP)
            {
                //服务端
                switch (data.RecFlag)
                {
                    #region 接收客户端发送的移板位移动到加样位
                    case "EA0101":
                        client_ONESELF.SendMessage(" EB 01 00 ");//回复客户端收到
                        client_TWOJC.SendMessage(" 65 63 01 01 00 00 00 00 00 ");//二号检测仓移板位运动到加样位
                        break;
                    #endregion

                    default:
                        break;
                }

            }
            else {
                //客户端
                switch (data.RecFlag)
                {
                    #region 接收服务端发送的完成移板位移动到加样位
                    case "EB0100":
                        //不做处理
                        break;
                    #endregion
                                                                                                                                           
                    default:
                        break;
                }

            }
           
        }

        /// <summary>
        /// 一号检测仓收数处理
        /// </summary>
        /// <param name="data"></param>
        private void FrmRun_ReceiveSuccess_ONE(ReceiveData data)
        {
            if (GetDataUtils.IsServerIP) return;//服务端不接收一号舱收数处理

            switch (data.RecFlag)
            {
                #region 接收封膜舱移板位运动到加样位的返回  执行返回提取仓完成指令
                case "65_646301":
                    client_TQ.SendMessage(" EB 01 00 ");//回复提取仓移板位运动到加样位完成
                    break;
                #endregion

                #region 接收封膜舱移板位运动到抓手位的返回   执行封膜舱抓手移动到对应抓手位位置   此处需要先判断封膜机是否处于闲置状态
                case "65_646302":
                    if (data.RecOther.Equals("01"))
                    {
                        //一号移板位的抓手位
                        Postion = 1;
                        posx = Pos.YB_JB_X1;
                        posy = Pos.YB_JB_Y1;
                    }
                    else
                    {
                        //二号移板位的抓手位
                        Postion = 2;
                        posx = Pos.YB_JB_X2;
                        posy = Pos.YB_JB_Y2;
                    }
                    if (is_FM ||TIdlePCR_List.Count == 4 || FMuse)
                    {
                        //封膜机正在被占用或者四个PCR闲置全部占满，等待处理
                        //封膜舱处于忙碌状态，先将该事件存储，待忙碌完成后进行处理
                        if (data.RecOther.Equals("01"))
                        {
                            //一号移板位
                            FM_MoveList.Add("1");
                        }
                        else
                        {
                            //二号移板位
                            FM_MoveList.Add("2");
                        }
                    }
                    else
                    {
                        //封膜机闲置并且闲置区有空位 直接发送抓板移动
                        FMuse = true;//开始抓板封膜舱置为忙碌状态
                        is_BanStste = true;
                        client_ONEJC.SendMessage(" 53 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    break;
                #endregion

                #region 接收封膜舱抓板XY的移动  执行抓板或者放板
                case "55_642001":
                    if (Postion == 1)
                    {
                        //移板位1进板位
                        if (is_BanStste)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 13 27 03 01 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 13 27 04 01 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion == 2)
                    {
                        //移板位2进板位
                        if (is_BanStste)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 13 27 03 02 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 13 27 04 02 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion == 3)
                    {
                        //封膜位
                        if (is_BanStste)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 13 27 05 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 13 27 06 00 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion == 4)
                    {
                        //PCR1列位
                        if (is_BanStste)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 13 27 07 01 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 13 27 08 01 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion == 5)
                    {
                        //PCR2列位
                        if (is_BanStste)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 13 27 07 02 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 13 27 08 02 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion == 6)
                    {
                        //移板位的出板位
                        if (is_BanStste)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 13 27 09 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 13 27 0a 00 00 00 00 00 00 ");
                        }
                    }
                    break;
                #endregion

                #region 接收封膜舱移板位1、2进板位抓板成功  执行移动到封膜位
                case "13_642703":
                    //封膜位机械位置
                    posx = Pos.FMB_X;
                    posy = Pos.FMB_Y;
                    is_BanStste = false;
                    Postion = 3;
                    client_ONEJC.SendMessage(" 55 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    break;
                #endregion

                #region 接收封膜舱移板位2进板位放板成功
                case "13_642704":

                    break;
                #endregion

                #region 接收封膜舱封膜位抓板成功
                case "13_642705":

                    break;
                #endregion

                #region 接收封膜舱封膜位放板成功  执行开始封膜
                case "13_642706":
                    client_ONEJC.SendMessage(" 10 23 01 00 00 00 00 00 00 ");
                    break;
                #endregion

                #region 接收封膜舱开始封膜  查询当前PCR闲置区是否有空位
                case "10_642301":
                    if (!TIdlePCR_List.Contains("1"))
                    {
                        //PCR1闲置区空闲   执行放置到一号位置
                        Postion = 4;
                        posx = Pos.PCR1_X;
                        posy = Pos.PCR1_Y;
                        TIdlePCR_List.Add("1");
                        is_BanStste = false;
                        client_ONEJC.SendMessage(" 55 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else if (!TIdlePCR_List.Contains("2"))
                    {
                        //PCR2闲置区空闲   执行放置到二号位置
                        Postion = 4;
                        posx = Pos.PCR2_X;
                        posy = Pos.PCR2_Y;
                        TIdlePCR_List.Add("2");
                        is_BanStste = false;
                        client_ONEJC.SendMessage(" 55 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else if (!TIdlePCR_List.Contains("3"))
                    {
                        //PCR3闲置区空闲   执行放置到三号位置
                        Postion = 5;
                        posx = Pos.PCR3_X;
                        posy = Pos.PCR3_Y;
                        TIdlePCR_List.Add("3");
                        is_BanStste = false;
                        client_ONEJC.SendMessage(" 55 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else if (!TIdlePCR_List.Contains("4"))
                    {
                        //PCR4闲置区空闲   执行放置到四号位置
                        Postion = 5;
                        posx = Pos.PCR4_X;
                        posy = Pos.PCR4_Y;
                        TIdlePCR_List.Add("4");
                        is_BanStste = false;
                        client_ONEJC.SendMessage(" 55 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else
                    {
                        //所有闲置区放满，不做处理
                    }
                    break;
                #endregion

                #region 接收封膜舱PCR1、2列抓板成功   执行抓板移动到移板位的出板位
                case "13_642707":
                    Postion = 6;
                    posx = Pos.YB_CB_X;
                    posy = Pos.YB_CB_Y;
                    is_BanStste = false;
                    client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    break;
                #endregion

                #region 接收封膜舱移板位出板位的放板   执行移动到移板位出板位的抓手位并且判断封膜舱是否还有任务未执行完成                                                         
                case "13_64270a":
                    FM_PerformTasks();//此时封膜舱闲置，查询舱内是否有未完成的任务，有就继续执行
                    client_ONEJC.SendMessage(" 66 63 02 01 00 00 00 00 00 ");
                    break;
                #endregion

                #region 接收封膜舱PCR1、2列放板成功   执行查询PCR是否有闲置并且离心机闲置
                case "13_642708":
                    //一号舱离心机和PCR需要同时闲置、二号舱离心机和PCR同时闲置必须保证一号舱抓板处于闲置状态  同时需要保证闲置区有样本板
                    if ((((!Use_PCR_List.Contains("1") || !Use_PCR_List.Contains("2")) && !Use_LX_List.Contains("1")) ||
                        ((!Use_PCR_List.Contains("3") || !Use_PCR_List.Contains("4")) && !Use_LX_List.Contains("2") && !ONEuse))&& TIdlePCR_List.Count>0)
                    {
                        //有PCR闲置并且离心机闲置  执行一号检测仓移板位移动到加样位
                        client_ONEJC.SendMessage(" 66 63 01 01 00 00 00 00 00 ");
                    }
                    else {
                        //此时封膜舱闲置，查询舱内是否有未完成的任务，有就继续执行
                        FM_PerformTasks();
                    }
                    break;
                #endregion

                #region 接收一号检测舱移板位运动到加样位的返回  执行封膜舱PCR闲置区抓板（该处根据顺序进行抓板）
                case "66_646301":
                    if (TIdlePCR_List[0].Equals("1")) {
                        //PCR1闲置
                        Postion = 4;
                        posx = Pos.PCR1_X;
                        posy = Pos.PCR1_Y;
                    }
                    else if (TIdlePCR_List[0].Equals("2"))
                    {
                        //PCR2闲置
                        Postion = 4;
                        posx = Pos.PCR2_X;
                        posy = Pos.PCR2_Y;
                    }
                    else if (TIdlePCR_List[0].Equals("3"))
                    {
                        //PCR3闲置
                        Postion = 5;
                        posx = Pos.PCR3_X;
                        posy = Pos.PCR3_Y;
                    }
                    else if (TIdlePCR_List[0].Equals("4"))
                    {
                        //PCR4闲置
                        Postion = 5;
                        posx = Pos.PCR4_X;
                        posy = Pos.PCR4_Y;
                    }
                    is_BanStste = true;
                    client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    break;
                #endregion

                #region 接收一号检测舱移板位运动到抓手位的返回  一号检测舱执行抓板
                case "66_646302":
                    ONEuse = true;//一号检测舱置为忙碌状态
                    Postion_ONE = 1;
                    posx = Pos.ONE_YB_JB_X;
                    posy = Pos.ONE_YB_JB_Y;
                    is_BanStste_ONE = true;
                    client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    break;
                #endregion

                #region 接收一号检测仓移板XY移动  执行对应的抓板或者放板
                case "56_642001":
                    if (Postion_ONE == 1)
                    {
                        //移板位进板位
                        if (is_BanStste_ONE)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 14 27 03 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 14 27 04 00 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_ONE == 2)
                    {
                        //离心机板位
                        if (is_BanStste_ONE)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 14 27 05 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 14 27 06 00 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_ONE == 3)
                    {
                        //PCR1板位
                        if (is_BanStste_ONE)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 14 27 07 01 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 14 27 07 02 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_ONE == 4)
                    {
                        //PCR2板位
                        if (is_BanStste_ONE)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 14 27 08 01 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 14 27 08 02 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_ONE == 5)
                    {
                        //移板位出板位
                        if (is_BanStste_ONE)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 14 27 09 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 14 27 0a 00 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_ONE == 6)
                    {
                        //PCR回收位
                        if (is_BanStste_ONE)
                        {
                            //抓板
                            client_ONEJC.SendMessage(" 14 27 0b 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_ONEJC.SendMessage(" 14 27 0c 00 00 00 00 00 00 ");
                        }
                    }
                    break;
                #endregion

                #region 接收一号检测舱移板位进板位抓板成功   执行查询闲置离心机和PCR位置
                case "14_642703":
                    if (((!Use_PCR_List.Contains("1") || !Use_PCR_List.Contains("2")) && !Use_LX_List.Contains("1"))){
                        //一号舱PCR和离心机闲置
                        Postion_ONE = 2;
                        posx = Pos.ONE_LXJ_X;
                        posy = Pos.ONE_LXJ_Y;
                        is_BanStste_ONE = false;
                        client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                        return;
                    }

                    if (((!Use_PCR_List.Contains("3") || !Use_PCR_List.Contains("4")) && !Use_LX_List.Contains("2")))
                    {
                        //二号舱PCR和离心机闲置  先通知服务器将移板位运动到加样位      先发送二号舱移板位移动到加样位
                        client_ONESELF.SendMessage(" EA 01 01 ");

                        return;
                    }
                    break;
                #endregion

                #region 接收一号检测舱移板位出板位放板成功  执行移板位出板位运动到抓手位
                case "14_64270a":
                    if (is_BanStste_ONE)
                    {
                        //抓板完成

                    }
                    else
                    {
                        //放板完成
                        client_TWOJC.SendMessage(" 65 63 02 01 00 00 00 00 00 ");//二号检测仓移板位运动到抓手位
                    }
                    break;
                #endregion

                #region 接收一号检测舱离心机板位放板成功  执行开始离心
                case "14_642706":
                    client_ONEJC.SendMessage(" 一号舱开始离心 ");
                    break;
                #endregion

                #region 接收一号检测舱离心机离心结束成功  执行抓板到PCR
                case "一号舱离心结束":
                    if (!Use_PCR_List.Contains("1"))
                    {
                        //一号PCR闲置
                        Postion_ONE = 3;
                        posx = Pos.ONE_PCR1_BW_X;
                        posy = Pos.ONE_PCR1_BW_Y;
                        is_BanStste_ONE = false;
                        client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else if (!Use_PCR_List.Contains("2"))
                    {
                        //二号PCR闲置
                        Postion_ONE = 4;
                        posx = Pos.ONE_PCR2_BW_X;
                        posy = Pos.ONE_PCR2_BW_Y;
                        is_BanStste_ONE = false;
                        client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    break;
                #endregion

                #region 接收一号检测舱PCR1板位放板成功  放板成功后执行开始运行PCR   抓板成功后执行移动到PCR回收位置
                case "14_642707":
                    if (is_BanStste_ONE)
                    {
                        //抓板完成
                        Postion_ONE = 6;
                        posx = Pos.ONE_PCR_HSBW_X;
                        posy = Pos.ONE_PCR_HSBW_Y;
                        is_BanStste_ONE = false;
                        client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else {
                        //放板完成
                        if (ONE_MoveList.Contains("1")) {
                            ONE_MoveList.Remove("1");//如果存在未完成的任务一就直接移除
                        }
                        ONEuse = false;//一号检测舱置为闲置状态
                        client_ONEJC.SendMessage(" 一号舱开始执行PCR ");
                        //同步执行查询有无未完成的任务
                        ONE_PerformTasks();
                    }
                    break;
                #endregion

                #region 接收一号检测舱PCR2板位放板成功  放板成功后执行开始运行PCR   抓板成功后执行移动到PCR回收位置
                case "14_642708":
                    if (is_BanStste_ONE)
                    {
                        //抓板完成
                        Postion_ONE = 6;
                        posx = Pos.ONE_PCR_HSBW_X;
                        posy = Pos.ONE_PCR_HSBW_Y;
                        is_BanStste_ONE = false;
                        client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else
                    {
                        //放板完成
                        ONEuse = false;//一号检测舱置为闲置状态
                        if (ONE_MoveList.Contains("2"))
                        {
                            ONE_MoveList.Remove("2");//如果存在未完成的任务二就直接移除
                        }
                        client_ONEJC.SendMessage(" 一号舱开始执行PCR ");
                        //同步执行查询有无未完成的任务
                        ONE_PerformTasks();
                    }
                    break;
                #endregion

                #region 接收一号检测舱PCR1执行完成  先查询一号检测舱PCR回收位是否处于占用状态
                case "PCR1执行完成":
                    if (ONE_Recovery || !ONEuse)
                    {
                        //一号检测舱PCR回收位处于占用状态或者一号检测舱处于忙碌状态   先将未完成任务记录
                        ONE_MoveList.Add("3");//3代表PCR1未成功抓板至回收位
                    }
                    else
                    {
                        //执行移动到PCR1抓板位置
                        ONEuse = true;//一号检测舱置为忙碌状态
                        Postion_ONE = 3;
                        posx = Pos.ONE_PCR1_BW_X;
                        posy = Pos.ONE_PCR1_BW_Y;
                        is_BanStste_ONE = true;
                        client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    break;
                #endregion

                #region 接收一号检测舱PCR2执行完成  先查询一号检测舱PCR回收位是否处于占用状态
                case "PCR2执行完成":
                    if (ONE_Recovery || !ONEuse)
                    {
                        //一号检测舱PCR回收位处于占用状态或者一号检测舱处于忙碌状态   先将未完成任务记录
                        ONE_MoveList.Add("4");//4代表PCR2未成功抓板至回收位
                    }
                    else
                    {
                        //执行移动到PCR2抓板位置
                        ONEuse = true;//一号检测舱置为忙碌状态
                        Postion_ONE = 4;
                        posx = Pos.ONE_PCR2_BW_X;
                        posy = Pos.ONE_PCR2_BW_Y;
                        is_BanStste_ONE = true;
                        client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    break;
                #endregion

                #region 接收一号检测舱PCR回收放板成功  执行弹窗提示并查询有无未完成的任务
                case "14_64270c":
                    ONEuse = false;//一号检测舱置为空闲状态
                    MessageBox.Show("PCR实验完成");
                    //查询有无未完成任务，继续执行
                    ONE_PerformTasks();
                    break;
                #endregion

                default:
                    break;
            }
        }

        /// <summary>
        /// 二号检测仓收数处理
        /// </summary>
        /// <param name="data"></param>
        private void FrmRun_ReceiveSuccess_TWO(ReceiveData data)
        {
            if (GetDataUtils.CurStatus != 2) return;

            switch (data.RecFlag)
            {
                #region 接收二号检测舱移板位移动到加样位  执行放板
                case "65_646301":
                    Postion_ONE = 5;
                    posx = Pos.ONE_YB_CB_X;
                    posy = Pos.ONE_YB_CB_Y;
                    is_BanStste_ONE = false;
                    client_ONEJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    break;
                #endregion

                #region 接收二号检测舱移板位移动到抓手位  执行抓板
                case "65_646302":
                    Postion_TWO = 1;
                    posx = Pos.TWO_YB_JB_X;
                    posy = Pos.TWO_YB_JB_Y;
                    is_BanStste_TWO = true;
                    client_TWOJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    break;
                #endregion

                #region 接收二号检测仓移板XY移动  执行对应的抓板或者放板
                case "56_642001":
                    if (Postion_TWO == 1)
                    {
                        //移板位进板位
                        if (is_BanStste_TWO)
                        {
                            //抓板
                            client_TWOJC.SendMessage(" 14 27 03 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_TWOJC.SendMessage(" 14 27 04 00 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_TWO == 2)
                    {
                        //离心机板位
                        if (is_BanStste_TWO)
                        {
                            //抓板
                            client_TWOJC.SendMessage(" 14 27 05 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_TWOJC.SendMessage(" 14 27 06 00 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_TWO == 3)
                    {
                        //PCR1板位
                        if (is_BanStste_TWO)
                        {
                            //抓板
                            client_TWOJC.SendMessage(" 14 27 07 01 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_TWOJC.SendMessage(" 14 27 07 02 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_TWO == 4)
                    {
                        //PCR2板位
                        if (is_BanStste_TWO)
                        {
                            //抓板
                            client_TWOJC.SendMessage(" 14 27 08 01 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_TWOJC.SendMessage(" 14 27 08 02 00 00 00 00 00 ");
                        }
                    }
                    else if (Postion_TWO == 5)
                    {
                        //移板位回收位
                        if (is_BanStste_TWO)
                        {
                            //抓板
                            client_TWOJC.SendMessage(" 14 27 0b 00 00 00 00 00 00 ");
                        }
                        else
                        {
                            //放板
                            client_TWOJC.SendMessage(" 14 27 0c 00 00 00 00 00 00 ");
                        }
                    }
                    break;
                #endregion

                #region 接收二号检测舱移板位进板位抓板成功   执行查询闲置离心机和PCR位置
                case "14_642703":
                    if (((!Use_PCR_List.Contains("3") || !Use_PCR_List.Contains("4")) && !Use_PCR_List.Contains("2")))
                    {
                        //二号舱PCR和离心机闲置  发送移动到离心机
                        Postion_TWO = 2;
                        posx = Pos.TWO_LXJ_X;
                        posy = Pos.TWO_LXJ_Y;
                        is_BanStste_TWO = false;
                        client_TWOJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    break;
                #endregion

                #region 接收二号检测舱离心机板位放板成功  执行开始离心
                case "14_642706":
                    client_TWOJC.SendMessage(" 二号舱开始离心 ");
                    break;
                #endregion

                #region 接收二号检测舱离心机离心结束成功  执行抓板到PCR
                case "二号舱离心结束":
                    if (!Use_PCR_List.Contains("3"))
                    {
                        //三号PCR闲置
                        Postion_TWO = 3;
                        posx = Pos.TWO_PCR1_BW_X;
                        posy = Pos.TWO_PCR1_BW_Y;
                        is_BanStste_TWO = false;
                        client_TWOJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    else if (!Use_PCR_List.Contains("4"))
                    {
                        //四号PCR闲置
                        Postion_TWO = 4;
                        posx = Pos.TWO_PCR2_BW_X;
                        posy = Pos.TWO_PCR2_BW_Y;
                        is_BanStste_TWO = false;
                        client_TWOJC.SendMessage(" 56 20 01 " + Convert.ToString(posx, 16).PadLeft(6, '0') + Convert.ToString(posy, 16).PadLeft(6, '0'));
                    }
                    break;
                #endregion

                #region 接收二号检测舱PCR1板位放板成功  执行开始运行PCR
                case "14_642707":
                    if (is_BanStste_TWO)
                    {
                        //抓板完成

                    }
                    else
                    {
                        //放板完成
                        client_TWOJC.SendMessage(" 二号舱开始执行PCR ");
                    }
                    break;
                #endregion

                #region 接收二号检测舱PCR2板位放板成功  执行开始运行PCR
                case "14_642708":
                    if (is_BanStste_TWO)
                    {
                        //抓板完成

                    }
                    else
                    {
                        //放板完成
                        client_TWOJC.SendMessage(" 二号舱开始执行PCR ");
                    }
                    break;
                #endregion

                default:
                    break;
            }
        }

        #region 开始运行
        private void uiButton1_Click(object sender, EventArgs e)
        {
            //三个舱初始化动作
            TIdlePCR_List.Add("1");
            TIdlePCR_List.Add("2");
            TIdlePCR_List.Add("3");
            TIdlePCR_List.Add("4");
            TIdlePCR_List.Remove("1");
            MessageBox.Show(""+ TIdlePCR_List.Count());

        }
        #endregion
    }
}
