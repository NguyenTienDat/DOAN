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
    public class BUS_ProblemsInContest
    {
        private const string TABLE_NAME = "ProblemsInContest";
        public long Id { get; set; }
        public long ContestsId { get; set; }
        public long ProblemsId { get; set; }

        public BUS_ProblemsInContest()
        {

        }

        DatabaseDAO dao = new DatabaseDAO();

        public BUS_ProblemsInContest(DatabaseDAO _dao)
        {
            this.dao = _dao;
        }
        private DataCollections GetObject()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "ContestsId", FieldTypes.DefaultValue, ContestsId, "");
            _col.Add(DataTypes.Number, "ProblemsId", FieldTypes.DefaultValue, ProblemsId, "");
            return _col;
        }
        public long Insert()
        {
            DataCollections _col = GetObject();
            return dao.DoInsertReturnID(_col);
        }
        public bool Update()
        {
            DataCollections _col = GetObject();
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, Id, "=");
            return dao.DoUpdate(_col);
        }

        public bool Delete(long p_id)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "Id", FieldTypes.Criterion, p_id, "=");
            return dao.DoDelete(_col);
        }

        public bool DeleteByContest()
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.NVarchar, "ContestsId", FieldTypes.Criterion, ContestsId, "=");
            return dao.DoDelete(_col);
        }


        public bool DeleteByProblem(long p_id)
        {
            DataCollections _col = new DataCollections(TABLE_NAME);
            _col.Add(DataTypes.Number, "ProblemsId", FieldTypes.Criterion, p_id, "=");
            return dao.DoDelete(_col);
        }
        //public DataTable LoadAll()
        //{
        //    int iResult = 1;
        //    DataCollections col = new DataCollections("V_" + TABLE_NAME);
        //    col.Add(DataTypes.NVarchar, "*", FieldTypes.DefaultValue, "", "");
        //    return dao.DoQuery(col, ref iResult);
        //}
        public DataTable LoadByContestID(long id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections(TABLE_NAME);
            col.Add(DataTypes.Number, "ProblemsId", FieldTypes.DefaultValue, ProblemsId, "");
            if (id > 0)
            {
                col.Add(DataTypes.Number, "ContestsId", FieldTypes.Criterion, id, "=");
            }
            return dao.DoQuery(col, ref iResult);
        }

        public DataTable LoadViewByContestID(long _Id)
        {
            int iResult = 1;
            DataCollections col = new DataCollections("V_ProblemsInContest");
            col.Add(DataTypes.Undefined, "*", FieldTypes.DefaultValue, "", "");
            col.Add(DataTypes.NVarchar, "ContestsId", FieldTypes.Criterion, _Id, "=");
            return dao.DoQuery(col, ref iResult);
        }

        //public void LoadToCheckList(DevExpress.Web.ASPxCheckBoxList obj)
        //{
        //    int iResult = 1;
        //    DataCollections col = new DataCollections("V_ProblemsInContest_CBO");
        //    col.Add(DataTypes.Undefined, "*", FieldTypes.DefaultValue, "", "");
        //    //col.Add(DataTypes.Number, "ContestsId", FieldTypes.Criterion, ContestsId, "=");
        //    DataTable dt = dao.DoQuery(col, ref iResult);

        //    obj.DataSource = dt;
        //    obj.ValueField = "Id";
        //    obj.TextField = "prName";
        //    obj.DataBind();
        //}

    }
}
