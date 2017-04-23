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
    public class BUS_Submission
    {
        private const string TABLE_NAME = "Submission";

        public long Id { get; set; }
        public long UserID { get; set; }
        public long ProblemId { get; set; }

        public long CompilerID { get; set; }
        public long ProcessType { get; set; }
        public long Points { get; set; }
        public DateTime TimeSubmiss { get; set; }
        public long ContestId { get; set; }


        public BUS_Submission()
        {

        }
        public BUS_Submission(
         long _ProblemId,
         long _CompilerID,
         long _ContestId)
        {
            this.ProblemId = _ProblemId;
            this.CompilerID = _CompilerID;
            this.ContestId = _ContestId;
        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_Submission(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }

        public long Insert()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "UserID", FieldTypes.DefaultValue, CGlobal.GetUserID(), "");
            _col.Add(DataTypes.DateTime, "TimeSubmiss", FieldTypes.DefaultValue, DateTime.Now, "");

            _col.Add(DataTypes.Number, "ProblemId", FieldTypes.DefaultValue, ProblemId, "");
            _col.Add(DataTypes.Number, "CompilerID", FieldTypes.DefaultValue, CompilerID, "");
            _col.Add(DataTypes.Number, "ProcessType", FieldTypes.DefaultValue, 1, "");
            _col.Add(DataTypes.Number, "ContestId", FieldTypes.DefaultValue, ContestId, "");
            _col.Add(DataTypes.Number, "Points", FieldTypes.DefaultValue, 0, "");

            return dao.DoInsertReturnID(_col);
        }
        public bool Update(long _id, int _processType, long _point)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, _id, "=");
            _col.Add(DataTypes.Number, "ProcessType", FieldTypes.DefaultValue, _processType, "");
            _col.Add(DataTypes.Number, "Points", FieldTypes.DefaultValue, _point, "");
            return dao.DoUpdate(_col);
        }
        public bool Update(long _id, int _processType)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "Id", FieldTypes.Criterion, _id, "=");
            _col.Add(DataTypes.Number, "ProcessType", FieldTypes.DefaultValue, _processType, "");
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

        public DataTable LoadByStatus()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_Submission_Status");
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");

            col.ORDERBY = " ORDER BY TimeSubmiss DESC";
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

        public long getPoint(long contestID, long problemID, long userID)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.Number, "MAX (Points)", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "UserID", FieldTypes.Criterion, userID, "=");
            col.Add(DataTypes.Number, "ProblemId", FieldTypes.Criterion, problemID, "=");
            col.Add(DataTypes.Number, "ContestId", FieldTypes.Criterion, contestID, "=");

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


        public DataTable LoadByUserID()
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_" + TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.NVarchar, "UserID", FieldTypes.Criterion, CGlobal.GetUserID(), "=");
            return dao.DoQuery(col, ref iResult);
        }
    }
}
