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
    public class BUS_MyContest
    {
        private const string TABLE_NAME = "MyContest";

        public long Id { get; set; }
        public long UserId { get; set; }
        public long ContestId { get; set; }

        public DateTime DateRequest { get; set; }
        public DateTime DateAccept { get; set; }

        public long AcceptBy { get; set; }
        public bool IsAccepted { get; set; }



        public BUS_MyContest()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_MyContest(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }
        private DataCollections GetObject()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "ContestId", FieldTypes.DefaultValue, ContestId, "");
            return _col;
        }
        public long Insert()
        {
            DataCollections _col = GetObject();
            _col.Add(DataTypes.Number, "UserId", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            _col.Add(DataTypes.DateTime, "DateRequest", FieldTypes.DefaultValue, DateTime.Now, "");
            return dao.DoInsertReturnID(_col);
        }
        public bool UpdateAcepted(long id, long acceptBy)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, id, "=");
            _col.Add(DataTypes.DateTime, "DateAccept", FieldTypes.DefaultValue, DateTime.Now, "");
            _col.Add(DataTypes.Number, "AcceptBy", FieldTypes.DefaultValue, acceptBy, "");
            _col.Add(DataTypes.Number, "IsAccepted", FieldTypes.DefaultValue, 1, "");
            return dao.DoUpdate(_col);
        }
        public bool UpdateNotAcepted()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, Id, "=");
            _col.Add(DataTypes.Number, "IsAccepted", FieldTypes.DefaultValue, 0, "");
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



        //Lấy số lượng đơn xin vào lớp của các khóa học do Giáo viên đó tạo
        public int GetCountNotAcceptedByCreated()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_Accepted");
            col.Add(DataTypes.NVarchar, "count(id)", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "createdby", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            DataTable dt = dao.DoQuery(col, ref iResult);

            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            return int.Parse(dt.Rows[0][0].ToString());

        }


        public DataTable LoadNotAcceptedByCreated()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_Accepted");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "createdby", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            return dao.DoQuery(col, ref iResult);
        }


        public bool CheckIsAccepted(long contestID)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("MyContest");
            col.Add(DataTypes.Number, "IsAccepted", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "ContestId", FieldTypes.Criterion, contestID, "=");
            col.Add(DataTypes.Number, "UserId", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            DataTable dt = dao.DoQuery(col, ref iResult);
            try
            {
                return Boolean.Parse(dt.Rows[0][0].ToString());
            }
            catch
            {
                return false;
            }
        }

      
        public DataTable LoadByUserID(int filter)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.NVarchar, "UserId", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            switch (filter)
            {
                case 1: // dc phe duyet
                    col.Add(DataTypes.Number, "IsAccepted", FieldTypes.Criterion, 1, "=");
                    // col.FILTER = " DateAccept IS NOT NULL";
                    col.ORDERBY = " ORDER BY DateAccept desc";
                    break;

                case 2: //chua phe duyet
                    col.Add(DataTypes.Number, "IsAccepted", FieldTypes.Criterion, 0, "=");
                    // col.FILTER = " DateAccept IS NULL";
                    col.ORDERBY = " ORDER BY DateRequest desc";
                    break;
                default: // dang hoc
                    col.Add(DataTypes.DateTime, "EndTime", FieldTypes.Criterion, DateTime.Now, ">");
                    col.Add(DataTypes.DateTime, "StartTime", FieldTypes.Criterion, DateTime.Now, "<");
                    // col.FILTER = " DateAccept IS NOT NULL";
                    col.Add(DataTypes.Number, "IsAccepted", FieldTypes.Criterion, 1, "=");
                    col.ORDERBY = " ORDER BY DateAccept desc";
                    break;
            }

            return dao.DoQuery(col, ref iResult);
        }
    }
}
