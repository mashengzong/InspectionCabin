using Aspose.Cells;
using Maticsoft.DBUtility;
using NucleicExtraction.Common;
using SampleProcessingSystem.Model;
using SampleProcessingSystem.Utils;
using Sunny.UI;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SampleProcessingSystem.Pages.InstrumentManage
{
    public partial class FrmInstrumentSettings : UIPage
    {
        public FrmInstrumentSettings()
        {
            InitializeComponent();
        }

        private SocketClientUtilsFB client_FB = new SocketClientUtilsFB();
        private SocketClientUtilsTQ client_TQ = new SocketClientUtilsTQ();
        private SocketClientUtilsONEJC client_ONEJC = new SocketClientUtilsONEJC();
        private SocketClientUtilsTWOJC client_TWOJC = new SocketClientUtilsTWOJC();
        private SocketClientUtilsONESELF client_ONESELF = new SocketClientUtilsONESELF();

        private bool CheckIp(string a)
        {
            return Regex.IsMatch(a, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        #region 分杯仓连接
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            try
            {
                client_FB = new SocketClientUtilsFB();
                client_FB.StartClient();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 分杯仓断开连接
        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            client_FB.DisConnect_FB();
        }
        #endregion

        #region 分杯网口信息保存
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (!CheckIp(uiipTextBox1.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!Tool.IsPositiveIntNoZero(uiTextBox1.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }

            if (SocketClientUtilsFB.IsConnect_FB)
            {
                client_FB.DisConnect_FB();
            }

            IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");

            ini.Write("FBServer", "ServerIP", uiipTextBox1.Text);
            ini.Write("FBServer", "ServerPort", uiTextBox1.IntValue);
            ini.Write("FBServer", "IsAutoConn", uiCheckBox1.Checked);

            GetDataUtils.FBServerIP = uiipTextBox1.Text;
            GetDataUtils.FBServerPort = uiTextBox1.IntValue;
            GetDataUtils.FB_IsAutoConn = uiCheckBox1.Checked;

            uiSymbolButton2.Enabled = true;
            uiSymbolButton3.Enabled = false;

            ShowSuccessDialog("保存成功！");
        }
        #endregion

        #region  提取仓连接信息
        private void uiSymbolButton8_Click(object sender, EventArgs e)
        {
            try
            {
                client_TQ = new SocketClientUtilsTQ();
                client_TQ.StartClient();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 提取仓断开连接
        private void uiSymbolButton9_Click(object sender, EventArgs e)
        {
            client_TQ.DisConnect_TQ();
        }
        #endregion

        #region 提取仓连接信息存储
        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            if (!CheckIp(uiipTextBox2.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!Tool.IsPositiveIntNoZero(uiTextBox2.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }

            if (SocketClientUtilsTQ.IsConnect_TQ)
            {
                client_TQ.DisConnect_TQ();
            }

            IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");

            ini.Write("TQServer", "ServerIP", uiipTextBox2.Text);
            ini.Write("TQServer", "ServerPort", uiTextBox2.IntValue);
            ini.Write("TQServer", "IsAutoConn", uiCheckBox2.Checked);

            GetDataUtils.TQServerIP = uiipTextBox2.Text;
            GetDataUtils.TQServerPort = uiTextBox2.IntValue;
            GetDataUtils.TQ_IsAutoConn = uiCheckBox2.Checked;

            uiSymbolButton8.Enabled = true;
            uiSymbolButton9.Enabled = false;

            ShowSuccessDialog("保存成功！");
        }
        #endregion

        #region 一号检测舱连接信息
        private void uiSymbolButton15_Click(object sender, EventArgs e)
        {
            try
            {
                client_ONEJC = new SocketClientUtilsONEJC();
                client_ONEJC.StartClient();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 一号检测舱连接断开
        private void uiSymbolButton16_Click(object sender, EventArgs e)
        {
            client_ONEJC.DisConnect_ONEJC();
        }
        #endregion

        #region 一号检测舱连接信息保存
        private void uiSymbolButton14_Click(object sender, EventArgs e)
        {
            if (!CheckIp(uiipTextBox3.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!Tool.IsPositiveIntNoZero(uiTextBox3.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }

            if (SocketClientUtilsONEJC.IsConnect_ONEJC)
            {
                client_ONEJC.DisConnect_ONEJC();
            }

            IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");

            ini.Write("ONEServer", "ServerIP", uiipTextBox3.Text);
            ini.Write("ONEServer", "ServerPort", uiTextBox3.IntValue);
            ini.Write("ONEServer", "IsAutoConn", chkAutolineScan.Checked);

            GetDataUtils.ONEServerIP = uiipTextBox3.Text;
            GetDataUtils.ONEServerPort = uiTextBox3.IntValue;
            GetDataUtils.ONE_IsAutoConn = chkAutolineScan.Checked;

            uiSymbolButton15.Enabled = true;
            uiSymbolButton16.Enabled = false;

            ShowSuccessDialog("保存成功！");
        }
        #endregion

        #region 2号检测仓连接信息
        private void uiSymbolButton20_Click(object sender, EventArgs e)
        {
            try
            {
                client_TWOJC = new SocketClientUtilsTWOJC();
                client_TWOJC.StartClient();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 2号检测仓断开连接
        private void uiSymbolButton21_Click(object sender, EventArgs e)
        {
            client_TWOJC.DisConnect_TWOJC();
        }
        #endregion

        #region 2号检测仓链接信息存储
        private void uiSymbolButton19_Click(object sender, EventArgs e)
        {
            if (!CheckIp(uiipTextBox4.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!Tool.IsPositiveIntNoZero(uiTextBox7.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }

            if (SocketClientUtilsTWOJC.IsConnect_TWOJC)
            {
                client_TWOJC.DisConnect_TWOJC();
            }

            IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");

            ini.Write("TWOServer", "ServerIP", uiipTextBox4.Text);
            ini.Write("TWOServer", "ServerPort", uiTextBox7.IntValue);
            ini.Write("TWOServer", "IsAutoConn", uiCheckBox5.Checked);

            GetDataUtils.TWOServerIP = uiipTextBox4.Text;
            GetDataUtils.TWOServerPort = uiTextBox7.IntValue;
            GetDataUtils.TWO_IsAutoConn = uiCheckBox5.Checked;

            uiSymbolButton20.Enabled = true;
            uiSymbolButton21.Enabled = false;

            ShowSuccessDialog("保存成功！");
        }
        #endregion

        public delegate void UpdateEventRunIP();
        public static event UpdateEventRunIP UpdateRunIPEvent;

        #region 检测服务器信息保存
        private void uiSymbolButton13_Click(object sender, EventArgs e)
        {
            if (!Tool.IsPositiveIntNoZero(uiTextBox6.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }

            IniFile confile = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");
            GetDataUtils.ONESELFServerIP = uiipTextBox6.Text;
            GetDataUtils.ONESELFServerPort = int.Parse(uiTextBox6.Text);
            confile.Write("ONESELFServer", "serverIP", uiipTextBox6.Text);
            confile.Write("ONESELFServer", "serverPort", int.Parse(uiTextBox6.Text));
            UpdateRunIPEvent();
        }
        #endregion

        #region 检测仓链接信息保存
        private void uiSymbolButton10_Click(object sender, EventArgs e)
        {
            if (!CheckIp(uiipTextBox5.Text))
            {
                ShowErrorTip("请检查IP地址是否输入正确！");
                return;
            }

            if (!Tool.IsPositiveIntNoZero(uiTextBox4.Text))
            {
                ShowErrorTip("请检查端口号是否输入正确！");
                return;
            }

            if (SocketClientUtilsONESELF.IsConnect_ONESELF)
            {
                client_ONESELF.DisConnect_ONESELF();
            }

            IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");

            ini.Write("ONESELFClient", "ServerIP", uiipTextBox5.Text);
            ini.Write("ONESELFClient", "ServerPort", uiTextBox4.IntValue);
            ini.Write("ONESELFClient", "IsAutoConn", uiCheckBox3.Checked);

            GetDataUtils.TWOServerIP = uiipTextBox5.Text;
            GetDataUtils.TWOServerPort = uiTextBox4.IntValue;
            GetDataUtils.TWO_IsAutoConn = uiCheckBox3.Checked;

            uiSymbolButton11.Enabled = true;
            uiSymbolButton12.Enabled = false;

            ShowSuccessDialog("保存成功！");
        }
        #endregion

        #region 检测仓客户端连接
        private void uiSymbolButton11_Click(object sender, EventArgs e)
        {
            try
            {
                client_ONESELF = new SocketClientUtilsONESELF();
                client_ONESELF.StartClient();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region 检测客户端断开连接
        private void uiSymbolButton12_Click(object sender, EventArgs e)
        {
            client_ONESELF.DisConnect_ONESELF();
        }
        #endregion
    }
}
