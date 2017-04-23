using DevExpress.Web;
using HELPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DOANTT.Pages
{
    public partial class MyContests : System.Web.UI.Page
    {
        private BUS.BUS_MyContest obj = new BUS.BUS_MyContest();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("KHÓA HỌC CỦA BẠN");
                initForm();
                Search();
            }
        }
        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvData);
        }

        protected void grvData_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            long id = long.Parse(grvData.GetRowValues(e.VisibleIndex, grvData.KeyFieldName).ToString());
            if (e.ButtonID == "GridDelete")
            {
                try
                {
                    obj.Delete(id);
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

        private void Search()
        {
            grvData.DataSource = obj.LoadByUserID(rblFilter.SelectedIndex);
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
        protected void grvData_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            Search();
        }

        protected void grvData_SearchPanelEditorCreate(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorCreateEventArgs e)
        {
            Search();
        }

        protected void rblFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            Search();
        }

        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName == "Description")
            if (e.CellValue != null)
            {
                string toolTip = Environment.NewLine +
                    "Mô tả: " + grvData.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
                    "Tạo bởi " + grvData.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine + Environment.NewLine +
                    "Sửa gần đây nhất: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;

                if (rblFilter.SelectedIndex != 2)
                { //chưa được duyệt không thể nhìn thấy password
                    toolTip += "Mật khẩu   : " + grvData.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine;
                }

                try
                {
                    if (grvData.GetRowValues(e.VisibleIndex, "StartTime") != null)
                    {
                        toolTip += "Bắt đầu: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "StartTime").ToString()).ToString("HH:mm, dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;
                    }
                    if (grvData.GetRowValues(e.VisibleIndex, "EndTime") != null)
                    {
                        toolTip += "Kết thúc: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "EndTime").ToString()).ToString("HH:mm, dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;
                    }
                }
                catch (Exception)
                {
                }
                if (e.DataColumn.FieldName == "StartTime" || e.DataColumn.FieldName == "EndTime")
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(e.CellValue.ToString());
                        e.Cell.Text = CDateTime.getTimeNoti(dt);
                    }
                    catch
                    {

                    }
                }
                //+ e.CellValue.ToString();
                e.Cell.ToolTip = toolTip;
                // e.Cell.Visible = false;

                try
                {
                    if (e.DataColumn.FieldName == "ContestId")
                    {
                        if (rblFilter.SelectedIndex == 2) // chưa phê duyệt thì k được xem
                        {
                            e.Cell.Enabled = false;
                        }


                        else if (rblFilter.SelectedIndex == 1) // đã phê duyệt mà hết hạn cũng không được tham gia
                        {
                            DateTime startTime = DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "StartTime").ToString());
                            DateTime endTime = DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "EndTime").ToString());
                            DateTime now = DateTime.Now;
                            if (now > endTime || now < startTime)
                            {
                                e.Cell.Enabled = false;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }



        }


    }
}