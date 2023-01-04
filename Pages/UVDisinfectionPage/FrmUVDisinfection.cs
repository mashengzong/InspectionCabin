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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InspectionCabin.Pages.UVDisinfectionPage
{
    public partial class FrmUVDisinfection : UIPage
    {
        public FrmUVDisinfection()
        {
            InitializeComponent();
            client_ONEJC = new SocketClientUtilsONEJC();
            client_TWOJC = new SocketClientUtilsTWOJC();
            client_TQ = new SocketClientUtilsTQ();
            SocketClientUtilsONEJC.ServerReceiveSuccess += new SocketClientUtilsONEJC.receiveSuccess<ReceiveData>(UVDisinfection_ReceiveSuccess_ONE);
            SocketClientUtilsTWOJC.ServerReceiveSuccess += new SocketClientUtilsTWOJC.receiveSuccess<ReceiveData>(UVDisinfection_ReceiveSuccess_TWO);
        }

        /// <summary>
        /// 一号检测仓收数处理
        /// </summary>
        /// <param name="data"></param>
        private void UVDisinfection_ReceiveSuccess_ONE(ReceiveData data)
        {
            if (GetDataUtils.CurStatus != 2) return;

            switch (data.RecFlag)
            {
               
                default:
                    break;
            }
        }

        /// <summary>
        /// 二号检测仓收数处理
        /// </summary>
        /// <param name="data"></param>
        private void UVDisinfection_ReceiveSuccess_TWO(ReceiveData data)
        {
            if (GetDataUtils.CurStatus != 2) return;

            switch (data.RecFlag)
            {

                default:
                    break;
            }
        }

        private SocketClientUtilsTQ client_TQ;
        private SocketClientUtilsONEJC client_ONEJC;
        private SocketClientUtilsTWOJC client_TWOJC;

        #region 一号检测仓开紫外灯
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (!client_ONEJC.IsConnectSocket_ONEJC())
            {
                ShowErrorTip("未联机");
                return;
            }

            GetDataUtils.CurStatus = 2;
            uiIntegerUpDown1.Enabled = false;
            uiTextBox1.Enabled = false;
            uiSymbolButton1.Enabled = false;
            uiSymbolButton2.Enabled = false;
            client_ONEJC.SendMessage("74 55 00 00 00 00 00 00 00");//开
        }
        #endregion

        #region 二号检测舱开紫外灯
        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            if (!client_TWOJC.IsConnectSocket_TWOJC())
            {
                ShowErrorTip("未联机");
                return;
            }

            GetDataUtils.CurStatus = 2;
            uiIntegerUpDown2.Enabled = false;
            uiTextBox2.Enabled = false;
            uiSymbolButton3.Enabled = false;
            uiSymbolButton4.Enabled = false;
            client_ONEJC.SendMessage("75 55 00 00 00 00 00 00 00");//开
        }
        #endregion

        #region 一号检测仓关闭紫外灯
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (!client_ONEJC.IsConnectSocket_ONEJC())
            {
                ShowErrorTip("未联机");
                return;
            }

            timer1.Stop();
            uiSymbolButton2.Enabled = false;
            client_ONEJC.SendMessage("74 55 01 00 00 00 00 00 00");//关

        }
        #endregion

        #region 二号检测仓关闭紫外灯
        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            if (!client_TWOJC.IsConnectSocket_TWOJC())
            {
                ShowErrorTip("未联机");
                return;
            }

            timer1.Stop();
            uiSymbolButton4.Enabled = false;
            client_ONEJC.SendMessage("75 55 01 00 00 00 00 00 00");//关
        }
        #endregion
    }
}
