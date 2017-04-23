using BUS;
using DevExpress.Web;
using HELPER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DOANTT.Pages
{
    public partial class Rank : System.Web.UI.Page
    {

        BUS.BUS_Users objUser = new BUS_Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("XẾP HẠNG");
                initForm();
                Search();
            }

        }


        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvData);
        }


        private void Search()
        {
            //grvData.DataSource = objProject.Search(txtPROJECT_CODE_Search.Text, txtPROJECT_NAME_Search.Text, long.Parse(cboPROJECT_TYPE_ID_Search.Value.ToString()));
            grvData.DataSource = objUser.LoadRank();
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

        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName == "Description")
            //if (e.CellValue != null)
            //{
            //    string toolTip = Environment.NewLine +
            //        ": " + grvData.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
            //        "M?t kh?u: " + grvData.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine + Environment.NewLine +
            //        "S?a g?n nh?t: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine +
            //        "T?o b?i: " + grvData.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine;

            //    //+ e.CellValue.ToString();
            //    e.Cell.ToolTip = toolTip;
            //}

        }


    }
}