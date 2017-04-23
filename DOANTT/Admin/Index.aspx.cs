using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using HELPER;

namespace DOANTT.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CGlobal.SetSessionTitleAdmin("THÔNG TIN CHUNG");
            }
        }
    }
}