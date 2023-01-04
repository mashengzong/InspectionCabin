using SampleProcessingSystem.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SampleProcessingSystem
{
    public class WaitFormService
    {
        /// <summary>
        /// 创建等待窗口
        /// </summary>
        /// <param name="str"></param>
        public static void CreateWaitForm(string text, IWin32Window owner)
        {
            Instance.CreateForm(text, owner);
        }

        public static void CloseWaitForm()
        {
            WaitFormService.Instance.CloseForm();
        }
        /// <summary>
        /// 界面信息显示
        /// </summary>
        /// <param name="text"></param>
        public static void SetWaitFormCaption(string text)
        {
            Instance.SetFormCaption(text);
        }

        private static WaitFormService _instance;
        private static readonly Object syncLock = new Object();

        public static WaitFormService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new WaitFormService();
                        }
                    }
                }
                return _instance;
            }
        }

        private WaitFormService()
        {
        }

        private Thread waitThread;
        private FrmLoading waitFM;

        public void CreateForm(string text, IWin32Window owner)
        {
            if (waitThread != null)
            {
                try
                {
                    //waitThread.Abort();
                    waitThread = null;
                    waitFM = null;
                }
                catch (Exception e)
                {
                    log4netHelper.Error(e.ToString());
                }
            }

            waitThread = new Thread(new ThreadStart(delegate ()
            {
                waitFM = new FrmLoading(text);
                waitFM.ShowDialog(owner);
                //System.Windows.Forms.Application.Run(waitFM);
            }));
            waitThread.Start();
        }

        public void CloseForm()
        {
            if (waitThread != null)
            {
                try
                {
                    waitFM.SetText("close");
                    //waitThread.Abort();
                    waitThread = null;
                    waitFM = null;
                }
                catch (Exception e)
                {
                    log4netHelper.Error(e.ToString());
                }
            }
        }

        public void SetFormCaption(string text)
        {
            if (waitFM != null)
            {
                try
                {
                    waitFM.SetText(text);
                }
                catch (Exception e)
                {
                    log4netHelper.Error(e.ToString());
                }
            }
        }
    }
}
