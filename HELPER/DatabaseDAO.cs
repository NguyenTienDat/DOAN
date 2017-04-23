using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
namespace HELPER
{
    public class DatabaseDAO
    {

        SqlConnection Sqlcon;
        SqlTransaction objTransaction = null;
        //SqlDataAdapter adap;
        bool hasTransaction = false;
        public enum QueryTypes
        {
            Insert, Update, SelectQuery, Delete
        };
        public enum SQLErrorTypes
        {
            SQL_DeleteError,
            SQL_ConnectError,
            SQL_UniqueError,
            SQL_Integrity,
            SQL_SelectError,
            SQL_UpdateError,
            SQL_InsertError,
            SQL_UnknownError
        };
        public DatabaseDAO()
        {
            //
            // TODO: Add constructor logic here
            //


        }
        public String ConnString
        {
            get
            {
                String sConnectStr = ConfigurationManager.ConnectionStrings["OJSConnectionString"].ToString();
                return sConnectStr;
            }
        }
        public void RollBack()
        {
            objTransaction.Rollback();
            hasTransaction = false;
            Sqlcon.Close();
        }
        public bool BeginTransaction()
        {
            try
            {
                if (ConnectValid())
                {
                    objTransaction = Sqlcon.BeginTransaction();
                    hasTransaction = true;
                    return true;
                }
                else
                    return false;

            }
            catch (Exception obj)
            {
                Console.WriteLine(obj.Message);
                hasTransaction = false;
                return false;
            }

        }

