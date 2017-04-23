using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//
using BUS;
using HELPER;
namespace Pages.Controler
{
    public partial class Login_User : System.Web.UI.Page
    {
        BUS_Users user = new BUS_Users();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uname = txtUserName.Text;
            string pas = txtPass.Text;

            long userID = user.GetID(uname, pas);
            if (userID >= 1)
            {
                Session[HELPER.CGlobal.USER_ID] = userID;
                if (user.CheckIsAdmin(userID))
                {
                    //HELPER.Client.Alert(this, "Đăng nhập thành công!");
                    Response.Redirect("~/Admin/Index.aspx");
                }
                else
                {
                    // HELPER.Client.Alert(this, "Bạn không có quyền Admin!");
                    Response.Redirect("~/Pages/Home.aspx");
                }

            }
            else
            {
                HELPER.Client.Alert(this, "Sai thông tin đăng nhập!");
            }

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Controler/SigUp_User.aspx");
        }




    }
}
