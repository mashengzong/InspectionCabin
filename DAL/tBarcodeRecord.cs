﻿using Maticsoft.DBUtility;//Please add references
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:tBarcodeRecord
    /// </summary>
    public partial class tBarcodeRecord
    {
        public tBarcodeRecord()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperOleDb.GetMaxID("ID", "tBarcodeRecord");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tBarcodeRecord");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.tBarcodeRecord GetModel(int RecID, int PlateCount, int SamplePos)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RecID,PlateCount,SamplePos,Barcode,ErrorInfo from tBarcodeRecord ");
            strSql.Append(" where RecID=@RecID");
            strSql.Append(" and PlateCount=@PlateCount");
            strSql.Append(" and SamplePos=@SamplePos");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@RecID", OleDbType.Integer),
                    new OleDbParameter("@PlateCount", OleDbType.Integer),
                    new OleDbParameter("@SamplePos", OleDbType.Integer)
            };
            parameters[0].Value = RecID;
            parameters[1].Value = PlateCount;
            parameters[2].Value = SamplePos;

            Maticsoft.Model.tBarcodeRecord model = new Maticsoft.Model.tBarcodeRecord();
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
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.tBarcodeRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tBarcodeRecord(");
            strSql.Append("RecID,PlateCount,SamplePos,Barcode,ErrorInfo)");
            strSql.Append(" values (");
            strSql.Append("@RecID,@PlateCount,@SamplePos,@Barcode,@ErrorInfo)");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@RecID", OleDbType.Integer,4),
                    new OleDbParameter("@PlateCount", OleDbType.Integer,4),
                    new OleDbParameter("@SamplePos", OleDbType.Integer,4),
                    new OleDbParameter("@Barcode", OleDbType.VarChar,255),
                    new OleDbParameter("@ErrorInfo", OleDbType.VarChar,255)};
            parameters[0].Value = model.RecID;
            parameters[1].Value = model.PlateCount;
            parameters[2].Value = model.SamplePos;
            parameters[3].Value = model.Barcode;
            parameters[4].Value = model.ErrorInfo;

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
        public bool Update(Maticsoft.Model.tBarcodeRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tBarcodeRecord set ");
            strSql.Append("RecID=@RecID,");
            strSql.Append("PlateCount=@PlateCount,");
            strSql.Append("SamplePos=@SamplePos,");
            strSql.Append("Barcode=@Barcode,");
            strSql.Append("ErrorInfo=@ErrorInfo");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@RecID", OleDbType.Integer,4),
                    new OleDbParameter("@PlateCount", OleDbType.Integer,4),
                    new OleDbParameter("@SamplePos", OleDbType.Integer,4),
                    new OleDbParameter("@Barcode", OleDbType.VarChar,255),
                    new OleDbParameter("@ErrorInfo", OleDbType.VarChar,255),
                    new OleDbParameter("@ID", OleDbType.Integer,4)};
            parameters[0].Value = model.RecID;
            parameters[1].Value = model.PlateCount;
            parameters[2].Value = model.SamplePos;
            parameters[3].Value = model.Barcode;
            parameters[4].Value = model.ErrorInfo;
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
            strSql.Append("delete from tBarcodeRecord ");
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
            strSql.Append("delete from tBarcodeRecord ");
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
        public Maticsoft.Model.tBarcodeRecord GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,RecID,PlateCount,SamplePos,Barcode,ErrorInfo from tBarcodeRecord ");
            strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
                    new OleDbParameter("@ID", OleDbType.Integer,4)
            };
            parameters[0].Value = ID;

            Maticsoft.Model.tBarcodeRecord model = new Maticsoft.Model.tBarcodeRecord();
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
        public Maticsoft.Model.tBarcodeRecord DataRowToModel(DataRow row)
        {
            Maticsoft.Model.tBarcodeRecord model = new Maticsoft.Model.tBarcodeRecord();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["RecID"] != null && row["RecID"].ToString() != "")
                {
                    model.RecID = int.Parse(row["RecID"].ToString());
                }
                if (row["PlateCount"] != null && row["PlateCount"].ToString() != "")
                {
                    model.PlateCount = int.Parse(row["PlateCount"].ToString());
                }
                if (row["SamplePos"] != null && row["SamplePos"].ToString() != "")
                {
                    model.SamplePos = int.Parse(row["SamplePos"].ToString());
                }
                if (row["Barcode"] != null)
                {
                    model.Barcode = row["Barcode"].ToString();
                }
                if (row["ErrorInfo"] != null)
                {
                    model.ErrorInfo = row["ErrorInfo"].ToString();
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
            strSql.Append("select ID,RecID,PlateCount,SamplePos,Barcode,ErrorInfo ");
            strSql.Append(" FROM tBarcodeRecord ");
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
            strSql.Append("select count(1) FROM tBarcodeRecord ");
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
            strSql.Append(")AS Row, T.*  from tBarcodeRecord T ");
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
			parameters[0].Value = "tBarcodeRecord";
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

