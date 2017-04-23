using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using BUS;
using HELPER;
namespace Master
{
    public partial class Main : System.Web.UI.MasterPage
    {
        BUS_Users user = new BUS_Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            long id = CGlobal.GetUserID();
            if (id <= 0)
            {
                Session[CGlobal.USER_ID] = 0;
                pnHello.Visible = false;
                pnLogin.Visible = true;
            }
            else
            {
                pnHello.Visible = true;
                pnLogin.Visible = false;
                lbFullName.Text = new DAL.DataUtils().getDataByColumn(id, "FullName", "[Users]");
              //  btnAdmin.Visible = user.IsAdmin(userID);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?search=" + txtInput.Text.Trim());
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session[CGlobal.USER_ID] = 0;
            Response.Redirect("~/Pages/Home.aspx");
        }

        protected void btnNoti_Click(object sender, ImageClickEventArgs e)
        {
            ppNoti.ShowOnPageLoad = true;
        }
    }
}