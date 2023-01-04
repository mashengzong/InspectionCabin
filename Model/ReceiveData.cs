namespace SampleProcessingSystem.Model
{
    /// <summary>
    /// 数据接收封装
    /// </summary>
    public class ReceiveData
    {
        /// <summary>
        /// 接收的帧ID
        /// </summary>
        private string recID = "";

        /// <summary>
        /// 接收标志
        /// </summary>
        private string recFlag = "";

        /// <summary>
        /// 接收参数
        /// </summary>
        private string recOther = "";

        /// <summary>
        /// 异常参数
        /// </summary>
        private string errorInfo = "";

        public ReceiveData(string recID, string recFlag)
        {
            this.RecID = recID;
            this.RecFlag = recFlag;
        }

        public ReceiveData()
        {
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="recID">接收的帧ID</param>
        /// <param name="recFlag">接收标志</param>
        /// <param name="recOther">接收参数</param>
        public ReceiveData(string recID, string recFlag, string recOther)
        {
            this.RecID = recID;
            this.RecFlag = recFlag;
            this.RecOther = recOther;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="recID">接收的帧ID</param>
        /// <param name="recFlag">接收标志</param>
        /// <param name="recOther">接收参数</param>
        /// <param name="errorInfo">异常参数</param>
        public ReceiveData(string recID, string recFlag, string recOther, string errorInfo)
        {
            this.recID = recID;
            this.recFlag = recFlag;
            this.recOther = recOther;
            this.errorInfo = errorInfo;
        }

        public string RecID { get => recID; set => recID = value; }
        public string RecFlag { get => recFlag; set => recFlag = value; }
        public string RecOther { get => recOther; set => recOther = value; }
        public string ErrorInfo { get => errorInfo; set => errorInfo = value; }
    }
}
