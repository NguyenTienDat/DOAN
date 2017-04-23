using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HELPER;

namespace BUS
{
    public class BUS_M_LOOKUP
    {
        private const string TABLE_NAME = "M_LOOKUP";

        public long Id { get; set; }
        public string VALUE { get; set; }
        public string TEXT { get; set; }
        public string CODE { get; set; }



        public BUS_M_LOOKUP()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_M_LOOKUP(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }



        public DataTable LoadAll()
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            return dao.DoQuery(col, ref iResult);
        }

        public void LoadToCombo(DevExpress.Web.ASPxComboBox objCombo, bool isAll, string code)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.NVarchar, "code", FieldTypes.Criterion, code, "=");
            DataTable dt = dao.DoQuery(col, ref iResult);
            if (isAll)
            {
                DataRow dr = dt.NewRow();
                dr["value"] = "0";
                dr["text"] = "";
                dt.Rows.InsertAt(dr, 0);
            }
            objCombo.DataSource = dt;
            objCombo.TextField = "text";
            objCombo.ValueField = "value";
            objCombo.DataBind();
            objCombo.SelectedIndex = 0;
        }
        public void LoadToCombo(DevExpress.Web.Bootstrap.BootstrapComboBox objCombo, bool isAll, string code)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.NVarchar, "code", FieldTypes.Criterion, code, "=");
            DataTable dt = dao.DoQuery(col, ref iResult);
            if (isAll)
            {
                DataRow dr = dt.NewRow();
                dr["value"] = "0";
                dr["text"] = "";
                dt.Rows.InsertAt(dr, 0);
            }
            objCombo.DataSource = dt;
            objCombo.TextField = "text";
            objCombo.ValueField = "value";
            objCombo.DataBind();
            objCombo.SelectedIndex = 0;
        }
        public void LoadNotiTypeToCombo(DevExpress.Web.Bootstrap.BootstrapComboBox objCombo, bool isAll)
        {
            LoadToCombo(objCombo, isAll, "noti_type");
        }

        public void LoadToCheckList(DevExpress.Web.ASPxCheckBoxList obj)
        {
            obj.DataSource = LoadAll();
            obj.TextField = "Name";
            obj.ValueField = "Id";
            obj.DataBind();
        }

    }
}
