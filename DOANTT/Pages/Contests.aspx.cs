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
    public partial class Contests : System.Web.UI.Page
    {
        private BUS.BUS_Contests objContest = new BUS.BUS_Contests();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("TẤT CẢ CÁC KHÓA HỌC");
                initForm();
            }
        }
        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvData);
            grvData.DataSource = objContest.LoadByUserID();
            grvData.DataBind();
        }

        private void Search()
        {
            grvData.DataSource = objContest.LoadByUserID();
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
            try
            {
                long id = long.Parse(grvData.GetRowValues(e.VisibleIndex, grvData.KeyFieldName).ToString());
                if (e.ButtonID == "GridEdit")
                {
                    BUS.BUS_MyContest obj = new BUS.BUS_MyContest();
                    obj.ContestId = id;
                    obj.Insert();
                    HELPER.Client.Alert(this, "Đã nộp yêu cầu!");
                    //   Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                HELPER.Client.Alert(this, "Bạn đã nộp yêu cầu vào khóa học này rồi! " + ex.ToString());
            }
        }

        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.CellValue != null)
            {
                string toolTip = Environment.NewLine +
                    "Mô tả: " + grvData.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
                    "Mật khẩu: " + grvData.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine + Environment.NewLine +
                    "Sửa gần nhất: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine +
                    "Tạo bởi: " + grvData.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine;
                //+ e.CellValue.ToString();


                if (grvData.GetRowValues(e.VisibleIndex, "StartTime") != null)
                {
                    try
                    {
                         toolTip += "Bắt đầu: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "StartTime").ToString()).ToString("HH:mm, dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                if (grvData.GetRowValues(e.VisibleIndex, "EndTime") != null)
                {
                    try
                    {
                        toolTip += "Kết thúc: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "EndTime").ToString()).ToString("HH:mm, dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;
                    }
                    catch (Exception)
                    {
                        
                    }
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
                e.Cell.ToolTip = toolTip;
            }


        }


    }
}