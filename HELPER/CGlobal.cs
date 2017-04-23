using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Data;

namespace HELPER
{

    public static class CGlobal
    {
        public const string USER_ID = "userid";
        public static string getText(DevExpress.Web.ASPxTextBox txt)
        {
            try
            {
                return txt.Text.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string getText(DevExpress.Web.ASPxMemo txt)
        {
            try
            {
                return txt.Text.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string getDataByColumn(long id, string col_name, string table)
        {
            try
            {
                return new DAL.DataUtils().getDataByColumn(id, col_name, table);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static void LoadToCombo(DevExpress.Web.ASPxComboBox objCombo, bool isAll, DataTable dt, string TextField, string ValueField)
        {
            if (isAll)
            {
                DataRow dr = dt.NewRow();
                dr[ValueField] = "0";
                dr[TextField] = "";
                dt.Rows.InsertAt(dr, 0);
            }
            objCombo.DataSource = dt;
            objCombo.TextField = TextField;
            objCombo.ValueField = ValueField;
            objCombo.DataBind();
            objCombo.SelectedIndex = 0;
        }
        public enum FunctionMode
        {
            AddMode, EditMode, SearchMode, DeleteMode, NormalMode, SelectMode, CloseMode, InitMode

        }
        public static long GetUserID()
        {
            try
            {
                string entity = "";
                HttpContext httpContext = HttpContext.Current;
                if (httpContext.ApplicationInstance.Session.Count > 0)
                {
                    entity = httpContext.ApplicationInstance.Session["userid"].ToString();
                }
                else { entity = "0"; }

                return long.Parse(entity);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static long GetDepartmentID()
        {
            string entity = "";
            HttpContext httpContext = HttpContext.Current;
            if (httpContext.ApplicationInstance.Session.Count > 0)
            {
                entity = httpContext.ApplicationInstance.Session["DEP_ID"].ToString();
                return long.Parse(entity.ToString());
            }
            else
            {
                return 1;
            }
        }
        public static void ChangeMode(Panel pnVisible, Panel pnInvisibble, DevExpress.Web.ASPxLabel lblHeader, string title)
        {
            pnVisible.Visible = true;
            pnInvisibble.Visible = false;
            lblHeader.Text = title;
        }

        static string GetSession(string name)
        {
            string entity = string.Empty; ;
            try
            {
                HttpContext httpContext = HttpContext.Current;
                if (httpContext.ApplicationInstance.Session.Count > 0)
                {
                    entity = httpContext.ApplicationInstance.Session[name].ToString();
                }

                return entity;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        static bool SetSession(string name, string value)
        {
            try
            {
                HttpContext httpContext = HttpContext.Current;
                if (httpContext.ApplicationInstance.Session.Count > 0)
                {
                    httpContext.ApplicationInstance.Session[name] = value;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static string GetTitleUser()
        {
            return GetSession("lbTitleUser");
        }
        public static bool SetSessionTitleUser(string title)
        {
            return SetSession("lbTitleUser", title);
        }


        public static string GetTitleAdmin()
        {
            return GetSession("lbTitleAdmin");
        }
        public static bool SetSessionTitleAdmin(string title)
        {
            return SetSession("lbTitleAdmin", title);
        }
    }



}
