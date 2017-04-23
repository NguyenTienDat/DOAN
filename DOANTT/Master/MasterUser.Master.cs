using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BUS;
using HELPER;
using System.Data;
using System.Web.UI.HtmlControls;

namespace DOANTT.Master
{
    public partial class MasterUser : System.Web.UI.MasterPage
    {
        BUS_Users objUser = new BUS_Users();
        BUS_MyNotification objMyNoti = new BUS_MyNotification();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbTruyCap.Text = Application.Contents["SoNguoiTruyCap"].ToString();
            lbTongTruyCap.Text = Application.Contents["TongTruyCap"].ToString();
            getNoti();
            
            if (!IsPostBack)
            {
                lbTitle.Text = CGlobal.GetTitleUser();
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

                if (objUser.CheckIsAdmin(id))
                {
                    liGoToAdmin.Visible = true;
                }
                else
                {
                    liGoToAdmin.Visible = false;
                }
                
            }
            catch
            {
                logOut();
            }
        }

        void getNoti()
        {
            rptNoti.DataSource = objMyNoti.GetMyNotiByUser(CConstant.C_NOTIFY_MAX);
            rptNoti.DataBind();
            string num = objMyNoti.GetMyNotiNotSeenByUser();
            lbCountNoti.Text = num;
            if (int.Parse(num) <= 0)
            {
                pnCountNoti.Visible = false;
            }
            else
            {
                string tooltip = "Bạn có " + num + " thông báo mới chưa đọc!";
                pnCountNoti.ToolTip = tooltip;
                pnNoti.ToolTip = tooltip;
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

        HtmlAnchor aRepeatID = null;
        DevExpress.Web.ASPxLabel lb = null;
        protected void rptNoti_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dt = (DataRowView)e.Item.DataItem;
            if (dt != null)
            {
                aRepeatID = e.Item.FindControl("aRepeatID") as HtmlAnchor;
                if (aRepeatID != null)
                {
                    aRepeatID.HRef = "../Pages/MyNotifications.aspx?ID="+dt["ID"].ToString();
                }

                lb = (DevExpress.Web.ASPxLabel)e.Item.FindControl("noti_message");
                if (lb != null && dt["Content"] != null)
                {
                    string content = dt["Content"].ToString();
                    lb.ToolTip = content;
                    int maxLength = 80;
                    if (content.Length > maxLength)
                    {
                        lb.Text = content.Substring(0, maxLength) + "...";
                    }
                    else
                    {
                        lb.Text = content;
                    }
                }

                lb = (DevExpress.Web.ASPxLabel)e.Item.FindControl("noti_time");
                if (lb != null)
                {
                    lb.Text = HELPER.CDateTime.getTimeNoti(DateTime.Parse(dt["CreatedOn"].ToString()));
                }
            }
        }

      
    }
}