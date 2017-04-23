using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace DOANTT.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserInfor();
        }
        protected void getUserInfor()
        {
            try
            {
                BUS.BUS_Users objUser = new BUS.BUS_Users();
                long userID = HELPER.CGlobal.GetUserID();

                DataTable dt = objUser.LoadByID(userID);
                DataRow dtRow = dt.Rows[0];

                imgAvatarSlide.ImageUrl = (dtRow["Avatar"].ToString());
                //lblAddress.Text = (dtRow["Adress"].ToString());
                lblClass.Text = (dtRow["Class"].ToString());
                dteDateOfBirth.Date = DateTime.Parse((dtRow["DateOfBirth"].ToString()));
                dteDateOfBirth.Enabled = false;
                lblEmail.Text = (dtRow["Email"].ToString());
                lblFullName.Text = (dtRow["FullName"].ToString());
                lblPhone.Text = (dtRow["Phone"].ToString());
                lblUserName.Text = (dtRow["UserName"].ToString());

                lblCourse.Text = objUser.P_GET_COUNT_COUNTEST_BY_USERID().Rows[0]["COUNT_COURSE"].ToString();

                lblSubmit.Text = objUser.GetCOUNT_SUBMIT().Rows[0]["COUNT_SUBMIT"].ToString();
            }
            catch (Exception)
            {

            }

        }
    }
}