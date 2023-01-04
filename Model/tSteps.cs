using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tSteps:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tSteps
    {
        public tSteps()
        { }
        #region Model
        private int _id;
        private int? _programid = 0;
        private string _steptype;
        private int? _liquidid = 0;
        private int? _tiptype = 0;
        private int? _suctionvol = 0;
        private int? _injectionvol = 0;
        private string _injectionpos = "";
        private int? _bottlesize = 0;
        private int? _bottlenumber = 0;
        private bool _ishuitu = false;
        private int? _injectiontimes = 0;
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
        public int? ProgramID
        {
            set { _programid = value; }
            get { return _programid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StepType
        {
            set { _steptype = value; }
            get { return _steptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LiquidID
        {
            set { _liquidid = value; }
            get { return _liquidid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TipType
        {
            set { _tiptype = value; }
            get { return _tiptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SuctionVol
        {
            set { _suctionvol = value; }
            get { return _suctionvol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? InjectionVol
        {
            set { _injectionvol = value; }
            get { return _injectionvol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InjectionPos
        {
            set { _injectionpos = value; }
            get { return _injectionpos; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BottleSize
        {
            set { _bottlesize = value; }
            get { return _bottlesize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BottleNumber
        {
            set { _bottlenumber = value; }
            get { return _bottlenumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsHuitu
        {
            set { _ishuitu = value; }
            get { return _ishuitu; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? InjectionTimes
        {
            set { _injectiontimes = value; }
            get { return _injectiontimes; }
        }
        #endregion Model

    }
}

