using Sunny.UI;

namespace SampleProcessingSystem.Pages.About
{
    public partial class FrmInsConfiguration : UIEditForm
    {
        public FrmInsConfiguration()
        {
            InitializeComponent();
        }

        protected override bool CheckData()
        {
            return CheckEmpty(txtInsNumber, "请输入仪器编号") && CheckEmpty(txtDate, "请选择生产日期");
        }


        private string mInsNumber;

        public string tInsNumber
        {
            get
            {
                mInsNumber = txtInsNumber.Text.PadLeft(4, '0');
                return mInsNumber;
            }
            set
            {
                mInsNumber = value;
            }
        }

        private string mDate;

        public string tDate
        {
            get
            {
                mDate = txtDate.Value.ToString("yyMM");
                return mDate;
            }
            set
            {
                mDate = value;
            }
        }
    }
}
