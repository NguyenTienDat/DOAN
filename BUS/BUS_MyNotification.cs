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
    public class BUS_MyNotification
    {
        private const string TABLE_NAME = "MyNotification";

        public long Id { get; set; }
        public long NotificationID { get; set; }
        public long Status { get; set; }
        public DateTime Date { get; set; }

        public long UserID { get; set; }
        public long ContestID { get; set; }
        public long ProblemID { get; set; }

        public DataTable GetMyNotiByUser(int notiMax)
        {
            DataCollections col = new DataCollections("P_GetMyNotiByUser");
            col.Add(DataTypes.Number, "@userid", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            col.Add(DataTypes.Number, "@notiMax", FieldTypes.Criterion, notiMax, "=");
            return dao.exeSelectPro(col, "P_GetMyNotiByUser");
        }
        public string GetMyNotiNotSeenByUser()
        {
            DataCollections col = new DataCollections("P_GetMyNotiNotSeenByUser");
            col.Add(DataTypes.Number, "@userid", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            DataTable dt = dao.exeSelectPro(col, "P_GetMyNotiNotSeenByUser");
            try
            {
                return dt.Rows[0][0].ToString();
            }
            catch
            {
                return "0";
            }
        }

        public BUS_MyNotification()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_MyNotification(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }

        public long Insert()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "NotificationID", FieldTypes.DefaultValue, NotificationID, "");
            if (UserID > 0)
            {
                _col.Add(DataTypes.Number, "UserID", FieldTypes.DefaultValue, UserID, "");
            }
            else if (ContestID > 0)
            {
                _col.Add(DataTypes.Number, "ContestID", FieldTypes.DefaultValue, ContestID, "");
            }
            else if (ProblemID > 0)
            {
                _col.Add(DataTypes.Number, "ProblemID", FieldTypes.DefaultValue, ProblemID, "");
            }
            return dao.DoInsertReturnID(_col);
        }

        public long Insert(long noti, long userID)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "NotificationID", FieldTypes.DefaultValue, noti, "");
            _col.Add(DataTypes.Number, "UserID", FieldTypes.DefaultValue, userID, "");
            return dao.DoInsertReturnID(_col);
        }

        public bool UpdateStatus(long _id, int _status)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, _id, "=");
            _col.Add(DataTypes.Number, "Status", FieldTypes.DefaultValue, _status, "");
            _col.Add(DataTypes.DateTime, "Date", FieldTypes.DefaultValue, DateTime.Now, "");
            return dao.DoUpdate(_col);
        }

        public bool Delete(long p_id)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, p_id, "=");
            return dao.DoDelete(_col);
        }

        public DataTable LoadAll()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            return dao.DoQuery(col, ref iResult);
        }

        public DataTable LoadBySearch(int status)
        {
            DataCollections col = new DataCollections("P_GetAllMyNotiByUser");
            col.Add(DataTypes.Number, "@userid", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            col.Add(DataTypes.Number, "@notiStatus", FieldTypes.Criterion, (status + 1), "=");
            return dao.exeSelectPro(col, "P_GetAllMyNotiByUser");
        }

        public DataTable LoadBySearchComponent(int type, long notiID)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            //col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            //if (status >= 1 && status <= 3)
            //{
            //    col.Add(DataTypes.Number, "NotiType", FieldTypes.Criterion, status, "=");
            //}
            switch (type)
            {
                case 1:
                    col.Add(DataTypes.NVarchar, "contestname", FieldTypes.DefaultValue, "", "");
                    col.ORDERBY = " ORDER BY contestname";
                    break;
                case 2:
                    col.Add(DataTypes.NVarchar, "problemName", FieldTypes.DefaultValue, "", "");
                    col.ORDERBY = " ORDER BY problemName";
                    break;
                case 3:
                    col.Add(DataTypes.NVarchar, "SendTo", FieldTypes.DefaultValue, "", "");
                    col.ORDERBY = " ORDER BY SendTo";
                    break;
                default:
                    col.Add(DataTypes.NVarchar, "contestname", FieldTypes.DefaultValue, "", "");
                    col.Add(DataTypes.NVarchar, "problemName", FieldTypes.DefaultValue, "", "");
                    col.Add(DataTypes.NVarchar, "SendTo", FieldTypes.DefaultValue, "", "");
                    col.ORDERBY = " ORDER BY CreatedOn DESC";
                    break;
            }
            col.Add(DataTypes.Number, "NotificationID", FieldTypes.Criterion, notiID, "=");
            col.Add(DataTypes.Number, "CreatedBy", FieldTypes.Criterion, CGlobal.GetUserID(), "=");


            return dao.DoQuery(col, ref iResult);
        }

        //public DataTable LoadBySearch(int status)
        //{
        //    int iResult = 1;
        //    DataCollections col = new DataCollections("V_" + TABLE_NAME);
        //    col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
        //    if (status >= 1 && status <= 3)
        //    {
        //        col.Add(DataTypes.Number, "NotiType", FieldTypes.DefaultValue, status, "");
        //    }
        //    col.Add(DataTypes.Number, "CreatedBy", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");

        //    col.ORDERBY = " ORDER BY CreatedOn DESC";
        //    return dao.DoQuery(col, ref iResult);
        //}

        public DataTable LoadByID(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, id, "=");
            return dao.DoQuery(col, ref iResult);
        }

        //public DataTable LoadByUserID(int notiMax)
        //{
        //    DataCollections col = new DataCollections("P_GetMyNotiByUser");
        //    col.Add(DataTypes.Number, "@userid", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
        //    col.Add(DataTypes.Number, "@notiMax", FieldTypes.Criterion, notiMax, "=");
        //    return dao.exeSelectPro(col, "P_GetMyNotiByUser");
        //}
        //public string GetMyNotiNotSeenByUser()
        //{
        //    DataCollections col = new DataCollections("GetMyNotiNotSeenByUser");
        //    col.Add(DataTypes.Number, "@userid", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
        //    DataTable dt = dao.exeSelectPro(col, "GetMyNotiNotSeenByUser");
        //    try
        //    {
        //        return dt.Rows[0][0].ToString();
        //    }
        //    catch
        //    {
        //        return "0";
        //    }
        //}



    }
}
