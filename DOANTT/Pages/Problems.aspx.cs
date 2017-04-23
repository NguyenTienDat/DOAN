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
    public partial class Problems : System.Web.UI.Page
    {
        private BUS.BUS_Problems objProblem = new BUS.BUS_Problems();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int type = getQueryString("status");
                switch (type)
                {
                    case 3: // bai thi 
                        rblFilter.SelectedIndex = 1;
                        HELPER.CGlobal.SetSessionTitleUser("BÀI KIỂM TRA");
                        objProblem.LoadByType(3);
                        break;
                    default:
                        rblFilter.SelectedIndex = 0;
                        HELPER.CGlobal.SetSessionTitleUser("BÀI TẬP ÔN");
                        objProblem.LoadByType(2);
                        break;
                }
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
            grvData.DataSource = objProblem.LoadByType(rblFilter.SelectedIndex+2);
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
            switch (rblFilter.SelectedIndex)
            {
                case 1: // bai thi 
                    Response.Redirect("Problems.aspx?status=3");
                    break;
                default:
                    Response.Redirect("Problems.aspx?status=2");
                    break;
            }
        }

        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName == "Description")
            if (e.CellValue != null)
            {
                string toolTip = Environment.NewLine +
                    "Điểm tối đa: " + grvData.GetRowValues(e.VisibleIndex, "MaximumPoints").ToString() + Environment.NewLine + Environment.NewLine +
                    "Thời gian tối đa: " + grvData.GetRowValues(e.VisibleIndex, "TimeLimit").ToString() + " ms" + Environment.NewLine + Environment.NewLine +
                    "Bộ nhớ tối đa: " + grvData.GetRowValues(e.VisibleIndex, "MemoryLimit").ToString() + " KB" + Environment.NewLine + Environment.NewLine +
                    "Dung lượng code tối đa: " + grvData.GetRowValues(e.VisibleIndex, "SourceCodeSizeLimit").ToString() + " KB" + Environment.NewLine;
                //+ e.CellValue.ToString();
                e.Cell.ToolTip = toolTip;
            }



        }


    }
}