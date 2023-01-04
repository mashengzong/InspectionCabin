using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tAlarmInfo
    /// </summary>
    public partial class tAlarmInfo
    {
        public tAlarmInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "tAlarmInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tAlarmInfo");
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
        public bool Add(Maticsoft.Model.tAlarmInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tAlarmInfo(");
            strSql.Append("AbnormalCode,AbnormalLeavel,AlarmInfo,Suggestion,AlarmTime)");
            strSql.Append(" values (");
            strSql.Append("@AbnormalCode,@AbnormalLeavel,@AlarmInfo,@Suggestion,@AlarmTime)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@AbnormalCode", OleDbType.VarChar,100),
                    new OleDbParameter("@AbnormalLeavel", OleDbType.Integer,4),
                    new OleDbParameter("@AlarmInfo", OleDbType.VarChar,255),
                    new OleDbParameter("@Suggestion", OleDbType.VarChar,100),
                    new OleDbParameter("@AlarmTime", OleDbType.VarChar,50)};
            parameters[0].Value = model.AbnormalCode;
            parameters[1].Value = model.AbnormalLeavel;
            parameters[2].Value = model.AlarmInfo;
            parameters[3].Value = model.Suggestion;
            parameters[4].Value = model.AlarmTime;

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
        public bool Update(Maticsoft.Model.tAlarmInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tAlarmInfo set ");
            strSql.Append("AbnormalCode=@AbnormalCode,");
            strSql.Append("AbnormalLeavel=@AbnormalLeavel,");
            strSql.Append("AlarmInfo=@AlarmInfo,");
            strSql.Append("Suggestion=@Suggestion,");
            strSql.Append("AlarmTime=@AlarmTime");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@AbnormalCode", OleDbType.VarChar,100),
                    new OleDbParameter("@AbnormalLeavel", OleDbType.Integer,4),
                    new OleDbParameter("@AlarmInfo", OleDbType.VarChar,255),
                    new OleDbParameter("@Suggestion", OleDbType.VarChar,100),
                    new OleDbParameter("@AlarmTime", OleDbType.VarChar,50),
                    new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.AbnormalCode;
            parameters[1].Value = model.AbnormalLeavel;
            parameters[2].Value = model.AlarmInfo;
            parameters[3].Value = model.Suggestion;
            parameters[4].Value = model.AlarmTime;
            parameters[5].Value = model.ID;

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
            strSql.Append("delete from tAlarmInfo ");
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
            strSql.Append("delete from tAlarmInfo ");
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
        public Maticsoft.Model.tAlarmInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,AbnormalCode,AbnormalLeavel,AlarmInfo,Suggestion,AlarmTime from tAlarmInfo ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            Maticsoft.Model.tAlarmInfo model = new Maticsoft.Model.tAlarmInfo();
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
        public Maticsoft.Model.tAlarmInfo DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tAlarmInfo model = new Maticsoft.Model.tAlarmInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["AbnormalCode"] != null)
                {
                    model.AbnormalCode = row["AbnormalCode"].ToString();
                }
                if (row["AbnormalLeavel"] != null && row["AbnormalLeavel"].ToString() != "")
                {
                    model.AbnormalLeavel = int.Parse(row["AbnormalLeavel"].ToString());
                }
                if (row["AlarmInfo"] != null)
                {
                    model.AlarmInfo = row["AlarmInfo"].ToString();
                }
                if (row["Suggestion"] != null)
                {
                    model.Suggestion = row["Suggestion"].ToString();
                }
                if (row["AlarmTime"] != null)
                {
                    model.AlarmTime = row["AlarmTime"].ToString();
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
            strSql.Append("select ID,AbnormalCode,AbnormalLeavel,AlarmInfo,Suggestion,AlarmTime ");
            strSql.Append(" FROM tAlarmInfo ");
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
            strSql.Append("select count(1) FROM tAlarmInfo ");
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
            strSql.Append(")AS Row, T.*  from tAlarmInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "tAlarmInfo";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
    }
}

