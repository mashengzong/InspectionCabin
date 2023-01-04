using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tLiquidParam
    /// </summary>
    public partial class tLiquidParam
    {
        public tLiquidParam()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "tLiquidParam");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tLiquidParam");
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
        public bool Add(Maticsoft.Model.tLiquidParam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tLiquidParam(");
            strSql.Append("ParamName,SuDelay,SuStartSpeed,SuEndSpeed,SuMaxSpeed,SuAcceleration,SuBackSpeed,SuBackVol,SuFollowSpeed,SuTipAir,SuTailAir,InAcceleration,InMaxSpeed,InEndSpeed,InFollowSpeed,InDelay,InBackVol)");
            strSql.Append(" values (");
            strSql.Append("@ParamName,@SuDelay,@SuStartSpeed,@SuEndSpeed,@SuMaxSpeed,@SuAcceleration,@SuBackSpeed,@SuBackVol,@SuFollowSpeed,@SuTipAir,@SuTailAir,@InAcceleration,@InMaxSpeed,@InEndSpeed,@InFollowSpeed,@InDelay,@InBackVol)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ParamName", OleDbType.VarChar,255),
                    new OleDbParameter("@SuDelay", OleDbType.Integer,4),
                    new OleDbParameter("@SuStartSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuEndSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuMaxSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuAcceleration", OleDbType.Integer,4),
                    new OleDbParameter("@SuBackSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuBackVol", OleDbType.Integer,4),
                    new OleDbParameter("@SuFollowSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuTipAir", OleDbType.Integer,4),
                    new OleDbParameter("@SuTailAir", OleDbType.Integer,4),
                    new OleDbParameter("@InAcceleration", OleDbType.Integer,4),
                    new OleDbParameter("@InMaxSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@InEndSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@InFollowSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@InDelay", OleDbType.Integer,4),
                    new OleDbParameter("@InBackVol", OleDbType.Integer,4)};
            parameters[0].Value = model.ParamName;
            parameters[1].Value = model.SuDelay;
            parameters[2].Value = model.SuStartSpeed;
            parameters[3].Value = model.SuEndSpeed;
            parameters[4].Value = model.SuMaxSpeed;
            parameters[5].Value = model.SuAcceleration;
            parameters[6].Value = model.SuBackSpeed;
            parameters[7].Value = model.SuBackVol;
            parameters[8].Value = model.SuFollowSpeed;
            parameters[9].Value = model.SuTipAir;
            parameters[10].Value = model.SuTailAir;
            parameters[11].Value = model.InAcceleration;
            parameters[12].Value = model.InMaxSpeed;
            parameters[13].Value = model.InEndSpeed;
            parameters[14].Value = model.InFollowSpeed;
            parameters[15].Value = model.InDelay;
            parameters[16].Value = model.InBackVol;

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
        public bool Update(Maticsoft.Model.tLiquidParam model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tLiquidParam set ");
            strSql.Append("ParamName=@ParamName,");
            strSql.Append("SuDelay=@SuDelay,");
            strSql.Append("SuStartSpeed=@SuStartSpeed,");
            strSql.Append("SuEndSpeed=@SuEndSpeed,");
            strSql.Append("SuMaxSpeed=@SuMaxSpeed,");
            strSql.Append("SuAcceleration=@SuAcceleration,");
            strSql.Append("SuBackSpeed=@SuBackSpeed,");
            strSql.Append("SuBackVol=@SuBackVol,");
            strSql.Append("SuFollowSpeed=@SuFollowSpeed,");
            strSql.Append("SuTipAir=@SuTipAir,");
            strSql.Append("SuTailAir=@SuTailAir,");
            strSql.Append("InAcceleration=@InAcceleration,");
            strSql.Append("InMaxSpeed=@InMaxSpeed,");
            strSql.Append("InEndSpeed=@InEndSpeed,");
            strSql.Append("InFollowSpeed=@InFollowSpeed,");
            strSql.Append("InDelay=@InDelay,");
            strSql.Append("InBackVol=@InBackVol");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ParamName", OleDbType.VarChar,255),
                    new OleDbParameter("@SuDelay", OleDbType.Integer,4),
                    new OleDbParameter("@SuStartSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuEndSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuMaxSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuAcceleration", OleDbType.Integer,4),
                    new OleDbParameter("@SuBackSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuBackVol", OleDbType.Integer,4),
                    new OleDbParameter("@SuFollowSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@SuTipAir", OleDbType.Integer,4),
                    new OleDbParameter("@SuTailAir", OleDbType.Integer,4),
                    new OleDbParameter("@InAcceleration", OleDbType.Integer,4),
                    new OleDbParameter("@InMaxSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@InEndSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@InFollowSpeed", OleDbType.Integer,4),
                    new OleDbParameter("@InDelay", OleDbType.Integer,4),
                    new OleDbParameter("@InBackVol", OleDbType.Integer,4),
                    new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.ParamName;
            parameters[1].Value = model.SuDelay;
            parameters[2].Value = model.SuStartSpeed;
            parameters[3].Value = model.SuEndSpeed;
            parameters[4].Value = model.SuMaxSpeed;
            parameters[5].Value = model.SuAcceleration;
            parameters[6].Value = model.SuBackSpeed;
            parameters[7].Value = model.SuBackVol;
            parameters[8].Value = model.SuFollowSpeed;
            parameters[9].Value = model.SuTipAir;
            parameters[10].Value = model.SuTailAir;
            parameters[11].Value = model.InAcceleration;
            parameters[12].Value = model.InMaxSpeed;
            parameters[13].Value = model.InEndSpeed;
            parameters[14].Value = model.InFollowSpeed;
            parameters[15].Value = model.InDelay;
            parameters[16].Value = model.InBackVol;
            parameters[17].Value = model.ID;

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
            strSql.Append("delete from tLiquidParam ");
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
            strSql.Append("delete from tLiquidParam ");
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
        public Maticsoft.Model.tLiquidParam GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ParamName,SuDelay,SuStartSpeed,SuEndSpeed,SuMaxSpeed,SuAcceleration,SuBackSpeed,SuBackVol,SuFollowSpeed,SuTipAir,SuTailAir,InAcceleration,InMaxSpeed,InEndSpeed,InFollowSpeed,InDelay,InBackVol from tLiquidParam ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            Maticsoft.Model.tLiquidParam model = new Maticsoft.Model.tLiquidParam();
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
        public Maticsoft.Model.tLiquidParam DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tLiquidParam model = new Maticsoft.Model.tLiquidParam();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ParamName"] != null)
                {
                    model.ParamName = row["ParamName"].ToString();
                }
                if (row["SuDelay"] != null && row["SuDelay"].ToString() != "")
                {
                    model.SuDelay = int.Parse(row["SuDelay"].ToString());
                }
                if (row["SuStartSpeed"] != null && row["SuStartSpeed"].ToString() != "")
                {
                    model.SuStartSpeed = int.Parse(row["SuStartSpeed"].ToString());
                }
                if (row["SuEndSpeed"] != null && row["SuEndSpeed"].ToString() != "")
                {
                    model.SuEndSpeed = int.Parse(row["SuEndSpeed"].ToString());
                }
                if (row["SuMaxSpeed"] != null && row["SuMaxSpeed"].ToString() != "")
                {
                    model.SuMaxSpeed = int.Parse(row["SuMaxSpeed"].ToString());
                }
                if (row["SuAcceleration"] != null && row["SuAcceleration"].ToString() != "")
                {
                    model.SuAcceleration = int.Parse(row["SuAcceleration"].ToString());
                }
                if (row["SuBackSpeed"] != null && row["SuBackSpeed"].ToString() != "")
                {
                    model.SuBackSpeed = int.Parse(row["SuBackSpeed"].ToString());
                }
                if (row["SuBackVol"] != null && row["SuBackVol"].ToString() != "")
                {
                    model.SuBackVol = int.Parse(row["SuBackVol"].ToString());
                }
                if (row["SuFollowSpeed"] != null && row["SuFollowSpeed"].ToString() != "")
                {
                    model.SuFollowSpeed = int.Parse(row["SuFollowSpeed"].ToString());
                }
                if (row["SuTipAir"] != null && row["SuTipAir"].ToString() != "")
                {
                    model.SuTipAir = int.Parse(row["SuTipAir"].ToString());
                }
                if (row["SuTailAir"] != null && row["SuTailAir"].ToString() != "")
                {
                    model.SuTailAir = int.Parse(row["SuTailAir"].ToString());
                }
                if (row["InAcceleration"] != null && row["InAcceleration"].ToString() != "")
                {
                    model.InAcceleration = int.Parse(row["InAcceleration"].ToString());
                }
                if (row["InMaxSpeed"] != null && row["InMaxSpeed"].ToString() != "")
                {
                    model.InMaxSpeed = int.Parse(row["InMaxSpeed"].ToString());
                }
                if (row["InEndSpeed"] != null && row["InEndSpeed"].ToString() != "")
                {
                    model.InEndSpeed = int.Parse(row["InEndSpeed"].ToString());
                }
                if (row["InFollowSpeed"] != null && row["InFollowSpeed"].ToString() != "")
                {
                    model.InFollowSpeed = int.Parse(row["InFollowSpeed"].ToString());
                }
                if (row["InDelay"] != null && row["InDelay"].ToString() != "")
                {
                    model.InDelay = int.Parse(row["InDelay"].ToString());
                }
                if (row["InBackVol"] != null && row["InBackVol"].ToString() != "")
                {
                    model.InBackVol = int.Parse(row["InBackVol"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ParamName,SuDelay,SuStartSpeed,SuEndSpeed,SuMaxSpeed,SuAcceleration,SuBackSpeed,SuBackVol,SuFollowSpeed,SuTipAir,SuTailAir,InAcceleration,InMaxSpeed,InEndSpeed,InFollowSpeed,InDelay,InBackVol ");
            strSql.Append(" FROM tLiquidParam ");
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
            strSql.Append("select count(1) FROM tLiquidParam ");
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
            strSql.Append(")AS Row, T.*  from tLiquidParam T ");
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

