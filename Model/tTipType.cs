using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tTipType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tTipType
    {
        public tTipType()
        { }
        #region Model
        private int? _id = 0;
        private string _name;
        /// <summary>
        /// 
        /// </summary>
        public int? ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion Model

    }
}

