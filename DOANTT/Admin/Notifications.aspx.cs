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
    public partial class Notifications : System.Web.UI.Page
    {
        private HELPER.CGlobal.FunctionMode FMode;
        private BUS.BUS_Contests objContest = new BUS.BUS_Contests();
        private BUS.BUS_Users objUser = new BUS.BUS_Users();
        private BUS.BUS_Problems objProb = new BUS.BUS_Problems();
        private BUS.BUS_Notification objNoti = new BUS.BUS_Notification();

        private BUS.BUS_MyNotification objMyNoti = new BUS.BUS_MyNotification();

        private BUS.BUS_M_LOOKUP objM_Lookup = new BUS.BUS_M_LOOKUP();

        public static string STR_KHOAHOC = "Khóa học";
        public static string STR_BAITAP = "Bài tập";
        public static string STR_USER = "Người nhận";

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
            CGlobal.SetSessionTitleAdmin("QUẢN TRỊ THÔNG BÁO");
            objProb.LoadToCheckList(cblProblemID);
            objContest.LoadToCheckList(cblContestID);
            objUser.LoadToCheckList(cblUserID);
            objM_Lookup.LoadNotiTypeToCombo(cboNotiType, false);
            cboNotiType_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void Search()
        {
            grvData.DataSource = objNoti.LoadBySearch(cboFillter.SelectedIndex);
            grvData.DataBind();
            switch (cboFillter.SelectedIndex)
            {

                case 1: //show khóa học
                    grvData.Columns[STR_KHOAHOC].Visible = true;
                    grvData.Columns[STR_BAITAP].Visible = false;
                    grvData.Columns[STR_USER].Visible = false;
                    break;
                case 2: // show bt
                    grvData.Columns[STR_KHOAHOC].Visible = false;
                    grvData.Columns[STR_BAITAP].Visible = true;
                    grvData.Columns[STR_USER].Visible = false;
                    break;
                case 3: // show user 
                    grvData.Columns[STR_KHOAHOC].Visible = false;
                    grvData.Columns[STR_BAITAP].Visible = false;
                    grvData.Columns[STR_USER].Visible = true;
                    break;
                default:
                    grvData.Columns[STR_KHOAHOC].Visible = true;
                    grvData.Columns[STR_BAITAP].Visible = true;
                    grvData.Columns[STR_USER].Visible = true;
                    break;
            }

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
            try
            {
                return long.Parse(hdf.Value.ToString());
            }
            catch (Exception)
            {
                return -1;
            }
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
            objNoti = new BUS.BUS_Notification(dao);
            BUS.BUS_MyNotification objMyNoti = new BUS.BUS_MyNotification(dao);
            try
            {
                dao.BeginTransaction();
                HELPER.CWebPage.BindProperty(objNoti, pnEdit);
                objNoti.NotiType = int.Parse(cboNotiType.Value.ToString());
                FMode = getMode();

                long NotiID = 0;
                if (FMode == CGlobal.FunctionMode.AddMode)
                {
                    NotiID = objNoti.Insert();
                    setHdf(hdfID, NotiID);
                    objMyNoti.NotificationID = NotiID;
                    switch (objNoti.NotiType)
                    {
                        case 1://khoa hoc
                            foreach (ListEditItem item in cblContestID.Items)
                            {
                                if (item.Selected)
                                {
                                    objMyNoti.ContestID = long.Parse(item.Value.ToString());
                                    objMyNoti.Insert();
                                }
                            }
                            break;
                        case 2://bt
                            foreach (ListEditItem item in cblProblemID.Items)
                            {
                                if (item.Selected)
                                {
                                    objMyNoti.ProblemID = long.Parse(item.Value.ToString());
                                    objMyNoti.Insert();
                                }
                            }
                            break;
                        case 3: // user
                            foreach (ListEditItem item in cblUserID.Items)
                            {
                                if (item.Selected)
                                {
                                    objMyNoti.UserID = long.Parse(item.Value.ToString());
                                    objMyNoti.Insert();
                                }
                            }
                            break;
                        default:
                            throw new Exception("Chọn loại thông báo!");
                            break;

                    }

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
                    //DataTable dt = objContest.LoadByID(getHdf(hdfID));
                    // HELPER.CWebPage.BindPanel(pnEdit, dt);

                }
                else //AddMode
                {
                }

            }
            else if (FMode == CGlobal.FunctionMode.CloseMode || FMode == CGlobal.FunctionMode.SearchMode)
            {
                pnMain.Visible = true;
                pnEdit.Visible = false;
                //Response.Redirect(Request.RawUrl);
            }

        }

        protected void grvData_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            long NotiID = long.Parse(grvData.GetRowValues(e.VisibleIndex, grvData.KeyFieldName).ToString());
            // long myNotiID = long.Parse(CGlobal.getDataByColumn(myNotiID, "NotificationID", "V_MyNotification"));

            if (e.ButtonID == "GridEdit")
            {
                setHdf(hdfID, NotiID);
                setMode(CGlobal.FunctionMode.EditMode);
                initFuncMode();
            }
            else if (e.ButtonID == "GridDelete")
            {
                try
                {
                    objNoti.Delete(NotiID);
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



        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName == "Description")
            //if (e.CellValue != null)
            //{
            //    string toolTip = Environment.NewLine +
            //        "Mô tả: " + grvData.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
            //        "Mật khẩu: " + grvData.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine + Environment.NewLine +
            //        "Sửa gần nhất: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine +
            //        "Tạo bởi: " + grvData.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine;

            //    +e.CellValue.ToString();
            //    e.Cell.ToolTip = toolTip;
            //}

            if (e.DataColumn.FieldName == grvData.KeyFieldName)
            {
                setHdf(hdfID, long.Parse(e.CellValue.ToString()));
            }
            string cap = e.DataColumn.Caption;
            if (cap == STR_KHOAHOC || cap == STR_BAITAP || cap == STR_USER)
            {
                DataTable dt = objMyNoti.LoadBySearchComponent(0, getHdf(hdfID));
                if (cap == STR_KHOAHOC)
                {
                    dt = objMyNoti.LoadBySearchComponent(1, getHdf(hdfID));
                }
                if (cap == STR_BAITAP)
                {
                    dt = objMyNoti.LoadBySearchComponent(2, getHdf(hdfID));
                }
                if (cap == STR_USER)
                {
                    dt = objMyNoti.LoadBySearchComponent(3, getHdf(hdfID));
                }
                string str = string.Empty;
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (!string.IsNullOrWhiteSpace(dt.Rows[i][0].ToString()))
                    {
                        str += dt.Rows[i][0].ToString() + ", ";
                    }

                }
                if (str.EndsWith(", "))
                {
                    e.Cell.Text = str.Substring(0, str.Length - 2);
                }

            }


        }


        protected void cboFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void cboNotiType_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (int.Parse(cboNotiType.Value.ToString()))
            {
                case 1://khoa hoc
                    trBaiTap.Visible = false;
                    trKhoaHoc.Visible = true;
                    trUser.Visible = false;
                    break;
                case 2://bt
                    trBaiTap.Visible = true;
                    trKhoaHoc.Visible = false;
                    trUser.Visible = false;
                    break;
                case 3: // user
                    trBaiTap.Visible = false;
                    trKhoaHoc.Visible = false;
                    trUser.Visible = true;
                    break;
                default:
                    trBaiTap.Visible = false;
                    trKhoaHoc.Visible = false;
                    trUser.Visible = false;
                    break;
            }
        }

    }
}
