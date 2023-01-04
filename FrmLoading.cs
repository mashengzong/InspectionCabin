using Sunny.UI;

namespace SampleProcessingSystem
{
    public partial class FrmLoading : UIForm
    {
        public FrmLoading(string strWait)
        {
            InitializeComponent();
            SetText(strWait);
        }

        private delegate void SetTextHandler(string text);
        public void SetText(string text)
        {
            if (this.lbl_caption.InvokeRequired)
            {
                this.Invoke(new SetTextHandler(SetText), text);
            }
            else
            {
                if (text == "close")
                    this.Close();
                else
                    this.lbl_caption.Text = text;
                //this.label1.Refresh();
            }
        }
    }
}
