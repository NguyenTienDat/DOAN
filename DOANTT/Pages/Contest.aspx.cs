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
    public partial class Contest : System.Web.UI.Page
    {
        private BUS.BUS_ProblemsInContest obj = new BUS.BUS_ProblemsInContest();

        private BUS.BUS_MyContest objMyContest = new BUS.BUS_MyContest();
        private BUS.BUS_Contests objContest = new BUS.BUS_Contests();

        long contestId;
        public long getQueryString(string querystring)
        {
            try
            {
                return long.Parse(Request.QueryString[querystring].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            contestId = getQueryString("ContestId");
            if (!objMyContest.CheckIsAccepted(contestId))
            {
                HELPER.Client.Alert(this, "KHÓA HỌC NÀY CHƯA ĐƯỢC PHÊ DUYỆT");
                Response.Redirect("MyContests.aspx");
            }
            if (!objContest.CheckIsAvailable(contestId))
            {
                HELPER.Client.Alert(this, "KHÓA HỌC NÀY ĐÃ HẾT HIỆU LỰC");
                Response.Redirect("MyContests.aspx");
            }

            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("BÀI TẬP TRONG KHÓA");
                initForm();

            }
        }
        private void initForm()
        {
            string pass = objContest.GetPassword(contestId);
            if (string.IsNullOrWhiteSpace(pass))
            {
                ppPass.ShowOnPageLoad = false;

                HELPER.CWebPage.PageSizeToVietnames(grvData);
                contestId = getQueryString("ContestId");
                grvData.DataSource = obj.LoadViewByContestID(contestId);
                grvData.DataBind();
            }
            else
            {
                ppPass.ShowOnPageLoad = true;
                txtPass.Focus();
            }


        }

        private void Search()
        {
            grvData.DataSource = obj.LoadViewByContestID(contestId);
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

                    HELPER.Client.Alert(this, "Đã nộp yêu cầu!");
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {

                HELPER.Client.Alert(this, "Lỗi xin vào khóa học! " + ex.ToString());
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

        protected void btnCommitPass_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == objContest.GetPassword(contestId))
            {
                ppPass.ShowOnPageLoad = false;
                string pass = objContest.GetPassword(contestId);
                HELPER.CWebPage.PageSizeToVietnames(grvData);
                contestId = getQueryString("ContestId");
                grvData.DataSource = obj.LoadViewByContestID(contestId);
                grvData.DataBind();
            }
        }


    }
}