        public bool EndTransaction()
        {
            try
            {
                objTransaction.Commit();
                hasTransaction = false;
                Sqlcon.Close();
                return true;
            }
            catch (Exception obj)
            {
                objTransaction.Rollback();
                Console.WriteLine(obj.Message);
                return false;
            }
        }
        public void Close()
        {
            try
            {
                Sqlcon.Close();
            }
            catch (Exception obj)
            {
                Console.WriteLine(obj.Message);
            }
        }
        public SqlConnection GetConn()
        {
            if (ConnectValid())
            {
                return Sqlcon;

            }
            else
            {
                return null;
            }
        }
        public bool ConnectValid()
        {
            try
            {


                if (Sqlcon == null)
                {
                    Sqlcon = new SqlConnection();
                }
                if (Sqlcon.ConnectionString == "")
                {
                    Sqlcon.ConnectionString = ConnString;
                }
                if (Sqlcon.State != ConnectionState.Open)
                {
                    Sqlcon.Open();
                }

                return true;
            }
            catch (Exception obj)
            {
                throw new Exception(obj.Message);
            }
        }
        public String ToSQLString(QueryTypes _QueryType, DataCollections _DataCol)
        {
            String sSQL = "", temp = "", temp1 = "";
            String strWhere = "";
            DateTime? tempDate;
            if (_QueryType == QueryTypes.Insert)
            {
                for (int i = 0; i < _DataCol.Count(); ++i)
                {
                    if (_DataCol[i].FieldType != FieldTypes.AutoIncrement)
                    {
                        temp += _DataCol[i].DataField;
                        switch (_DataCol[i].DataType)
                        {
                            case DataTypes.NVarchar:
                                {
                                    temp1 += "N'" + _DataCol[i].DataValue + "'";
                                    break;
                                }
                            case DataTypes.Number:
                                {
                                    if (_DataCol[i].DataValue == null)
                                    {
                                        temp1 += "null";
                                    }
                                    else
                                    {
                                        temp1 += "'" + _DataCol[i].DataValue + "'";
                                    }
                                    break;
                                }
                            case DataTypes.DateTime:
                                {
                                    if (_DataCol[i].DataValue == null || Convert.ToDateTime(_DataCol[i].DataValue) == DateTime.MinValue)
                                    {
                                        temp1 += "null";
                                    }
                                    else
                                    {
                                        temp1 += "'" + _DataCol[i].DataValue + "'";
                                    }
                                    break;
                                }
                            default:
                                {
                                    temp1 += _DataCol[i].DataValue;
                                    break;
                                }
                        }
                        if (i < _DataCol.Count() - 1)
                        {
                            temp += ",";
                            temp1 += ",";
                        }

                    }
                    else
                    {
                        temp += _DataCol[i].DataField;
                        temp1 += _DataCol.DataTable + "_SEQ.nextval";
                        if (i < _DataCol.Count() - 1)
                        {
                            temp += ",";
                            temp1 += ",";
                        }
                    }
                }//end of for
                sSQL = "INSERT INTO " + _DataCol.DataTable + "(" + temp + ")" + " VALUES(" + temp1 + ")";
            }//end of Insert
            else if (_QueryType == QueryTypes.Update)
            {
                for (int i = 0; i < _DataCol.Count(); ++i)
                {
                    if (_DataCol[i].FieldType == FieldTypes.Criterion)
                    {
                        if (strWhere != "") strWhere += " AND ";
                        if (strWhere == "") strWhere += " WHERE ";
                        switch (_DataCol[i].DataType)
                        {
                            case DataTypes.NVarchar:
                                {
                                    strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " N'" + _DataCol[i].DataValue + "'";
                                    break;
                                }

                            case DataTypes.DateTime:
                                {
                                    if (_DataCol[i].DataValue == null || Convert.ToDateTime(_DataCol[i].DataValue) == DateTime.MinValue)
                                    {

                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " null";
                                    }
                                    else
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " '" + _DataCol[i].DataValue + "'";
                                    }
                                    break;


                                }
                            case DataTypes.Number:
                                {
                                    if (_DataCol[i].DataValue == null)
                                    {

                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " null";
                                    }
                                    else
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " '" + _DataCol[i].DataValue + "'";
                                    }
                                    break;


                                }
                            default:
                                {
                                    strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " " + _DataCol[i].DataValue;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        if (temp1 != "") temp1 += ",";
                        switch (_DataCol[i].DataType)
                        {
                            case DataTypes.NVarchar:
                                {
                                    temp1 += _DataCol[i].DataField + " = N'" + _DataCol[i].DataValue + "'";
                                    break;
                                }
                            case DataTypes.DateTime:
                                {
                                    if (_DataCol[i].DataValue == null || Convert.ToDateTime(_DataCol[i].DataValue) == DateTime.MinValue)
                                    {

                                        temp1 += _DataCol[i].DataField + " = null";
                                    }
                                    else
                                    {
                                        temp1 += _DataCol[i].DataField + " = '" + _DataCol[i].DataValue + "'";
                                    }

                                    break;
                                }
                            case DataTypes.Number:
                                {
                                    if (_DataCol[i].DataValue == null)
                                    {

                                        temp1 += _DataCol[i].DataField + " = null";
                                    }
                                    else
                                    {
                                        temp1 += _DataCol[i].DataField + " = '" + _DataCol[i].DataValue + "'";
                                    }

                                    break;
                                }
                            case DataTypes.Null:
                                {
                                    temp1 += _DataCol[i].DataField + " = null";
                                    break;
                                }
                            default:
                                {
                                    temp1 += _DataCol[i].DataField + " = " + _DataCol[i].DataValue;
                                    break;
                                }
                        }
                    }//end of if

                }
                sSQL = "UPDATE " + _DataCol.DataTable + " SET " + temp1 + strWhere;
            }//end of update
            else if (_QueryType == QueryTypes.SelectQuery)
            {
                for (int i = 0; i < _DataCol.Count(); ++i)
                {
                    if (_DataCol[i].FieldType == FieldTypes.Criterion)
                    {
                        if (strWhere != "") strWhere += " AND ";
                        if (strWhere == "") strWhere += " WHERE ";
                        switch (_DataCol[i].DataType)
                        {
                            case DataTypes.NVarchar:
                                {
                                    if (_DataCol[i].Expression.ToUpper() == "LIKE")
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " " + "N'%" + _DataCol[i].DataValue + "%'";
                                    }
                                    else if (_DataCol[i].Expression.ToUpper() == "CHARINDEX")
                                    {
                                        strWhere += "CHARINDEX(" + _DataCol[i].DataField + "," + _DataCol[i].DataValue + ") >=0";
                                    }
                                    else
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " '" + _DataCol[i].DataValue + "'";
                                    }
                                    break;
                                }
                            case DataTypes.DateTime:
                                {
                                    tempDate = Convert.ToDateTime(_DataCol[i].DataValue);
                                    if (tempDate.HasValue)
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " '" + _DataCol[i].DataValue + "'";
                                    }
                                    else
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " null";
                                    }
                                    break;
                                }
                            default:
                                {
                                    if (_DataCol[i].Expression.ToUpper() == "LIKE" || _DataCol[i].Expression.ToUpper() == "NOT LIKE")
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " " + "N'%" + _DataCol[i].DataValue + "%'";
                                    }
                                    else
                                    {
                                        strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " " + _DataCol[i].DataValue;
                                    }
                                    break;
                                }
                        }
                    }
                    else
                    {
                        if (temp1 != "") temp1 += ",";
                        temp1 += _DataCol[i].DataField;
                    }
                }//end of for
                sSQL = "SELECT " + temp1 + " FROM " + _DataCol.DataTable + strWhere;
                if (_DataCol.FILTER != "")
                {
                    if (sSQL.IndexOf("WHERE") < 0)
                    {
                        sSQL += " WHERE ";
                    }
                    else
                    {
                        sSQL += " AND ";
                    }
                    sSQL += _DataCol.FILTER;
                }
                sSQL += " " + _DataCol.ORDERBY;
            }//end of SelectQuery
            else if (_QueryType == QueryTypes.Delete)
            {
                for (int i = 0; i < _DataCol.Count(); ++i)
                {
                    if (_DataCol[i].FieldType == FieldTypes.Criterion)
                    {
                        if (strWhere != "") strWhere += " AND ";
                        if (strWhere == "") strWhere += " WHERE ";
                        switch (_DataCol[i].DataType)
                        {
                            case DataTypes.NVarchar:
                                {
                                    strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " " + "'" + _DataCol[i].DataValue + "'";
                                    break;
                                }
                            default:
                                {
                                    strWhere += _DataCol[i].DataField + " " + _DataCol[i].Expression + " " + _DataCol[i].DataValue;
                                    break;
                                }

                        }
                    }
                }//end of for
                sSQL = "DELETE FROM " + _DataCol.DataTable + strWhere;
            }
            return sSQL;
        }//end of method
        public bool DoDelete(DataCollections _DataCol)
        {
            String sSQL;
            sSQL = ToSQLString(QueryTypes.Delete, _DataCol);
            try
            {
                if (ConnectValid() == true)
                {
                    SqlCommand cmd = new SqlCommand();
                    if (hasTransaction == true) cmd.Transaction = objTransaction;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sSQL;
                    cmd.Connection = Sqlcon;
                    cmd.ExecuteNonQuery();
                    if (hasTransaction == false)
                    {
                        Sqlcon.Close();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception obj)
            {
                throw new Exception(obj.Message);
            }

        }
        public bool DoUpdate(DataCollections _DataCol)
        {
            String sSQL;
            sSQL = ToSQLString(DatabaseDAO.QueryTypes.Update, _DataCol);
            if (ConnectValid() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlParameter _para = new SqlParameter();
                    if (hasTransaction == true) cmd.Transaction = objTransaction;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sSQL;
                    cmd.Connection = Sqlcon;
                    cmd.ExecuteNonQuery();
                    if (hasTransaction == false)
                    {
                        Sqlcon.Close();
                    }
                    return true;

                }
                catch (Exception obj)
                {
                    throw new Exception(obj.Message);

                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// return identity value
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public long DoInsertReturnID(DataCollections _DataCol)
        {
            String sSQL;
            object _ReturnObject = null;
            sSQL = ToSQLString(DatabaseDAO.QueryTypes.Insert, _DataCol);
            sSQL += ";SELECT @@IDENTITY AS 'Identity'";
            if (ConnectValid() == true)
            {
                try
                {
                    System.Data.SqlClient.SqlCommand _SqlCommand = new System.Data.SqlClient.SqlCommand(sSQL, Sqlcon);
                    if (hasTransaction == true) _SqlCommand.Transaction = objTransaction;
                    _ReturnObject = _SqlCommand.ExecuteScalar();
                    _SqlCommand.Dispose();
                    _SqlCommand = null;
                    if (hasTransaction == false)
                    {
                        Sqlcon.Close();
                    }
                    return long.Parse(_ReturnObject.ToString());

                }
                catch (Exception obj)
                {
                    throw new Exception(obj.Message);

                }
            }
            else
            {
                return 0;
            }
        }
        public bool DoInsert(DataCollections _DataCol)
        {
            String sSQL;
            sSQL = ToSQLString(DatabaseDAO.QueryTypes.Insert, _DataCol);
            if (ConnectValid() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlParameter _para = new SqlParameter();
                    if (hasTransaction == true) cmd.Transaction = objTransaction;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sSQL;
                    cmd.Connection = Sqlcon;
                    cmd.ExecuteNonQuery();
                    Sqlcon.Close();
                    return true;

                }
                catch (Exception obj)
                {
                    throw new Exception(obj.Message);

                }
            }
            else
            {
                return false;
            }

        }
        public DataTable DoQuery(String sql)
        {
            if (ConnectValid() == true)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Connection = Sqlcon;
                    if (hasTransaction == true) cmd.Transaction = objTransaction;
                    SqlDataAdapter dA = new SqlDataAdapter(cmd);
                    DataSet dS = new DataSet();
                    if (hasTransaction == true) { }
                    dA.Fill(dS);
                    if (hasTransaction == false)
                    {
                        Sqlcon.Close();
                    }
                    return dS.Tables[0];
                }
                catch (Exception obj)
                {
                    Console.WriteLine(obj.Message);
                    return new DataTable();

                }

            }//end of if
            return new DataTable();
        }
        public DataTable DoQuery(DataCollections _DataCol, ref int iResult)
        {
            String sSQL;
            sSQL = ToSQLString(QueryTypes.SelectQuery, _DataCol);
            if (ConnectValid() == true)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sSQL;
                    cmd.Connection = Sqlcon;
                    if (hasTransaction == true) cmd.Transaction = objTransaction;
                    SqlDataAdapter dA = new SqlDataAdapter(cmd);
                    DataSet dS = new DataSet();
                    dA.Fill(dS);
                    iResult = 1;
                    if (hasTransaction == false)
                    {
                        Sqlcon.Close();
                    }
                    return dS.Tables[0];
                }
                catch (Exception obj)
                {
                    throw new Exception(obj.Message);

                }

            }//end of if
            return new DataTable();
        }
        public DataTable exeSelectPro(DataCollections _DataCol, String _Pro_Name)
        {
            if (ConnectValid() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Sqlcon;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = _Pro_Name;
                    SqlParameter myParam;
                    for (int i = 0; i < _DataCol.Count(); ++i)
                    {
                        myParam = new SqlParameter();
                        myParam.ParameterName = _DataCol[i].DataField;
                        myParam.Value = _DataCol[i].DataValue;
                        cmd.Parameters.Add(myParam);
                    }
                    SqlDataAdapter dA = new SqlDataAdapter(cmd);
                    DataSet dS = new DataSet();
                    dA.Fill(dS);
                    return dS.Tables[0];
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return new DataTable();
            }

        }

        public int exeUpdatePro(DataCollections _DataCol, String _Pro_Name)
        {
            if (ConnectValid() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = _Pro_Name;
                    SqlParameter myParam;
                    for (int i = 0; i < _DataCol.Count(); ++i)
                    {
                        myParam = new SqlParameter();
                        myParam.ParameterName = _DataCol[i].DataField;
                        myParam.Value = _DataCol[i].DataValue;
                        cmd.Parameters.Add(myParam);
                    }
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            else
            {
                return -1;
            }

        }
        public int exeInsertPro(DataCollections _DataCol, String _Pro_Name)
        {
            if (ConnectValid() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = _Pro_Name;
                    SqlParameter myParam;
                    myParam = new SqlParameter();
                    myParam.ParameterName = _DataCol[0].DataField;
                    myParam.Value = _DataCol[0].DataValue;
                    myParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(myParam);
                    for (int i = 1; i < _DataCol.Count(); ++i)
                    {
                        myParam = new SqlParameter();
                        myParam.ParameterName = _DataCol[i].DataField;
                        myParam.Value = _DataCol[i].DataValue;
                        cmd.Parameters.Add(myParam);

                    }
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.Parameters[0].Value.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            else
            {
                return -1;
            }

        }
        public int exeInsertProWithoutID(DataCollections _DataCol, String _Pro_Name)
        {
            if (ConnectValid() == true)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Sqlcon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = _Pro_Name;
                    SqlParameter myParam;

                    for (int i = 0; i < _DataCol.Count(); ++i)
                    {
                        myParam = new SqlParameter();
                        myParam.ParameterName = _DataCol[i].DataField;
                        myParam.Value = _DataCol[i].DataValue;
                        cmd.Parameters.Add(myParam);

                    }
                    cmd.ExecuteNonQuery();
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        public DataTable ReadExcel(string fileName)
        {

            string drPathFull = fileName;
            string strConn;
            DataSet dsExcel = new DataSet();
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            "Data Source=" + drPathFull + ";" +
            "Extended Properties=Excel 8.0;";

            OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);
            myCommand.Fill(dsExcel);
            return dsExcel.Tables[0];

        }

    }
}
