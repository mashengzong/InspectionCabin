namespace SampleProcessingSystem.Model
{
    public class TestProgram
    {
        /// <summary>
        /// 程序id
        /// </summary>
        private int programId;

        /// <summary>
        /// 实验个数
        /// </summary>
        private int totalCount;

        /// <summary>
        /// 程序名称
        /// </summary>
        private string programName;

        /// <summary>
        /// 样本管类型
        /// </summary>
        private int tubeType;

        /// <summary>
        /// 混检类型
        /// </summary>
        private int mixType;

        /// <summary>
        /// 是否扫描
        /// </summary>
        private bool isScan;
        /// <summary>
        ///特定位置吸液
        /// </summary>
        private int suctioPos;
        public TestProgram()
        {

        }

        /// <summary>
        /// 实验信息
        /// </summary>
        /// <param name="programId">程序id</param>
        /// <param name="totalCount">实验个数</param>
        /// <param name="programName">程序名称</param>
        /// <param name="tubeType">样本管类型</param>
        /// <param name="mixType">混检类型</param>
        /// <param name="isScan">是否扫描</param>
        public TestProgram(int programId, int totalCount, string programName, int tubeType, int mixType, bool isScan, int suctioPos)
        {
            this.programId = programId;
            this.totalCount = totalCount;
            this.programName = programName;
            this.tubeType = tubeType;
            this.mixType = mixType;
            this.isScan = isScan;
            this.suctioPos = suctioPos;
        }

        public int ProgramId { get => programId; set => programId = value; }
        public int TotalCount { get => totalCount; set => totalCount = value; }
        public string ProgramName { get => programName; set => programName = value; }
        public int TubeType { get => tubeType; set => tubeType = value; }
        public int MixType { get => mixType; set => mixType = value; }
        public bool IsScan { get => isScan; set => isScan = value; }
        public int SuctioPos { get => suctioPos; set => suctioPos = value; }
    }
}
