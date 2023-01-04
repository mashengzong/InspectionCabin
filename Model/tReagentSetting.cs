using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tReagentSetting:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tReagentSetting
    {
        public tReagentSetting()
        { }
        #region Model
        private int _id = 0;
        private int _reagent1 = 0;
        private int _reagent2 = 0;
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
        public int Reagent1
        {
            set { _reagent1 = value; }
            get { return _reagent1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Reagent2
        {
            set { _reagent2 = value; }
            get { return _reagent2; }
        }
        #endregion Model

    }
}

