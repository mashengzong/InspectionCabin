using Sunny.UI;
using System;
using System.Diagnostics;
using System.IO;

namespace SampleProcessingSystem.Pages.InstrumentManage
{
    public partial class FrmSystemLog : UIPage
    {
        string run_logPath = AppDomain.CurrentDomain.BaseDirectory + @"Log/Run_Log/" + DateTime.Now.ToString("yyyy-MM");
        string error_logPath = AppDomain.CurrentDomain.BaseDirectory + @"Log/Error_Log/" + DateTime.Now.ToString("yyyy-MM");

        public FrmSystemLog()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
        }

        /// <summary>
        /// 获取所有运行日志文件
        /// </summary>
        /// <param name="path"></param>
        private void DirSearch(string path, UIListBox uIListBox)
        {
            try
            {
                DirectoryInfo child = new DirectoryInfo(path);
                FileInfo[] fil = child.GetFiles();

                SortAsFileCreationTime(ref fil);// 按创建时间排序
                foreach (FileInfo f in fil)
                {
                    uIListBox.Items.Add(f); //获取文件名
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 按创建时间排序
        /// </summary>
        /// <param name="fil">待排序数组</param>
        private void SortAsFileCreationTime(ref FileInfo[] fil)
        {
            Array.Sort(fil, delegate (FileInfo x, FileInfo y) { return y.CreationTime.CompareTo(x.CreationTime); });
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (uiListBox1.SelectedItems.Count == 0)
            {
                ShowWarningTip("未选择要打开的文件");
                return;
            }
            Process pro = new Process();
            pro.StartInfo.FileName = "notepad.exe ";
            pro.StartInfo.Arguments = run_logPath + @"/" + uiListBox1.SelectedItem;
            pro.Start();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (uiListBox2.SelectedItems.Count == 0)
            {
                ShowWarningTip("未选择要打开的文件");
                return;
            }
            Process pro = new Process();
            pro.StartInfo.FileName = "notepad.exe ";
            pro.StartInfo.Arguments = error_logPath + @"/" + uiListBox2.SelectedItem;
            pro.Start();
        }

        private void uiDatePicker1_ValueChanged(object sender, DateTime value)
        {
            run_logPath = AppDomain.CurrentDomain.BaseDirectory + @"Log/Run_Log/" + uiDatePicker1.Value.ToString("yyyy-MM");
            error_logPath = AppDomain.CurrentDomain.BaseDirectory + @"Log/Error_Log/" + uiDatePicker1.Value.ToString("yyyy-MM");

            uiListBox1.Items.Clear();
            uiListBox2.Items.Clear();

            //运行日志
            if (Directory.Exists(run_logPath))
            {
                if (Directory.GetFiles(run_logPath, "*.log").Length > 0)
                {
                    DirSearch(run_logPath, uiListBox1);
                }
            }

            //错误日志
            if (Directory.Exists(error_logPath))
            {
                if (Directory.GetFiles(error_logPath, "*.log").Length > 0)
                {
                    DirSearch(error_logPath, uiListBox2);
                }
            }
        }
    }
}
