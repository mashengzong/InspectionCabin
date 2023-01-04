using Sunny.UI;
using System;
using System.Windows.Forms;

namespace SampleProcessingSystem
{
    public partial class FrmCheckContinue : UIForm
    {
        public FrmCheckContinue()
        {
            InitializeComponent();
        }

        public FrmCheckContinue(string strMag)
        {
            InitializeComponent();
            uiLabel1.Text = strMag;
        }

        private int resetFlag = 0;//默认继续

        public int mresetFlag
        {
            get
            {
                return resetFlag;
            }

            set
            {
                resetFlag = value;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            resetFlag = 0;
            this.DialogResult = DialogResult.OK;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            resetFlag = 1;
            this.DialogResult = DialogResult.OK;
        }
    }
}
