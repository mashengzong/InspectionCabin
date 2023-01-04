using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tReagentSetting
    /// </summary>
    public partial class tReagentSetting
    {
        public tReagentSetting()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "tReagentSetting");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tReagentSetting");
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
        public bool Add(Maticsoft.Model.tReagentSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tReagentSetting(");
            strSql.Append("Reagent1,Reagent2)");
            strSql.Append(" values (");
            strSql.Append("@Reagent1,@Reagent2)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@Reagent1", OleDbType.Integer,4),
                    new OleDbParameter("@Reagent2", OleDbType.Integer,4)};
            parameters[0].Value = model.Reagent1;
            parameters[1].Value = model.Reagent2;

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
        public bool Update(Maticsoft.Model.tReagentSetting model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tReagentSetting set ");
            strSql.Append("Reagent1=@Reagent1,");
            strSql.Append("Reagent2=@Reagent2");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@Reagent1", OleDbType.Integer,4),
                    new OleDbParameter("@Reagent2", OleDbType.Integer,4),
                    new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.Reagent1;
            parameters[1].Value = model.Reagent2;
            parameters[2].Value = model.ID;

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
            strSql.Append("delete from tReagentSetting ");
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
            strSql.Append("delete from tReagentSetting ");
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
        public Maticsoft.Model.tReagentSetting GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Reagent1,Reagent2 from tReagentSetting ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            Maticsoft.Model.tReagentSetting model = new Maticsoft.Model.tReagentSetting();
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
        public Maticsoft.Model.tReagentSetting DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tReagentSetting model = new Maticsoft.Model.tReagentSetting();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Reagent1"] != null && row["Reagent1"].ToString() != "")
                {
                    model.Reagent1 = int.Parse(row["Reagent1"].ToString());
                }
                if (row["Reagent2"] != null && row["Reagent2"].ToString() != "")
                {
                    model.Reagent2 = int.Parse(row["Reagent2"].ToString());
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
            strSql.Append("select ID,Reagent1,Reagent2 ");
            strSql.Append(" FROM tReagentSetting ");
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
            strSql.Append("select count(1) FROM tReagentSetting ");
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
            strSql.Append(")AS Row, T.*  from tReagentSetting T ");
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

