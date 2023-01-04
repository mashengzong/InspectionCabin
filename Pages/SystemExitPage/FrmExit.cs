using SampleProcessingSystem.Utils;
using Sunny.UI;
using System;
using System.Windows.Forms;

namespace SampleProcessingSystem.Pages.SystemExitPage
{
    public partial class FrmExit : UIForm
    {
        public FrmExit()
        {
            InitializeComponent();
            uiCheckBox1.Checked = GetDataUtils.TiQuAutoShuntdown;
            uiCheckBox1.CheckedChanged += uiCheckBox1_CheckedChanged;
            //if (!GetDataUtils.TestTogether)
            //{
            //    uiCheckBox1.Visible = false;
            //}
        }

        public int isExit = 0;//0 取消 1退出软件  2退出并关机

        public int misExit
        {
            get
            {
                return isExit;
            }

            set
            {
                isExit = value;
            }
        }


        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            isExit = 1;
            this.DialogResult = DialogResult.OK;
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            isExit = 2;
            this.DialogResult = DialogResult.OK;
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            isExit = 0;
            this.DialogResult = DialogResult.OK;
        }

        private void uiCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"InsConfig/Config.ini");

            if (uiCheckBox1.Checked)
            {
                GetDataUtils.TiQuAutoShuntdown = true;
                ini.Write("Settings", "TiQuAutoShuntdown", true);
            }
            else
            {
                GetDataUtils.TiQuAutoShuntdown = false;
                ini.Write("Settings", "TiQuAutoShuntdown", false);
            }
        }
    }
}
