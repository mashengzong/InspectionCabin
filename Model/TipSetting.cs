using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tTipInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class TipSetting
    {
        public TipSetting()
        { }
        #region Model
        private bool _tip1;
        private bool _tip2;
        private bool _tip3;
        private bool _tip4;
        private bool _tip5;
        private bool _tip6;
        private bool _tip7;
        private bool _tip8;

        public bool Tip1 { get => _tip1; set => _tip1 = value; }
        public bool Tip2 { get => _tip2; set => _tip2 = value; }
        public bool Tip3 { get => _tip3; set => _tip3 = value; }
        public bool Tip4 { get => _tip4; set => _tip4 = value; }
        public bool Tip5 { get => _tip5; set => _tip5 = value; }
        public bool Tip6 { get => _tip6; set => _tip6 = value; }
        public bool Tip7 { get => _tip7; set => _tip7 = value; }
        public bool Tip8 { get => _tip8; set => _tip8 = value; }

        #endregion Model

    }
}

