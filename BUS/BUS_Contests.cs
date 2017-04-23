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
    public class BUS_Contests
    {
        private const string TABLE_NAME = "Contests";

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ContestPassword { get; set; }
        public bool IsVisible { get; set; }
        public long OrderBy { get; set; }
        public string Url { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }


        public BUS_Contests(long _Id,
          string _Name,
          string _Description,
          DateTime _StartTime,
          DateTime _EndTime,
          string _ContestPassword,
          bool _IsVisible,
          long _OrderBy,
          long _CreatedBy,
          DateTime _ModifiedOn)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Description = _Description;
            this.StartTime = _StartTime;
            this.EndTime = _EndTime;
            this.ContestPassword = _ContestPassword;
            this.IsVisible = _IsVisible;
            this.OrderBy = _OrderBy;
            this.CreatedBy = _CreatedBy;
            this.ModifiedOn = _ModifiedOn;
        }
        public BUS_Contests()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_Contests(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }
        private DataCollections GetObject()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Name", FieldTypes.DefaultValue, Name, "");
            _col.Add(DataTypes.NVarchar, "Description", FieldTypes.DefaultValue, Description, "");

            if (StartTime > DateTime.MinValue)
            {
                _col.Add(DataTypes.DateTime, "StartTime", FieldTypes.DefaultValue, StartTime, "");
            }
            else
            {
                _col.Add(DataTypes.Null, "StartTime", FieldTypes.DefaultValue, DataTypes.Null, "");
            }
            if (EndTime > DateTime.MinValue)
            {
                _col.Add(DataTypes.DateTime, "EndTime", FieldTypes.DefaultValue, EndTime, "");
            }
            else
            {
                _col.Add(DataTypes.Null, "EndTime", FieldTypes.DefaultValue, DataTypes.Null, "");
            }

            if (!string.IsNullOrEmpty(ContestPassword) && !string.IsNullOrWhiteSpace(ContestPassword))
            {
                _col.Add(DataTypes.NVarchar, "ContestPassword", FieldTypes.DefaultValue, ContestPassword, "");
            }

            _col.Add(DataTypes.NVarchar, "IsVisible", FieldTypes.DefaultValue, IsVisible, "");
            _col.Add(DataTypes.Number, "OrderBy", FieldTypes.DefaultValue, OrderBy, "");
            _col.Add(DataTypes.NVarchar, "Url", FieldTypes.DefaultValue, Url, "");
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

        public string GetPassword(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "ContestPassword", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "ID", FieldTypes.Criterion, id, "=");
            DataTable dt = dao.DoQuery(col, ref iResult);
            try
            {
                return dt.Rows[0]["ContestPassword"].ToString();
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
        public bool CheckIsAvailable(long contestID)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.Number, "ID", FieldTypes.Criterion, contestID, "=");
            col.Add(DataTypes.DateTime, "StartTime", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.DateTime, "EndTime", FieldTypes.DefaultValue, "", "");
            DataTable dt = dao.DoQuery(col, ref iResult);
            try
            {

                DateTime startTIme = DateTime.Parse(dt.Rows[0]["StartTime"].ToString());
                DateTime endTime = DateTime.Parse(dt.Rows[0]["EndTime"].ToString());
                DateTime now = DateTime.Now;
                if (startTIme > now)
                {
                    return false;
                }
                if (endTime < now)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                //start time, end time null thì cho phép
                return true;
            }
        }




        public DataTable LoadBySearch(long caseToSearch)
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
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, id, "=");
            return dao.DoQuery(col, ref iResult);
        }

        public DataTable LoadByUserID()
        {
            DataCollections _col = new DataCollections("P_AllContest");
            _col.Add(DataTypes.NVarchar, "UserId", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            return dao.exeSelectPro(_col, "P_AllContest");
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
