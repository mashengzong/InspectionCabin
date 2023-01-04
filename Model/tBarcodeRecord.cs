using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// tBarcodeRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tBarcodeRecord
    {
        public tBarcodeRecord()
        { }
        #region Model
        private int _id;
        private int _recid = 0;
        private int _platecount = 0;
        private int _samplepos = 0;
        private string _barcode;
        private string _errorinfo;
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
        public int RecID
        {
            set { _recid = value; }
            get { return _recid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PlateCount
        {
            set { _platecount = value; }
            get { return _platecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SamplePos
        {
            set { _samplepos = value; }
            get { return _samplepos; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Barcode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorInfo
        {
            set { _errorinfo = value; }
            get { return _errorinfo; }
        }
        #endregion Model

    }
}

