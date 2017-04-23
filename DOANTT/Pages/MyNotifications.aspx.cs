using HELPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using DevExpress.Web;

namespace DOANTT.Pages
{
    public partial class MyNotifications : System.Web.UI.Page
    {

        private BUS.BUS_MyNotification objMyNoti = new BUS.BUS_MyNotification();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    long myNotiID = long.Parse(Request.QueryString["ID"].ToString());
                    objMyNoti.UpdateStatus(myNotiID, 2);
                    cboFillter.SelectedIndex = 1;
                }
                catch
                {
                    
                }

                initForm();
                Search();
               
            }
        }
        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvData);
            CGlobal.SetSessionTitleUser("THÔNG BÁO CỦA BẠN");
        }

        private void Search()
        {
            grvData.DataSource = objMyNoti.LoadBySearch(cboFillter.SelectedIndex);
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


        protected void grvData_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            long myNotiID = long.Parse(grvData.GetRowValues(e.VisibleIndex, grvData.KeyFieldName).ToString());

            if (e.ButtonID == "GridDelete")
            {
                try
                {
                    objMyNoti.Delete(myNotiID);
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
           // if (e.DataColumn.FieldName == "Date")
                if (e.CellValue != null)
                {
                    string toolTip = Environment.NewLine +
                        "Người gửi: " + grvData.GetRowValues(e.VisibleIndex, "NameCreatedBy").ToString() + Environment.NewLine + Environment.NewLine +
                        "Nội dung: " + grvData.GetRowValues(e.VisibleIndex, "Content").ToString() + Environment.NewLine + Environment.NewLine +
                        "Ngày giờ: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "Date").ToString()).ToString("HH:mm, dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;
                    e.Cell.ToolTip = toolTip;
                }
                if (e.DataColumn.FieldName == "Date")
                {
                    if (e.CellValue != null)
                    {
                        e.Cell.Text = CDateTime.getTimeNoti(DateTime.Parse(e.CellValue.ToString()));
                    }
                }
        }


        protected void cboFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnNotSeen_Click(object sender, EventArgs e)
        {
            clickMulti(3);
        }

        protected void btnSeen_Click(object sender, EventArgs e)
        {
            clickMulti(2);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            clickMulti(1);
        }

        void clickMulti(int clickType)
        {
            List<Object> selectItemsID = new List<object>();
            selectItemsID = grvData.GetSelectedFieldValues(grvData.KeyFieldName);
            try
            {
                long acceptBy = CGlobal.GetUserID();

                if (selectItemsID.Count <= 0)
                {
                    HELPER.Client.Alert(this, "Bạn chưa chọn thông báo nào!");
                }
                else
                {

                    foreach (object selectItemId in selectItemsID)
                    {

                        long myNotiID = long.Parse(selectItemId.ToString());

                        switch (clickType)
                        {
                            case 1: // del , xóa
                                objMyNoti.Delete(myNotiID);
                                break;
                            case 2: // đã xem
                                objMyNoti.UpdateStatus(myNotiID, 2);
                                break;
                            case 3: // un accept, bỏ kích hoạt
                                objMyNoti.UpdateStatus(myNotiID, 1);
                                break;
                            default:
                                break;
                        }
                    }

                }
                Response.Redirect(Request.RawUrl,false);
            }
            catch (Exception ex)
            {
                HELPER.Client.Alert(this, "Lỗi cập nhật CSDL! " + ex.Message);
            }
        }


    }
}
