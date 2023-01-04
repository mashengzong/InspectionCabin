using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tProgram
    /// </summary>
    public partial class tProgram
    {
        public tProgram()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("id", "tProgram");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tProgram");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@id", OleDbType.Integer,4)
            };
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tProgram");
            strSql.Append(" where programName=@programName");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@programName", OleDbType.VarChar)
            };
            parameters[0].Value = name;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.tProgram model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tProgram(");
            strSql.Append("programName,addTime,isDefaut)");
            strSql.Append(" values (");
            strSql.Append("@programName,@addTime,@isDefaut)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@programName", OleDbType.VarChar,255),
                    new OleDbParameter("@addTime", OleDbType.VarChar,50),
                    new OleDbParameter("@isDefaut", OleDbType.Boolean,1)};
            parameters[0].Value = model.programName;
            parameters[1].Value = model.addTime;
            parameters[2].Value = model.isDefaut;

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
        public bool Update(Maticsoft.Model.tProgram model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tProgram set ");
            strSql.Append("programName=@programName,");
            strSql.Append("addTime=@addTime,");
            strSql.Append("isDefaut=@isDefaut");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@programName", OleDbType.VarChar,255),
                    new OleDbParameter("@addTime", OleDbType.VarChar,50),
                    new OleDbParameter("@isDefaut", OleDbType.Boolean,1),
                    new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.programName;
            parameters[1].Value = model.addTime;
            parameters[2].Value = model.isDefaut;
            parameters[3].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tProgram ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@id", OleDbType.Integer,4)
            };
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tProgram ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Maticsoft.Model.tProgram GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,programName,addTime,isDefaut from tProgram ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@id", OleDbType.Integer,4)
            };
            parameters[0].Value = id;

            Maticsoft.Model.tProgram model = new Maticsoft.Model.tProgram();
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
        public Maticsoft.Model.tProgram GetModel(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,programName,addTime,isDefaut from tProgram ");
            strSql.Append(" where programName=@programName");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@programName", OleDbType.VarChar)
            };
            parameters[0].Value = name;

            Maticsoft.Model.tProgram model = new Maticsoft.Model.tProgram();
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
        public Maticsoft.Model.tProgram DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tProgram model = new Maticsoft.Model.tProgram();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["programName"] != null)
                {
                    model.programName = row["programName"].ToString();
                }
                if (row["addTime"] != null)
                {
                    model.addTime = row["addTime"].ToString();
                }
                if (row["isDefaut"] != null && row["isDefaut"].ToString() != "")
                {
                    if ((row["isDefaut"].ToString() == "1") || (row["isDefaut"].ToString().ToLower() == "true"))
                    {
                        model.isDefaut = true;
                    }
                    else
                    {
                        model.isDefaut = false;
                    }
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
            strSql.Append("select id,programName,addTime,isDefaut ");
            strSql.Append(" FROM tProgram ");
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
            strSql.Append("select count(1) FROM tProgram ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from tProgram T ");
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

