using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tTipInfo
    /// </summary>
    public partial class tTipInfo
    {
        public tTipInfo()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "tTipInfo");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tTipInfo");
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
        public bool Add(Maticsoft.Model.tTipInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tTipInfo(");
            strSql.Append("Tip1,Tip2,Tip3,Tip4,Tip5,Tip6,Tip7,Tip8)");
            strSql.Append(" values (");
            strSql.Append("@Tip1,@Tip2,@Tip3,@Tip4,@Tip5,@Tip6,@Tip7,@Tip8)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@Tip1", OleDbType.Integer,4),
                    new OleDbParameter("@Tip2", OleDbType.Integer,4),
                    new OleDbParameter("@Tip3", OleDbType.Integer,4),
                    new OleDbParameter("@Tip4", OleDbType.Integer,4),
                    new OleDbParameter("@Tip5", OleDbType.Integer,4),
                    new OleDbParameter("@Tip6", OleDbType.Integer,4),
                    new OleDbParameter("@Tip7", OleDbType.Integer,4),
                    new OleDbParameter("@Tip8", OleDbType.Integer,4)};
            parameters[0].Value = model.Tip1;
            parameters[1].Value = model.Tip2;
            parameters[2].Value = model.Tip3;
            parameters[3].Value = model.Tip4;
            parameters[4].Value = model.Tip5;
            parameters[5].Value = model.Tip6;
            parameters[6].Value = model.Tip7;
            parameters[7].Value = model.Tip8;

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
        public bool Update(Maticsoft.Model.tTipInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tTipInfo set ");
            strSql.Append("Tip1=@Tip1,");
            strSql.Append("Tip2=@Tip2,");
            strSql.Append("Tip3=@Tip3,");
            strSql.Append("Tip4=@Tip4,");
            strSql.Append("Tip5=@Tip5,");
            strSql.Append("Tip6=@Tip6,");
            strSql.Append("Tip7=@Tip7,");
            strSql.Append("Tip8=@Tip8");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@Tip1", OleDbType.Integer,4),
                    new OleDbParameter("@Tip2", OleDbType.Integer,4),
                    new OleDbParameter("@Tip3", OleDbType.Integer,4),
                    new OleDbParameter("@Tip4", OleDbType.Integer,4),
                    new OleDbParameter("@Tip5", OleDbType.Integer,4),
                    new OleDbParameter("@Tip6", OleDbType.Integer,4),
                    new OleDbParameter("@Tip7", OleDbType.Integer,4),
                    new OleDbParameter("@Tip8", OleDbType.Integer,4),
                    new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.Tip1;
            parameters[1].Value = model.Tip2;
            parameters[2].Value = model.Tip3;
            parameters[3].Value = model.Tip4;
            parameters[4].Value = model.Tip5;
            parameters[5].Value = model.Tip6;
            parameters[6].Value = model.Tip7;
            parameters[7].Value = model.Tip8;
            parameters[8].Value = model.ID;

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
            strSql.Append("delete from tTipInfo ");
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
            strSql.Append("delete from tTipInfo ");
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
        public Maticsoft.Model.tTipInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Tip1,Tip2,Tip3,Tip4,Tip5,Tip6,Tip7,Tip8 from tTipInfo ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            Maticsoft.Model.tTipInfo model = new Maticsoft.Model.tTipInfo();
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
        public Maticsoft.Model.tTipInfo DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tTipInfo model = new Maticsoft.Model.tTipInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Tip1"] != null && row["Tip1"].ToString() != "")
                {
                    model.Tip1 = int.Parse(row["Tip1"].ToString());
                }
                if (row["Tip2"] != null && row["Tip2"].ToString() != "")
                {
                    model.Tip2 = int.Parse(row["Tip2"].ToString());
                }
                if (row["Tip3"] != null && row["Tip3"].ToString() != "")
                {
                    model.Tip3 = int.Parse(row["Tip3"].ToString());
                }
                if (row["Tip4"] != null && row["Tip4"].ToString() != "")
                {
                    model.Tip4 = int.Parse(row["Tip4"].ToString());
                }
                if (row["Tip5"] != null && row["Tip5"].ToString() != "")
                {
                    model.Tip5 = int.Parse(row["Tip5"].ToString());
                }
                if (row["Tip6"] != null && row["Tip6"].ToString() != "")
                {
                    model.Tip6 = int.Parse(row["Tip6"].ToString());
                }
                if (row["Tip7"] != null && row["Tip7"].ToString() != "")
                {
                    model.Tip7 = int.Parse(row["Tip7"].ToString());
                }
                if (row["Tip8"] != null && row["Tip8"].ToString() != "")
                {
                    model.Tip8 = int.Parse(row["Tip8"].ToString());
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
            strSql.Append("select ID,Tip1,Tip2,Tip3,Tip4,Tip5,Tip6,Tip7,Tip8 ");
            strSql.Append(" FROM tTipInfo ");
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
            strSql.Append("select count(1) FROM tTipInfo ");
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
            strSql.Append(")AS Row, T.*  from tTipInfo T ");
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

