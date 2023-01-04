using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tAlarmInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tAlarmInfo
    {
        public tAlarmInfo()
        { }
        #region Model
        private int _id;
        private string _abnormalcode;
        private int? _abnormalleavel = 0;
        private string _alarminfo;
        private string _suggestion;
        private string _alarmtime;
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
        public string AbnormalCode
        {
            set { _abnormalcode = value; }
            get { return _abnormalcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AbnormalLeavel
        {
            set { _abnormalleavel = value; }
            get { return _abnormalleavel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AlarmInfo
        {
            set { _alarminfo = value; }
            get { return _alarminfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Suggestion
        {
            set { _suggestion = value; }
            get { return _suggestion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AlarmTime
        {
            set { _alarmtime = value; }
            get { return _alarmtime; }
        }
        #endregion Model

    }
}

