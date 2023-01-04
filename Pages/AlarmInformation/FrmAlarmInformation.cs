using Maticsoft.DBUtility;
using Sunny.UI;
using System;
using System.Windows.Forms;

namespace SampleProcessingSystem.Pages.Alarm_information
{
    public partial class FrmAlarmInformation : UIForm
    {
        public FrmAlarmInformation()
        {
            InitializeComponent();

            startTimes.Value = DateTime.Now;
            endTimes.Value = DateTime.Now;

            uiDataGridView1.DataSource = bll_tAlarmInfo.GetList(" format(AlarmTime,'yyyy-MM-dd HH:mm:ss') between format(#" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00#,'yyyy-MM-dd HH:mm:ss') and format(#" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59#,'yyyy-MM-dd HH:mm:ss') order by ID desc").Tables[0];
        }

        /// <summary>
        /// 设置行号
        /// </summary>
        /// <param name="uIDataGridView"></param>
        /// <param name="e"></param>
        void setRowHeaders(UIDataGridView uIDataGridView, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, uIDataGridView.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), uIDataGridView.RowHeadersDefaultCellStyle.Font, rectangle, uIDataGridView.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private Maticsoft.BLL.tAlarmInfo bll_tAlarmInfo = new Maticsoft.BLL.tAlarmInfo();

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 查询时间段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton13_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(startTimes.Value, endTimes.Value) > 0)
            {
                ShowErrorDialog("起始时间不能大于截止时间!", true);
                return;
            }

            uiDataGridView1.DataSource = bll_tAlarmInfo.GetList(" format(AlarmTime,'yyyy-MM-dd HH:mm:ss') between format(#" + startTimes.Text + "#,'yyyy-MM-dd HH:mm:ss') and format(#" + endTimes.Text + "#,'yyyy-MM-dd HH:mm:ss') order by ID desc").Tables[0];
        }

        /// <summary>
        /// 查询当天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            uiDataGridView1.DataSource = bll_tAlarmInfo.GetList(" format(AlarmTime,'yyyy-MM-dd HH:mm:ss') between format(#" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00#,'yyyy-MM-dd HH:mm:ss') and format(#" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59#,'yyyy-MM-dd HH:mm:ss') order by ID desc").Tables[0];
        }

        /// <summary>
        /// 删除选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (uiDataGridView1.SelectedRows.Count > 0)
                {
                    bll_tAlarmInfo.Delete(int.Parse(uiDataGridView1.CurrentRow.Cells["ID"].Value.ToString()));
                    ShowSuccessTip("删除成功");
                }
                else
                {
                    ShowSuccessTip("未选中行");
                }
            }
            catch (Exception ex)
            {

                ShowErrorDialog("删除失败! " + ex.Message, true);
            }
        }

        /// <summary>
        /// 删除所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            if (ShowAskDialog("确定要删除所有报警信息吗?", true))
            {
                try
                {
                    DbHelperOleDb.ExecuteSql("delete from tAlarmInfo");
                    ShowSuccessTip("删除成功");
                }
                catch (Exception ex)
                {

                    ShowErrorDialog("删除失败! " + ex.Message, true);
                }
            }
        }

        private void uiDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            setRowHeaders(uiDataGridView1, e);
        }
    }
}
