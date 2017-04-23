using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BUS;

namespace Pages.Controler
{
    public partial class Login : System.Web.UI.Page
    {
        BUS_Users user = new BUS_Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            if (!IsPostBack)
            {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            String tenNguoiDung = txtUserName.Text;
            String matKhau = txtPassword.Text;

            //Validate
            if (String.IsNullOrEmpty(tenNguoiDung))
            {
                error_div.Attributes.CssStyle["display"] = "block";
                lblError.Text = "Tên đăng nhập không được bỏ trống";
                txtUserName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(matKhau))
            {
                error_div.Attributes.CssStyle["display"] = "block";
                lblError.Text = "Mật khẩu không được bỏ trống";
                txtPassword.Focus();
                return;
            }

            long userID = user.GetID(tenNguoiDung, matKhau);
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
                error_div.Attributes.CssStyle["display"] = "block";
                lblError.Text = "Tên đăng nhập hoặc mật khẩu không đúng";
            }

            //AccessControl.SignOut();
            //AccessControl.SignIn(tenNguoiDung, matKhau);

            //if (AccessControl.IsLoggedIn)
            //{
            //    //Remember user                
            //    HttpCookie cookieUsername = new HttpCookie("uname", tenNguoiDung);
            //    cookieUsername.Expires = DateTime.Now.AddDays(30);
            //    HttpCookie cookiePassword = new HttpCookie("upass", matKhau);
            //    cookiePassword.Expires = DateTime.Now.AddDays(30);
            //    Response.Cookies.Add(cookieUsername);
            //    Response.Cookies.Add(cookiePassword);  

            //    Response.Redirect("~");
            //}
            //else
            //{
            //    
            //}
        }
    }
}