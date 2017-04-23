using HELPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DevExpress.Web;

namespace DOANTT.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        private HELPER.CGlobal.FunctionMode FMode;
        private BUS.BUS_Users objUser = new BUS.BUS_Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initForm();
                Search();
            }
        }
        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvData);
            HELPER.CWebPage.FormatPanel(pnEdit);
            CGlobal.SetSessionTitleAdmin("QUẢN TRỊ NGƯỜI DÙNG");
            objUser.LoadType(cboUserType);
        }

        private void Search()
        {
            grvData.DataSource = objUser.LoadBySearch(cboFillter.SelectedIndex);
            grvData.DataBind();
        }


        protected void grvData_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            Search();
        }

        protected void grvData_PageSizeChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void grvData_PageIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void grvData_ProcessColumnAutoFilter(object sender, DevExpress.Web.ASPxGridViewAutoFilterEventArgs e)
        {
            Search();
        }

        protected void grvData_SearchPanelEditorCreate(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorCreateEventArgs e)
        {
            Search();
        }

        public void setMode(CGlobal.FunctionMode fmode)
        {
            hdfFunc.Value = fmode.ToString();
        }

        public CGlobal.FunctionMode getMode()
        {
            return (HELPER.CGlobal.FunctionMode)Enum.Parse(typeof(HELPER.CGlobal.FunctionMode), hdfFunc.Value);
        }

        public void setHdf(HiddenField hdf, long value)
        {
            hdf.Value = value.ToString();
        }

        public long getHdf(HiddenField hdf)
        {
            return long.Parse(hdf.Value.ToString());
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            setMode(CGlobal.FunctionMode.CloseMode);
            initFuncMode();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            setMode(CGlobal.FunctionMode.AddMode);
            initFuncMode();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseDAO dao = new DatabaseDAO();

            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (txtPassword.Text != txtPasswordAgain.Text)
                {
                    HELPER.Client.Alert(this, "Mật khẩu không trùng khớp!");
                    return;
                }
            }

            objUser = new BUS.BUS_Users(dao);
            try
            {
                HELPER.CWebPage.BindProperty(objUser, pnEdit);

                FMode = getMode();
                dao.BeginTransaction();

                if (FMode == CGlobal.FunctionMode.AddMode)
                {
                    objUser.Password = txtPassword.Text;
                    objUser.InsertByAdmin();
                }
                else if (FMode == CGlobal.FunctionMode.EditMode)
                {
                    objUser.Id = getHdf(hdfID);
                    objUser.UpdateByAdmin();
                }


                dao.EndTransaction();

                setMode(CGlobal.FunctionMode.SearchMode);
                initFuncMode();
            }

            catch (Exception ex)
            {
                dao.RollBack();
                HELPER.CError.ErrorType err = HELPER.CError.Parse(ex.Message);
                if (err == CError.ErrorType.Duplicate)
                {
                    HELPER.Client.Alert(this, "Dữ liệu đã tồn tại!");
                }
                else
                {
                    HELPER.Client.Alert(this, "Lỗi cấp nhật CSDL!" + err.ToString());
                }
            }
        }
        private void initFuncMode()
        {
            FMode = getMode();
            HELPER.CWebPage.ResetPanel(pnEdit);
            if (FMode == CGlobal.FunctionMode.AddMode || FMode == CGlobal.FunctionMode.EditMode)
            {
                pnMain.Visible = false;
                pnEdit.Visible = true;
                if (FMode == CGlobal.FunctionMode.EditMode)
                {
                    DataTable dt = objUser.LoadByID(getHdf(hdfID));
                    HELPER.CWebPage.BindPanel(pnEdit, dt);
                    txtUserName.ReadOnly = true;
                    trPass.Visible = false;
                    trPassAgain.Visible = false;
                }
                else //AddMode
                {
                    txtUserName.ReadOnly = false;
                    trPass.Visible = true;
                    trPassAgain.Visible = true;
                }
            }
            else if (FMode == CGlobal.FunctionMode.CloseMode || FMode == CGlobal.FunctionMode.SearchMode)
            {
                pnMain.Visible = true;
                pnEdit.Visible = false;
                Response.Redirect(Request.RawUrl);
            }

        }

        protected void grvData_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            long id = long.Parse(grvData.GetRowValues(e.VisibleIndex, grvData.KeyFieldName).ToString());
            if (e.ButtonID == "GridEdit")
            {
                setHdf(hdfID, id);
                setMode(CGlobal.FunctionMode.EditMode);
                initFuncMode();
            }
            else if (e.ButtonID == "GridDelete")
            {
                try
                {
                    objUser.Delete(id);
                    setMode(CGlobal.FunctionMode.SearchMode);
                    initFuncMode();
                }
                catch (Exception ex)
                {
                    HELPER.CError.ErrorType err = HELPER.CError.Parse(ex.Message);
                    if (err == CError.ErrorType.InUse)
                    {
                        HELPER.Client.Alert(this, "Dữ liệu đã được sử dụng. Không thể xóa được!");
                    }
                    else
                    {
                        HELPER.Client.Alert(this, "Lỗi xóa dữ liệu!");
                    }
                }
            }

        }



        void clickMulti(int clickType)
        {
            List<Object> selectItemsID = new List<object>();
            selectItemsID = grvData.GetSelectedFieldValues(grvData.KeyFieldName);
            DatabaseDAO dao = new DatabaseDAO();
            objUser = new BUS.BUS_Users(dao);
            BUS.BUS_Notification objNoti = new BUS.BUS_Notification(dao);
            BUS.BUS_MyNotification objMyNoti = new BUS.BUS_MyNotification(dao);
            try
            {
                long acceptBy = CGlobal.GetUserID();

                if (selectItemsID.Count <= 0)
                {
                    HELPER.Client.Alert(this, "Bạn chưa chọn người dùng nào!");
                }
                else
                {
                    long idNoti = 0;
                    switch (clickType)
                    {
                        case 1: // del , xóa
                            break;
                        case 2: // accept, kích hoạt
                            idNoti = objNoti.Insert(acceptBy, "Đã kích hoạt tài khoản của bạn", 3);
                            break;
                        case 3: // un accept, bỏ kích hoạt
                            break;
                        case 4: // to Usertype 1, sinh viên
                            idNoti = objNoti.Insert(acceptBy, "Đã chuyển tài khoản của bạn thành tài khoản Sinh Viên", 3);
                            break;
                        case 5: // to Usertype 2. Giáo viên
                            idNoti = objNoti.Insert(acceptBy, "Đã chuyển tài khoản của bạn thành tài khoản Giáo Viên", 3);
                            break;
                        default:
                            break;
                    }

                    foreach (object selectItemId in selectItemsID)
                    {

                        long userId = long.Parse(selectItemId.ToString());

                        switch (clickType)
                        {
                            case 1: // del , xóa
                                objUser.Delete(userId);

                                break;
                            case 2: // accept, kích hoạt
                                objUser.UpdateByAdminEnable(userId, 1);
                                objMyNoti.Insert(idNoti, userId);
                                break;
                            case 3: // un accept, bỏ kích hoạt
                                objUser.UpdateByAdminEnable(userId, 0);
                                break;
                            case 4: // to Usertype 1, sinh viên
                                objUser.UpdateByAdminType(userId, 1);
                                objMyNoti.Insert(idNoti, userId);
                                break;
                            case 5: // to Usertype 2. Giáo viên
                                objUser.UpdateByAdminType(userId, 2);
                                objMyNoti.Insert(idNoti, userId);
                                break;
                            default:
                                break;
                        }
                    }

                    Response.Redirect(Request.RawUrl, false);
                }
            }
            catch (Exception ex)
            {
                HELPER.Client.Alert(this, "Lỗi cập nhật CSDL! " + ex.Message);
            }
        }


        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.CellValue != null)
            //{
            //    string toolTip = Environment.NewLine +
            //        "Mô tả: " + grvData.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
            //        "Mật khẩu: " + grvData.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine + Environment.NewLine +
            //        "Sửa gần nhất: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine +
            //        "Tạo bởi: " + grvData.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine;

            //    //+ e.CellValue.ToString();
            //    e.Cell.ToolTip = toolTip;
            //}
        }


        protected void cboFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            clickMulti(1);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            clickMulti(2);
        }

        protected void btnNotAccept_Click(object sender, EventArgs e)
        {
            clickMulti(3);
        }

        protected void btnStudent_Click(object sender, EventArgs e)
        {
            clickMulti(4);
        }

        protected void btnTeacher_Click(object sender, EventArgs e)
        {
            clickMulti(5);
        }

    }
}
