using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HELPER;

namespace DOANTT.Pages
{
    public partial class Problem : System.Web.UI.Page
    {
        BUS.BUS_Problems obj = new BUS.BUS_Problems();
        BUS.BUS_ProblemsInContest objProblemInContest = new BUS.BUS_ProblemsInContest();

        BUS.BUS_Contests objContest = new BUS.BUS_Contests();
        BUS.BUS_MyContest objMyContest = new BUS.BUS_MyContest();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HELPER.CGlobal.SetSessionTitleUser("BÀI TẬP");
                initForm();
            }
        }
        private void initForm()
        {
            long problemsInContest = getQueryString("ProblemsInContest");
            long problemId = getDataByColum("ProblemsId");
            long contestId = getDataByColum("ContestsId");

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





            HELPER.CWebPage.BindPanel(pnMain, obj.LoadByID(problemId));
            ASPxRichEdit1.Open(
                Server.MapPath(CConstant.C_WORK_DIRECTORY_PROBLEMS + txtURL_Content.Text)
            );
        }

        protected void btnSubmiss_Click(object sender, EventArgs e)
        {
            long problemId = getDataByColum("ProblemsId");
            long contestId = getDataByColum("ContestsId");
            Response.Redirect("Submiss.aspx?ContestId=" + contestId + "&ProblemId=" + problemId);
        }

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
        public long getDataByColum(string col)
        {
            try
            {
                long problemsInContest = getQueryString("ProblemsInContest");
                return long.Parse(CGlobal.getDataByColumn(problemsInContest, col, "ProblemsInContest"));
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
