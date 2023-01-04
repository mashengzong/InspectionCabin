using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tProgram:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tProgram
    {
        public tProgram()
        { }
        #region Model
        private int _id;
        private string _programname;
        private string _addtime;
        private bool _isdefaut = false;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string programName
        {
            set { _programname = value; }
            get { return _programname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string addTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isDefaut
        {
            set { _isdefaut = value; }
            get { return _isdefaut; }
        }
        #endregion Model

    }
}

