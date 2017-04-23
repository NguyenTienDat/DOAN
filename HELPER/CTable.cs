using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
namespace HELPER
{
    public static class CTable
    {
        public static long GetTotal(DataTable p_dt, String p_column_name)
        {
            long total = 0;
            for (int i = 0; i < p_dt.Rows.Count; ++i)
            {
                total = total + long.Parse(p_dt.Rows[i][p_column_name].ToString());
            }
            return total;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        //  Converts DataTable To List
        //  DataTable dtTable = GetEmployeeDataTable();
        //  List<Employee> employeeList = dtTable.DataTableToList<Employee>();
	
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
        // ok
         //DataTable dt = objProblemsTestCase.LoadByProblemID(getHdf(hdfID));

         //   List<DataRow> list = dt.AsEnumerable().ToList();
         //   foreach (ListEditItem item in cblProblems.Items)
         //   {
         //       if (item.Selected)
         //       {
         //           objProbInContest.ProblemsId = long.Parse(item.Value.ToString());
         //           objProbInContest.Insert();
         //       }
         //   }
    }
}
