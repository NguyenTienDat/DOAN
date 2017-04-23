using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BUS;
using HELPER;
using System.Data;

namespace DOANTT.Admin
{
    public partial class MasterAdmin : System.Web.UI.MasterPage
    {
        BUS_Users objUser = new BUS_Users();
        BUS_MyContest objMyContest= new BUS_MyContest();
        protected void Page_Load(object sender, EventArgs e)
        {
            //lbTruyCap.Text = Application.Contents["SoNguoiTruyCap"].ToString();
            //lbTongTruyCap.Text = Application.Contents["TongTruyCap"].ToString();
            if (!IsPostBack)
            {
                lbTitle.Text = CGlobal.GetTitleAdmin();
                int num  =objMyContest.GetCountNotAcceptedByCreated();
                if(num>0){
                    lbXinVaoLop.Text = " (" + num + ")";
                }
                //checkAdmin();
                //lbname.Text  
            }
            long id = CGlobal.GetUserID();
            try
            {
                DataTable dt = objUser.LoadByID(id);
                DataRow dtRow = dt.Rows[0];
                lbUserFullName.Text = dtRow["FullName"].ToString();
                lbUserName.Text = dtRow["UserName"].ToString();
                lbUserCode.Text = dtRow["UserCode"].ToString();
                imgAvatar.ImageUrl = (dtRow["Avatar"].ToString());
                imgAvatarSlide.ImageUrl = (dtRow["Avatar"].ToString());

                if (!objUser.CheckIsAdmin(id))
                {
                    logOut();
                }

            }
            catch (Exception)
            {
                logOut();
            }
        }

        void logOut()
        {
            Session.Clear();
            Session[CGlobal.USER_ID] = 0;
            Response.Redirect("~/Pages/Controler/Login.aspx");
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            logOut();
        }
    }
}