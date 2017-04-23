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
    public class BUS_Problems
    {
        private const string TABLE_NAME = "Problems";
        public long Id { get; set; }
        public string Name { get; set; }
        public long MaximumPoints { get; set; }
        public long TimeLimit { get; set; }
        public long MemoryLimit { get; set; }
        public long SourceCodeSizeLimit { get; set; }
        public bool IsVisible { get; set; }
        public long OrderBy { get; set; }
        public string URL_Content { get; set; }

        public long CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public string Url { get; set; }

        public int ProblemType { get; set; }


        public BUS_Problems(long _Id,
          string _Name,
          long _MaximumPoints,
          long _TimeLimit,
          long _MemoryLimit,
          long _SourceCodeSizeLimit,
          bool _IsVisible,
          long _OrderBy,
          long _CreatedBy,
          DateTime _ModifiedOn,
          string _URL_Content,
            string _Url)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.MaximumPoints = _MaximumPoints;
            this.TimeLimit = _TimeLimit;
            this.MemoryLimit = _MemoryLimit;
            this.SourceCodeSizeLimit = _SourceCodeSizeLimit;
            this.IsVisible = _IsVisible;
            this.OrderBy = _OrderBy;
            this.CreatedBy = _CreatedBy;
            this.ModifiedOn = _ModifiedOn;
            this.URL_Content = _URL_Content;
            this.Url = _Url;
        }

        public BUS_Problems()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_Problems(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }
        private DataCollections GetObject()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Name", FieldTypes.DefaultValue, Name, "");
            _col.Add(DataTypes.Number, "MaximumPoints", FieldTypes.DefaultValue, MaximumPoints, "");
            _col.Add(DataTypes.Number, "TimeLimit", FieldTypes.DefaultValue, TimeLimit, "");
            _col.Add(DataTypes.Number, "MemoryLimit", FieldTypes.DefaultValue, MemoryLimit, "");
            _col.Add(DataTypes.Number, "SourceCodeSizeLimit", FieldTypes.DefaultValue, SourceCodeSizeLimit, "");
            _col.Add(DataTypes.NVarchar, "IsVisible", FieldTypes.DefaultValue, IsVisible, "");
            _col.Add(DataTypes.Number, "OrderBy", FieldTypes.DefaultValue, OrderBy, "");
            _col.Add(DataTypes.NVarchar, "Url", FieldTypes.DefaultValue, Url, "");
            _col.Add(DataTypes.NVarchar, "URL_Content", FieldTypes.DefaultValue, URL_Content, "");

            _col.Add(DataTypes.Number, "ProblemType", FieldTypes.DefaultValue, ProblemType, "");
            return _col;
        }
        public long Insert()
        {
            DataCollections _col = GetObject();
            _col.Add(DataTypes.Number, "CreatedBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            _col.Add(DataTypes.DateTime, "ModifiedOn", FieldTypes.DefaultValue, DateTime.Now.Date, "");
            return dao.DoInsertReturnID(_col);
        }
        public bool Update()
        {
            DataCollections _col = GetObject();
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, Id, "=");
            _col.Add(DataTypes.DateTime, "ModifiedOn", FieldTypes.DefaultValue, DateTime.Now.Date, "");
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

        public DataTable LoadByType(int type)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "ProblemType", FieldTypes.Criterion, type, "=");
            col.Add(DataTypes.Number, "IsVisible", FieldTypes.Criterion, 1, "=");
            col.ORDERBY = " ORDER BY ModifiedOn DESC";

            return dao.DoQuery(col, ref iResult);
        }


        public DataTable LoadBySearch(int caseToSearch)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");

            switch (caseToSearch)
            {
                case 0: // isvisible = 1
                    col.Add(DataTypes.Number, "IsVisible", FieldTypes.Criterion, 1, "=");
                    break;
                case 1: //isvisible = 0 
                    col.Add(DataTypes.Number, "IsVisible", FieldTypes.Criterion, 0, "=");
                    break;
                case 2: // all
                    break;
                default:
                    break;
            }
            return dao.DoQuery(col, ref iResult);
        }


        public DataTable LoadByID(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, id, "=");
            return dao.DoQuery(col, ref iResult);
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
