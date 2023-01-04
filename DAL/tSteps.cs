using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tSteps
    /// </summary>
    public partial class tSteps
    {
        public tSteps()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "tSteps");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tSteps");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.tSteps model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tSteps(");
            strSql.Append("ProgramID,StepType,LiquidID,TipType,SuctionVol,InjectionVol,InjectionPos,BottleSize,BottleNumber,IsHuitu,InjectionTimes)");
            strSql.Append(" values (");
            strSql.Append("@ProgramID,@StepType,@LiquidID,@TipType,@SuctionVol,@InjectionVol,@InjectionPos,@BottleSize,@BottleNumber,@IsHuitu,@InjectionTimes)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ProgramID", OleDbType.Integer,4),
                    new OleDbParameter("@StepType", OleDbType.VarChar,255),
                    new OleDbParameter("@LiquidID", OleDbType.Integer,4),
                    new OleDbParameter("@TipType", OleDbType.Integer,4),
                    new OleDbParameter("@SuctionVol", OleDbType.Integer,4),
                    new OleDbParameter("@InjectionVol", OleDbType.Integer,4),
                    new OleDbParameter("@InjectionPos", OleDbType.VarChar,255),
                    new OleDbParameter("@BottleSize", OleDbType.Integer,4),
                    new OleDbParameter("@BottleNumber", OleDbType.Integer,4),
                    new OleDbParameter("@IsHuitu", OleDbType.Boolean,1),
                    new OleDbParameter("@InjectionTimes", OleDbType.Integer,4)};
            parameters[0].Value = model.ProgramID;
            parameters[1].Value = model.StepType;
            parameters[2].Value = model.LiquidID;
            parameters[3].Value = model.TipType;
            parameters[4].Value = model.SuctionVol;
            parameters[5].Value = model.InjectionVol;
            parameters[6].Value = model.InjectionPos;
            parameters[7].Value = model.BottleSize;
            parameters[8].Value = model.BottleNumber;
            parameters[9].Value = model.IsHuitu;
            parameters[10].Value = model.InjectionTimes;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.tSteps model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tSteps set ");
            strSql.Append("ProgramID=@ProgramID,");
            strSql.Append("StepType=@StepType,");
            strSql.Append("LiquidID=@LiquidID,");
            strSql.Append("TipType=@TipType,");
            strSql.Append("SuctionVol=@SuctionVol,");
            strSql.Append("InjectionVol=@InjectionVol,");
            strSql.Append("InjectionPos=@InjectionPos,");
            strSql.Append("BottleSize=@BottleSize,");
            strSql.Append("BottleNumber=@BottleNumber,");
            strSql.Append("IsHuitu=@IsHuitu,");
            strSql.Append("InjectionTimes=@InjectionTimes");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ProgramID", OleDbType.Integer,4),
                    new OleDbParameter("@StepType", OleDbType.VarChar,255),
                    new OleDbParameter("@LiquidID", OleDbType.Integer,4),
                    new OleDbParameter("@TipType", OleDbType.Integer,4),
                    new OleDbParameter("@SuctionVol", OleDbType.Integer,4),
                    new OleDbParameter("@InjectionVol", OleDbType.Integer,4),
                    new OleDbParameter("@InjectionPos", OleDbType.VarChar,255),
                    new OleDbParameter("@BottleSize", OleDbType.Integer,4),
                    new OleDbParameter("@BottleNumber", OleDbType.Integer,4),
                    new OleDbParameter("@IsHuitu", OleDbType.Boolean,1),
                    new OleDbParameter("@InjectionTimes", OleDbType.Integer,4),
                    new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.ProgramID;
            parameters[1].Value = model.StepType;
            parameters[2].Value = model.LiquidID;
            parameters[3].Value = model.TipType;
            parameters[4].Value = model.SuctionVol;
            parameters[5].Value = model.InjectionVol;
            parameters[6].Value = model.InjectionPos;
            parameters[7].Value = model.BottleSize;
            parameters[8].Value = model.BottleNumber;
            parameters[9].Value = model.IsHuitu;
            parameters[10].Value = model.InjectionTimes;
            parameters[11].Value = model.ID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tSteps ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tSteps ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tSteps GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ProgramID,StepType,LiquidID,TipType,SuctionVol,InjectionVol,InjectionPos,BottleSize,BottleNumber,IsHuitu,InjectionTimes from tSteps ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            Maticsoft.Model.tSteps model = new Maticsoft.Model.tSteps();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tSteps DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tSteps model = new Maticsoft.Model.tSteps();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ProgramID"] != null && row["ProgramID"].ToString() != "")
                {
                    model.ProgramID = int.Parse(row["ProgramID"].ToString());
                }
                if (row["StepType"] != null)
                {
                    model.StepType = row["StepType"].ToString();
                }
                if (row["LiquidID"] != null && row["LiquidID"].ToString() != "")
                {
                    model.LiquidID = int.Parse(row["LiquidID"].ToString());
                }
                if (row["TipType"] != null && row["TipType"].ToString() != "")
                {
                    model.TipType = int.Parse(row["TipType"].ToString());
                }
                if (row["SuctionVol"] != null && row["SuctionVol"].ToString() != "")
                {
                    model.SuctionVol = int.Parse(row["SuctionVol"].ToString());
                }
                if (row["InjectionVol"] != null && row["InjectionVol"].ToString() != "")
                {
                    model.InjectionVol = int.Parse(row["InjectionVol"].ToString());
                }
                if (row["InjectionPos"] != null)
                {
                    model.InjectionPos = row["InjectionPos"].ToString();
                }
                if (row["BottleSize"] != null && row["BottleSize"].ToString() != "")
                {
                    model.BottleSize = int.Parse(row["BottleSize"].ToString());
                }
                if (row["BottleNumber"] != null && row["BottleNumber"].ToString() != "")
                {
                    model.BottleNumber = int.Parse(row["BottleNumber"].ToString());
                }
                if (row["IsHuitu"] != null && row["IsHuitu"].ToString() != "")
                {
                    if ((row["IsHuitu"].ToString() == "1") || (row["IsHuitu"].ToString().ToLower() == "true"))
                    {
                        model.IsHuitu = true;
                    }
                    else
                    {
                        model.IsHuitu = false;
                    }
                }
                if (row["InjectionTimes"] != null && row["InjectionTimes"].ToString() != "")
                {
                    model.InjectionTimes = int.Parse(row["InjectionTimes"].ToString());
                }
            }
            return model;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDataList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select A.*,B.programName ");
            strSql.Append(" FROM tSteps AS A LEFT JOIN tProgram AS B ON A.ProgramID = B.ID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" ORDER BY A.ProgramID");
            return DbHelperOleDb.Query(strSql.ToString());
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ProgramID,StepType,LiquidID,TipType,SuctionVol,InjectionVol,InjectionPos,BottleSize,BottleNumber,IsHuitu,InjectionTimes ");
            strSql.Append(" FROM tSteps ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tSteps ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOleDb.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from tSteps T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  BasicMethod
    }
}

