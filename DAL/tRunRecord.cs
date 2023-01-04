using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tRunRecord
    /// </summary>
    public partial class tRunRecord
    {
        public tRunRecord()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "tRunRecord");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tRunRecord");
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
        public bool Add(Maticsoft.Model.tRunRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tRunRecord(");
            strSql.Append("ProID,RunTime,TotalCount)");
            strSql.Append(" values (");
            strSql.Append("@ProID,@RunTime,@TotalCount)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ProID", OleDbType.Integer,4),
                    new OleDbParameter("@RunTime", OleDbType.VarChar,50),
                    new OleDbParameter("@TotalCount", OleDbType.Integer,4)};
            parameters[0].Value = model.ProID;
            parameters[1].Value = model.RunTime;
            parameters[2].Value = model.TotalCount;

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
        public bool Update(Maticsoft.Model.tRunRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tRunRecord set ");
            strSql.Append("ProID=@ProID,");
            strSql.Append("RunTime=@RunTime,");
            strSql.Append("TotalCount=@TotalCount");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ProID", OleDbType.Integer,4),
                    new OleDbParameter("@RunTime", OleDbType.VarChar,50),
                    new OleDbParameter("@TotalCount", OleDbType.Integer,4),
                    new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.ProID;
            parameters[1].Value = model.RunTime;
            parameters[2].Value = model.TotalCount;
            parameters[3].Value = model.ID;

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
            strSql.Append("delete from tRunRecord ");
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
            strSql.Append("delete from tRunRecord ");
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
        public Maticsoft.Model.tRunRecord GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ProID,RunTime,TotalCount from tRunRecord ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            Maticsoft.Model.tRunRecord model = new Maticsoft.Model.tRunRecord();
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
        public Maticsoft.Model.tRunRecord DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tRunRecord model = new Maticsoft.Model.tRunRecord();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["ProID"] != null && row["ProID"].ToString() != "")
                {
                    model.ProID = int.Parse(row["ProID"].ToString());
                }
                if (row["RunTime"] != null)
                {
                    model.RunTime = row["RunTime"].ToString();
                }
                if (row["TotalCount"] != null && row["TotalCount"].ToString() != "")
                {
                    model.TotalCount = int.Parse(row["TotalCount"].ToString());
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
            strSql.Append("select ID,ProID,RunTime,TotalCount ");
            strSql.Append(" FROM tRunRecord ");
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
            strSql.Append("select count(1) FROM tRunRecord ");
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
            strSql.Append(")AS Row, T.*  from tRunRecord T ");
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

