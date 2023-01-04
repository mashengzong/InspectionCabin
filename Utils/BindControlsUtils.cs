using Maticsoft.DBUtility;
using Sunny.UI;
using System;
using System.Data;

namespace SampleProcessingSystem.Utils
{
    public class BindControlsUtils
    {
        public void BindUIComboBox(UIComboBox cmb, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = "";
            dt.Rows.InsertAt(dr, 0);
            cmb.DisplayMember = dt.Columns[1].ColumnName;
            cmb.ValueMember = dt.Columns[0].ColumnName;
            cmb.DataSource = dt;
        }


        public void BindUIComboBox(UIComboBox cmb, string sql)
        {
            DataTable dt = DbHelperOleDb.Query(sql).Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = "";
            dt.Rows.InsertAt(dr, 0);
            cmb.DisplayMember = dt.Columns[1].ColumnName;
            cmb.ValueMember = dt.Columns[0].ColumnName;
            cmb.DataSource = dt;
        }
    }
}