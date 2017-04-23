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
    public class BUS_Notification
    {
        private const string TABLE_NAME = "Notification";

        public long Id { get; set; }
        public long CreatedBy { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

        public int NotiType { get; set; }

        public BUS_Notification()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_Notification(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }
        private DataCollections GetObject()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "CreatedBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            _col.Add(DataTypes.NVarchar, "Content", FieldTypes.DefaultValue, Content, "");
            _col.Add(DataTypes.Number, "NotiType", FieldTypes.DefaultValue, NotiType, "");
            return _col;
        }
        public long Insert()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "CreatedBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            _col.Add(DataTypes.NVarchar, "Content", FieldTypes.DefaultValue, Content, "");
            _col.Add(DataTypes.Number, "NotiType", FieldTypes.DefaultValue, NotiType, "");
            return dao.DoInsertReturnID(_col);
        }
        public long Insert(long createdBy, string content, int notiType)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "CreatedBy", FieldTypes.DefaultValue,createdBy, "");
            _col.Add(DataTypes.NVarchar, "Content", FieldTypes.DefaultValue, content, "");
            _col.Add(DataTypes.Number, "NotiType", FieldTypes.DefaultValue, notiType, "");
            return dao.DoInsertReturnID(_col);
        }
        public bool Update()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, Id, "=");
            _col.Add(DataTypes.Number, "CreatedBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            _col.Add(DataTypes.NVarchar, "Content", FieldTypes.DefaultValue, Content, "");
            _col.Add(DataTypes.Number, "NotiType", FieldTypes.DefaultValue, NotiType, "");
            return dao.DoUpdate(_col);
        }

        public bool Delete(long p_id)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, p_id, "=");
            return dao.DoDelete(_col);
        }

        public DataTable LoadAll()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            return dao.DoQuery(col, ref iResult);
        }

        //public void LoadTypeToCombo(DevExpress.Web.Bootstrap.BootstrapComboBox objCombo, bool isAll)
        //{
        //    DataTable dt = LoadAll();
        //    if (isAll)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["ID"] = "0";
        //        dr["PROJECT_NAME"] = "";
        //        dt.Rows.InsertAt(dr, 0);
        //    }
        //    objCombo.DataSource = dt;
        //    objCombo.TextField = "PROJECT_NAME";
        //    objCombo.ValueField = "ID";
        //    objCombo.DataBind();
        //    objCombo.SelectedIndex = 0;
        //}

        public DataTable LoadBySearch(int type)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            if (type >= 1 && type <= 3)
            {
                col.Add(DataTypes.Number, "NotiType", FieldTypes.Criterion, type, "=");
            }
            col.Add(DataTypes.Number, "CreatedBy", FieldTypes.Criterion, CGlobal.GetUserID(), "=");

            col.ORDERBY = " ORDER BY CreatedOn DESC";
            return dao.DoQuery(col, ref iResult);
        }

       



        public DataTable LoadByID(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, id, "=");
            return dao.DoQuery(col, ref iResult);
        }





    }
}
