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
    public class BUS_Compiler
    {
        private const string TABLE_NAME = "Compiler";

        public long Id { get; set; }
        public bool IsEnable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CompilerPath { get; set; }
        public string Url { get; set; }

        public BUS_Compiler()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_Compiler(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }
        public DataTable selectEnable()
        {
            int iResult = 1;
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            _col.Add(DataTypes.Number, "IsEnable", FieldTypes.Criterion, 1, "=");
            return dao.DoQuery(_col, ref iResult);
        }

        public DataTable LoadByID(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.Number, "ID", FieldTypes.Criterion, id, "=");
            return dao.DoQuery(col, ref iResult);
        }
    }
}

