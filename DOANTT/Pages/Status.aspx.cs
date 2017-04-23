using BUS;
using DevExpress.Web;
using DevExpress.Web.Rendering;
using HELPER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DOANTT.Pages
{
    public partial class Status : System.Web.UI.Page
    {
        private BUS.BUS_Submission objSub = new BUS.BUS_Submission();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("TRẠNG THÁI");
                initForm();
                Search();
            }
        }

        public int getQueryString(string querystring)
        {
            try
            {
                return int.Parse(Request.QueryString[querystring].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvData);
        }


        private void Search()
        {
            grvData.DataSource = objSub.LoadByStatus();
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
            //if (e.CellValue != null)
            //{
            //    string toolTip = Environment.NewLine +
            //        "Điểm tối đa: " + grvData.GetRowValues(e.VisibleIndex, "MaximumPoints").ToString() + Environment.NewLine + Environment.NewLine +
            //        "Thời gian tối đa: " + grvData.GetRowValues(e.VisibleIndex, "TimeLimit").ToString() + " ms" + Environment.NewLine + Environment.NewLine +
            //        "Bộ nhớ tối đa: " + grvData.GetRowValues(e.VisibleIndex, "MemoryLimit").ToString() + " KB" + Environment.NewLine + Environment.NewLine +
            //        "Dung lượng code tối đa: " + grvData.GetRowValues(e.VisibleIndex, "SourceCodeSizeLimit").ToString() + " KB" + Environment.NewLine;
            //    //+ e.CellValue.ToString();
            //    e.Cell.ToolTip = toolTip;
            //}

        }

        protected void grvData_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            if (e.RowType != GridViewRowType.Data && !grid.IsEditing) return;
            string value = (string)e.GetValue("process");
            if (value == "Thành công")
            {
                e.Row.BackColor = Color.Green;
                e.Row.ForeColor = Color.White;
            }
            else if (value == "Lỗi biên dịch")
            {
                e.Row.BackColor = Color.Orange;
                e.Row.ForeColor = Color.White;
            }
            else if (value == "Lỗi khi chạy")
            {
                e.Row.BackColor = Color.Red;
                e.Row.ForeColor = Color.White;
            }
            else if (value == "Đang xử lý")
            {
                e.Row.BackColor = Color.Yellow;
                e.Row.ForeColor = Color.Black;
            }
        }

    }
}