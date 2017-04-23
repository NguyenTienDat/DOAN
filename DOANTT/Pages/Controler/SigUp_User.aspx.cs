using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BUS;
namespace Pages.Controler
{
    public partial class SigUp_User : System.Web.UI.Page
    {
        BUS_Users user = new BUS_Users();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

            //DTO.User us = new DTO.User(-1, CGloble.getText(txtName), CGloble.getText(txtUname), CGloble.getText(txtPass), 1, false, CGloble.getText(txtEmail), CGloble.getText(txtAddress), CGloble.getText(txtPhone));
            try
            {
                BUS_Users objUser = new BUS_Users();
                
                objUser.FullName = txtName.Text;
                objUser.UserName = txtUname.Text;
                objUser.Password = txtPass.Text;
                objUser.Email = txtEmail.Text;
               // objUser.Adress = txtAddress.Text;
                objUser.Phone = txtPhone.Text;
                objUser.DateOfBirth = dteDateOfBirth.Date;
                objUser.Class = txtClass.Text;
                 
                if (objUser.Insert()>0)
                {
                    HELPER.Client.Alert(this, "Đăng ký thành công!");
                    Response.Redirect("~/Pages/Controler/Login_User.aspx",false);
                }
                else
                {
                    HELPER.Client.Alert(this, "Đăng ký thất bại! Hãy kiểm tra lại dữ liệu bạn nhập vào!");
                    txtPass.Text = "";
                }
            }
            catch(Exception ex)
            {
                
                HELPER.Client.Alert(this, "Đăng ký thất bại! Hãy kiểm tra lại dữ liệu bạn nhập vào!");

            }
            

        }




        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
}