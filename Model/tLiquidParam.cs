using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tLiquidParam:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tLiquidParam
    {
        public tLiquidParam()
        { }
        #region Model
        private int _id;
        private string _paramname;
        private int _sudelay = 0;
        private int _sustartspeed = 0;
        private int _suendspeed = 0;
        private int _sumaxspeed = 0;
        private int _suacceleration = 0;
        private int _subackspeed = 0;
        private int _subackvol = 0;
        private int _sufollowspeed = 0;
        private int _sutipair = 0;
        private int _sutailair = 0;
        private int _inacceleration = 0;
        private int _inmaxspeed = 0;
        private int _inendspeed = 0;
        private int _infollowspeed = 0;
        private int _indelay = 0;
        private int _inbackvol = 0;
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
        public string ParamName
        {
            set { _paramname = value; }
            get { return _paramname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuDelay
        {
            set { _sudelay = value; }
            get { return _sudelay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuStartSpeed
        {
            set { _sustartspeed = value; }
            get { return _sustartspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuEndSpeed
        {
            set { _suendspeed = value; }
            get { return _suendspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuMaxSpeed
        {
            set { _sumaxspeed = value; }
            get { return _sumaxspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuAcceleration
        {
            set { _suacceleration = value; }
            get { return _suacceleration; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuBackSpeed
        {
            set { _subackspeed = value; }
            get { return _subackspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuBackVol
        {
            set { _subackvol = value; }
            get { return _subackvol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuFollowSpeed
        {
            set { _sufollowspeed = value; }
            get { return _sufollowspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuTipAir
        {
            set { _sutipair = value; }
            get { return _sutipair; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SuTailAir
        {
            set { _sutailair = value; }
            get { return _sutailair; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InAcceleration
        {
            set { _inacceleration = value; }
            get { return _inacceleration; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InMaxSpeed
        {
            set { _inmaxspeed = value; }
            get { return _inmaxspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InEndSpeed
        {
            set { _inendspeed = value; }
            get { return _inendspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InFollowSpeed
        {
            set { _infollowspeed = value; }
            get { return _infollowspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InDelay
        {
            set { _indelay = value; }
            get { return _indelay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InBackVol
        {
            set { _inbackvol = value; }
            get { return _inbackvol; }
        }
        #endregion Model

    }
}

