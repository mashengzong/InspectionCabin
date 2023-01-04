using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tRunRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tRunRecord
    {
        public tRunRecord()
        { }
        #region Model
        private int _id;
        private int _proid;
        private string _runtime;
        private int _totalcount;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProID
        {
            set { _proid = value; }
            get { return _proid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RunTime
        {
            set { _runtime = value; }
            get { return _runtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount
        {
            set { _totalcount = value; }
            get { return _totalcount; }
        }
        #endregion Model

    }
}

