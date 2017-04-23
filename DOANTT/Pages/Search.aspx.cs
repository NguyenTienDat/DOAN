using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        static string strSearch = "";
        static int style_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strSearch = Request.QueryString["search"].ToString();
            }
            catch (Exception)
            {
                strSearch = "";
            }
            try
            {
                style_ID = int.Parse(Request.QueryString["style"].ToString());
            }
            catch (Exception)
            {
                style_ID = 0;
            }
            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("TÌM KIẾM");
            }
        }
    }
}