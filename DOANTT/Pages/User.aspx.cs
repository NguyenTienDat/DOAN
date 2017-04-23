using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using System.Data;
using System.Data.SqlClient;
namespace Pages
{
    public partial class User : System.Web.UI.Page
    {
        BUS_Users user = new BUS_Users();

        static int userid = 1;

        DevExpress.Web.ASPxTextBox txtName, txtUsername, txtPassold, txtpasnew, txtPassAgain, txtEmail, txtAddress, txtPhone;


        //  DevExpress.Web.ASPxSpinEdit txtSL;
        //   DevExpress.Web.ASPxTextBox txtThanhTien;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("QUẢN LÝ THÔNG TIN CÁ NHÂN");
            }

            try
            {
                userid = int.Parse(Session["userid"].ToString());
            }
            catch (Exception)
            {
            }
            if (!IsPostBack)
            {
                //DataListUser.DataSource = user.selectByID(userid);
                DataListUser.DataBind();
            }
            else
            {
                getUserInfor();

            }
            int ID_SELECTED = 1;
            try
            {
                ID_SELECTED = int.Parse(hdProduct.Value.ToString());
            }
            catch (Exception)
            {
            }

            //txtSL = DataListEditOrder.Controls[0].FindControl("txtSL") as DevExpress.Web.ASPxSpinEdit;

            // txtThanhTien = DataListEditOrder.Controls[0].FindControl("txtThanhTien") as DevExpress.Web.ASPxTextBox;




        }

        protected void btnShowUpdate_Click(object sender, EventArgs e)
        {
            pnUser.Visible = !pnUser.Visible;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            getUserInfor();

            //if (user.GetType(objProblem.UserName, objProblem.PassWord) >= 0
            //    && txtpasnew.Text.Equals(txtPassAgain.Text)
            //    && txtpasnew.Text != "" && txtPassAgain.Text != ""
            //    )
            //{
            //    user.updateByID(objProblem);
            //    BUS.CGloble.Alert(this, "Cập nhật thành công thông tin của bạn: " + objProblem.UserName);

            //}
            //else
            //{
            //    BUS.CGloble.Alert(this, "Vui lòng xem lại thông tin!");
            //    txtpasnew.Text = "";
            //    txtPassAgain.Text = "";
            //    txtPassold.Text = "";
            //}

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            pnUser.Visible = false;
        }

        void getUserInfor()
        {
            Control Template = DataListUser.Controls[0].Controls[0];
            txtName = Template.FindControl("txtName") as DevExpress.Web.ASPxTextBox;
            txtUsername = Template.FindControl("txtUsername") as DevExpress.Web.ASPxTextBox;
            txtpasnew = Template.FindControl("txtPassOld") as DevExpress.Web.ASPxTextBox;
            txtPassold = Template.FindControl("txtPassNew") as DevExpress.Web.ASPxTextBox;
            txtPassAgain = Template.FindControl("txtPassAgain") as DevExpress.Web.ASPxTextBox;
            txtEmail = Template.FindControl("txtEmail") as DevExpress.Web.ASPxTextBox;
            txtAddress = Template.FindControl("txtAddress") as DevExpress.Web.ASPxTextBox;
            txtPhone = Template.FindControl("txtPhone") as DevExpress.Web.ASPxTextBox;
            //objProblem.ID = int.Parse(Session["userid"].ToString());
            //try
            //{
            //    objProblem.NAME = txtName.Text;
            //}
            //catch (Exception)
            //{
            //    objProblem.NAME = "";
            //}
            //try
            //{
            //    objProblem.UserName = txtUsername.Text;
            //}
            //catch (Exception)
            //{
            //    objProblem.UserName = "";
            //}
            //try
            //{
            //    objProblem.PassWord = txtPassold.Text;
            //}
            //catch (Exception)
            //{
            //    objProblem.PassWord = "";
            //}
            //try
            //{
            //    objProblem.EMAIL = txtEmail.Text;
            //}
            //catch (Exception)
            //{
            //    objProblem.EMAIL = "";
            //}
            //try
            //{
            //    objProblem.ADDRESS = txtAddress.Text;
            //}
            //catch (Exception)
            //{
            //    objProblem.ADDRESS = "";
            //}
            //try
            //{
            //    objProblem.PHONE = txtPhone.Text;
            //}
            //catch (Exception)
            //{
            //    objProblem.PHONE = "";
            //}
        }

        protected void ASPxGridViewOder_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            int ID_SELECTED = int.Parse(ASPxGridViewOder.GetRowValues(e.VisibleIndex, ASPxGridViewOder.KeyFieldName).ToString());
            hdProduct.Value = ID_SELECTED.ToString();

            if (e.ButtonID == "GridEdit")
            {
                pnEdit.Visible = true;



            }
            else if (e.ButtonID == "GridDel")
            {

                Response.Redirect("User.aspx");
            }
        }


        protected void btnXong_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void txtSL_ValueChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = string.Format("{0:#,###}", (int.Parse(txtSL.Text) * float.Parse(hdPrice.Value.ToString())));
        }

    }
}