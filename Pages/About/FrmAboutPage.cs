using SampleProcessingSystem.Model;
using SampleProcessingSystem.Pages.About;
using SampleProcessingSystem.Utils;
using Sunny.UI;
using System;

namespace SampleProcessingSystem
{
    public partial class FrmAboutPage : UIPage
    {

        SocketClientUtilsTQ client = new SocketClientUtilsTQ();

        public FrmAboutPage()
        {
            InitializeComponent();
        }

        private void FrmAboutPage_ReceiveSuccess(ReceiveData data)
        {
            if (GetDataUtils.CurStatus != 3) return; 
            switch (data.RecFlag)
            {
              
                default:
                    break;
            }
        }


        /// <summary>
        /// 配置仪器编号
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiLine1_DoubleClick(object sender, EventArgs e)
        {

            string value = "";
            if (this.InputPasswordDialog(ref value))
            {
                if (value == "666666")
                {
                    FrmInsConfiguration frmIns = new FrmInsConfiguration();
                    frmIns.Render();
                    frmIns.ShowDialog();
                    if (frmIns.IsOK)
                    {
                        GetDataUtils.IsCommunications = true;
                        GetDataUtils.CurStatus = 3;
                        this.Invoke(new Action(() =>
                        {
                            timer1.Stop();
                            timer1.ReStart();
                        }));
                        client.SendMessage("71 FE 01 00 00 " + frmIns.tDate + frmIns.tInsNumber);
                    }
                    frmIns.Dispose();
                }
                else
                {
                    ShowErrorDialog("密码错误", true);
                }
            }
        }
    }
}