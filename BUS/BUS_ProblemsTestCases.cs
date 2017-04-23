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
    public class BUS_ProblemsTestCases
    {
        private const string TABLE_NAME = "ProblemsTestCases";
        public long Id { get; set; }
        public long ProblemId { get; set; }
        public string FileName { get; set; }
        public long Point { get; set; }

        public BUS_ProblemsTestCases()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_ProblemsTestCases(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }

        public long Insert()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "ProblemId", FieldTypes.DefaultValue, ProblemId, "");
            _col.Add(DataTypes.NVarchar, "FileName", FieldTypes.DefaultValue, FileName, "");
            _col.Add(DataTypes.Number, "Point", FieldTypes.DefaultValue, Point, "");
            return dao.DoInsertReturnID(_col);
        }
        public bool UpdateById()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, Id, "=");
            return dao.DoUpdate(_col);
        }
        public bool UpdateByProblemIdAndFileName()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "ProblemId", FieldTypes.Criterion, ProblemId, "=");
            _col.Add(DataTypes.NVarchar, "FileName", FieldTypes.Criterion, FileName, "=");
            _col.Add(DataTypes.Number, "Point", FieldTypes.DefaultValue, Point, "");
            return dao.DoUpdate(_col);
        }

        public bool Delete(long p_id)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, p_id, "=");
            return dao.DoDelete(_col);
        }
        public bool DeleteByProblemId()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "ProblemId", FieldTypes.Criterion, ProblemId, "=");
            return dao.DoDelete(_col);
        }

        public DataTable LoadAll()
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.Undefined, "*", FieldTypes.DefaultValue, "", "");
            return dao.DoQuery(col, ref iResult);
        }

        public DataTable LoadByProblemID(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections( TABLE_NAME);
            col.Add(DataTypes.Undefined, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "ProblemId", FieldTypes.Criterion, id, "=");
            return dao.DoQuery(col, ref iResult);
        }

    }
}
