using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace HELPER
{
    public class CDataGrid
    {
        public static void Format(System.Web.UI.WebControls.GridView   obj, String columns, String captions, String widths,bool editMode)
        {
            String[] fields, wid,cap;
            int i;
            fields = columns.Split(',');
            wid = widths.Split(',');
            cap = captions.Split(',');
            
            for(i=0;i<fields.GetLength(0);++i)
            {
                BoundField bf = new BoundField();
                bf.DataField = fields[i];
                bf.HeaderText = cap[i];
                if (wid[i] != "*")
                {
                    bf.HeaderStyle.Width = int.Parse(wid[i]);
                    bf.ItemStyle.Width = int.Parse(wid[i]);
                }
                else
                {
                    bf.HeaderStyle.CssClass ="AutoWidth";
                    bf.ItemStyle.CssClass = "AutoWidth";
                }
                obj.Columns.Insert (i,bf);
            }
            if (editMode)
            {
                CommandField cs = new CommandField();
                cs.ButtonType = ButtonType.Link;
                cs.ShowSelectButton = true;
                cs.HeaderText = "#";
                cs.SelectText = "Sửa";
                cs.HeaderStyle.Width = 20;
                cs.ItemStyle.Width = 20;
                obj.Columns.Add(cs);

                CommandField cd = new CommandField();
                cd.ButtonType = ButtonType.Link;
                cd.HeaderText = "#";
                cd.DeleteText = "Xóa";
                cd.ShowDeleteButton = true;
                cd.HeaderStyle.Width = 20;
                cd.ItemStyle.Width = 20;
                obj.Columns.Add(cd);
                 
            }
            obj.Columns[0].Visible = false;
            //obj.Columns[0].Visible = false;
            obj.EmptyDataText = "Không có dữ liệu";
            obj.CssClass = "mGrid";
            obj.PagerStyle.CssClass = "pgr";
            obj.AlternatingRowStyle.CssClass = "alt";
            obj.AutoGenerateColumns = false;
            obj.BorderWidth = 1;
            obj.BorderColor = System.Drawing.Color.Black;
            obj.AllowPaging = true;
            obj.PagerSettings.Visible = false;
            
        }
        public static void Format(System.Web.UI.WebControls.GridView obj) {
            obj.EmptyDataText = "Không có dữ liệu";
            obj.CssClass = "mGrid";
            obj.PagerStyle.CssClass = "pgr";
            obj.AlternatingRowStyle.CssClass = "alt";
            obj.AutoGenerateColumns = false;
            obj.BorderWidth = 1;
            obj.BorderColor = System.Drawing.Color.Black;
       
        }
        public static void Format(System.Web.UI.WebControls.DataGrid  obj)
        {

            obj.CssClass = "mGrid";
            obj.PagerStyle.CssClass = "pgr";
            obj.AlternatingItemStyle.CssClass = "alt";
            obj.AutoGenerateColumns = false;
            obj.BorderWidth = 1;
            obj.BorderColor = System.Drawing.Color.Black;
        }
        public static List<Int64> getSelectedID(System.Web.UI.WebControls.GridView obj)
        {
            List<Int64> arr = new List<long>();
            for (int i = 0; i < obj.Rows.Count ;++i )
            {
                System.Web.UI.WebControls.CheckBox cb =(System.Web.UI.WebControls.CheckBox) obj.Rows[i].FindControl("ckItem");
                if (cb.Checked)
                    arr.Add(long.Parse(obj.Rows[i].Cells[0].Text.ToString()));
            }
            return arr;
        }
        
    }
}
