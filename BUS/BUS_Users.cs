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
    public class BUS_Users
    {
        private const string TABLE_NAME = "Users";
        public long Id { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Class { get; set; }
        public string UserCode { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string ForgottenPasswordToken { get; set; }
        public bool IsEnable { get; set; }
        public long OrderBy { get; set; }
        public long AcceptBy { get; set; }

        public string Avatar { get; set; }
        public long Point { get; set; }

        public BUS_Users()
        {

        }
        DatabaseDAO dao = new DatabaseDAO();

        public BUS_Users(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }
        public BUS_Users(long _Id,
           int _UserType,
           string _UserName,
           string _Password,
           string _FullName,
           string _Class,
           string _UserCode,
           string _Email,
           DateTime _DateOfBirth,
           string _Phone,
           string _ForgottenPasswordToken,
           bool _IsEnable,
           long _OrderBy)
        {
            this.Id = _Id;
            this.UserType = _UserType;
            this.UserName = _UserName;
            this.Password = _Password;
            this.FullName = _Password;
            this.Class = _Class;
            this.UserCode = _UserCode;
            this.Email = _Email;
            this.DateOfBirth = _DateOfBirth;
            this.Phone = _Phone;
            this.ForgottenPasswordToken = _ForgottenPasswordToken;
            this.IsEnable = _IsEnable;
            this.OrderBy = _OrderBy;
        }

        public DataTable LoadByStatus(String p_Proj_Status)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_FMS_B_PROJECT");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            if (p_Proj_Status.Trim() != "")
                col.Add(DataTypes.NVarchar, "status", FieldTypes.Criterion, p_Proj_Status, "LIKE");
            col.ORDERBY = "ORDER BY PROJECT_NAME";
            return dao.DoQuery(col, ref iResult);
        }

        public DataTable LoadByID(long u_id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_Users");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "ID", FieldTypes.Criterion, u_id, "=");
            return dao.DoQuery(col, ref iResult);
        }

        public DataTable LoadAll()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_Users");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            return dao.DoQuery(col, ref iResult);
        }
        public void LoadToCheckList(DevExpress.Web.ASPxCheckBoxList obj)
        {
            obj.DataSource = LoadAll();
            obj.TextField = "FullName";
            obj.ValueField = "Id";
            obj.DataBind();
        }

        public bool CheckIsAdmin(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.Number, "UserType", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, id, "=");
            col.Add(DataTypes.Number, "IsEnable", FieldTypes.Criterion, 1, "=");
            DataTable dt = dao.DoQuery(col, ref iResult);
            try
            {
                return (int.Parse(dt.Rows[0][0].ToString()) > 1);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable LoadBySearch(int caseToSearch)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_Users");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            switch (caseToSearch)
            {
                case 0:
                    col.Add(DataTypes.Number, "IsEnable", FieldTypes.Criterion, 1, "=");
                    break;
                case 1:
                    col.Add(DataTypes.Number, "IsEnable", FieldTypes.Criterion, 0, "=");
                    break;
                case 2: // all
                    break;
                default:
                    break;
            }
            return dao.DoQuery(col, ref iResult);
        }

        public DataTable LoadRank()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_Users");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.NVarchar, "IsEnable", FieldTypes.Criterion, "1", "=");
            col.ORDERBY = " ORDER BY POINT DESC";
            return dao.DoQuery(col, ref iResult);
        }

        public long getPoint(long userID)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("Users");
            col.Add(DataTypes.Number, "Point", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "ID", FieldTypes.Criterion, userID, "=");
            DataTable dt = dao.DoQuery(col, ref iResult);
            try
            {
                return long.Parse(dt.Rows[0][0].ToString());
            }
            catch
            {
                throw;
            }
        }


        private DataCollections GetObject()
        {
            DataCollections _col = new DataCollections("Users");
            _col.Add(DataTypes.Number, "UserType", FieldTypes.DefaultValue, UserType, "");
            _col.Add(DataTypes.NVarchar, "UserName", FieldTypes.DefaultValue, UserName, "");
            _col.Add(DataTypes.NVarchar, "Password", FieldTypes.DefaultValue, Password, "");
            _col.Add(DataTypes.NVarchar, "FullName", FieldTypes.DefaultValue, FullName, "");
            _col.Add(DataTypes.NVarchar, "Class", FieldTypes.DefaultValue, Class, "");
            _col.Add(DataTypes.NVarchar, "UserCode", FieldTypes.DefaultValue, UserCode, "");
            _col.Add(DataTypes.NVarchar, "Email", FieldTypes.DefaultValue, Email, "");
            _col.Add(DataTypes.DateTime, "DateOfBirth", FieldTypes.DefaultValue, DateOfBirth, "");
            _col.Add(DataTypes.NVarchar, "Phone", FieldTypes.DefaultValue, Phone, "");
            _col.Add(DataTypes.NVarchar, "IsEnable", FieldTypes.DefaultValue, IsEnable, "");
            _col.Add(DataTypes.Number, "OrderBy", FieldTypes.DefaultValue, OrderBy, "");
            return _col;
        }
        public long Insert()
        {
            DataCollections _col = GetObject();

            return dao.DoInsertReturnID(_col);
        }
        public long InsertByAdmin()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "AcceptBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            _col.Add(DataTypes.NVarchar, "IsEnable", FieldTypes.DefaultValue, IsEnable, "");
            _col.Add(DataTypes.Number, "UserType", FieldTypes.DefaultValue, UserType, "");
            _col.Add(DataTypes.NVarchar, "UserName", FieldTypes.DefaultValue, UserName, "");
            _col.Add(DataTypes.NVarchar, "Password", FieldTypes.DefaultValue, Password, "");
            return dao.DoInsertReturnID(_col);
        }
        public bool Delete(long p_id)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, p_id, "=");
            return dao.DoDelete(_col);
        }
        public bool UpdateByAdmin()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "ID", FieldTypes.Criterion, Id, "=");
            _col.Add(DataTypes.NVarchar, "IsEnable", FieldTypes.DefaultValue, IsEnable, "");
            _col.Add(DataTypes.Number, "UserType", FieldTypes.DefaultValue, UserType, "");
            _col.Add(DataTypes.Number, "AcceptBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");

            return dao.DoUpdate(_col);
        }

        public bool UpdateByAdminEnable(long id, int enable)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "ID", FieldTypes.Criterion, id, "=");
            _col.Add(DataTypes.NVarchar, "IsEnable", FieldTypes.DefaultValue, enable, "");
            _col.Add(DataTypes.Number, "AcceptBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            return dao.DoUpdate(_col);
        }
        public bool UpdateByAdminType(long id, int type)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "ID", FieldTypes.Criterion, id, "=");
            _col.Add(DataTypes.Number, "UserType", FieldTypes.DefaultValue, type, "");
            _col.Add(DataTypes.Number, "AcceptBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            return dao.DoUpdate(_col);
        }






        // do work không thể gọi đc getUserID()
        public bool UpdatePoint(long point, long userID)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, userID, "=");
            _col.Add(DataTypes.Number, "Point", FieldTypes.DefaultValue, point, "");
            return dao.DoUpdate(_col);
        }

        public bool UpdatePointByID(long point)
        {
            DataCollections _col = GetObject();
            _col.Add(DataTypes.Number, "ID", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            _col.Add(DataTypes.Number, "Point", FieldTypes.DefaultValue, point, "");
            return dao.DoUpdate(_col);
        }


        public long GetID(string uname, string pas)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.Number, "ID", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.NVarchar, "UserName", FieldTypes.Criterion, uname, "=");
            col.Add(DataTypes.NVarchar, "Password", FieldTypes.Criterion, pas, "=");
            col.Add(DataTypes.Number, "IsEnable", FieldTypes.Criterion, 1, "=");
            DataTable dt = dao.DoQuery(col, ref iResult);
            try
            {
                return (int.Parse(dt.Rows[0][0].ToString()));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void LoadType(DevExpress.Web.Bootstrap.BootstrapComboBox objCombo)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("UserType");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            DataTable dt = dao.DoQuery(col, ref iResult);

            objCombo.DataSource = dt;
            objCombo.TextField = "Name";
            objCombo.ValueField = "Id";
            objCombo.DataBind();
            objCombo.SelectedIndex = 0;
        }

        public DataTable P_GET_COUNT_COUNTEST_BY_USERID()
        {
            DataCollections col = new DataCollections("P_GET_COUNT_COUNTEST_BY_USERID");
            col.Add(DataTypes.Number, "@userid", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            return dao.exeSelectPro(col, "P_GET_COUNT_COUNTEST_BY_USERID");
        }
        public DataTable GetCOUNT_SUBMIT()
        {
            DataCollections col = new DataCollections("P_GET_COUNT_SUBMIT_BY_USERID");
            col.Add(DataTypes.Number, "@userid", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            return dao.exeSelectPro(col, "P_GET_COUNT_SUBMIT_BY_USERID");
        }


    }
}
