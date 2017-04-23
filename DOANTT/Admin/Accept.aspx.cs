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
    public partial class Accept : System.Web.UI.Page
    {
        private BUS.BUS_MyContest objMyContest = new BUS.BUS_MyContest();

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
            CGlobal.SetSessionTitleAdmin("ĐƠN XIN VÀO LỚP");
        }

        private void Search()
        {
            grvData.DataSource = objMyContest.LoadNotAcceptedByCreated();
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


        protected void grvData_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName == "Description")
            //    if (e.CellValue != null)
            //    {
            //        string toolTip = Environment.NewLine +
            //            "Mô tả: " + grvData.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
            //            "Mật khẩu: " + grvData.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine + Environment.NewLine +
            //            "Sửa gần nhất: " + DateTime.Parse(grvData.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine +
            //            "Tạo bởi: " + grvData.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine;
            //        e.Cell.ToolTip = toolTip;
            //    }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<Object> selectItemsID = new List<object>();
            selectItemsID = grvData.GetSelectedFieldValues(grvData.KeyFieldName);
            accept(selectItemsID);
        }
        protected void grvData_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            // long myNotiID = long.Parse(CGlobal.getDataByColumn(myNotiID, "NotificationID", "V_MyNotification"));
            List<Object> selectItemsID = new List<object>();
            selectItemsID.Add(grvData.GetRowValues(e.VisibleIndex, grvData.KeyFieldName));
            accept(selectItemsID);
        }
        void accept(List<Object> selectItemsID)
        {
            DatabaseDAO dao = new DatabaseDAO();
            objMyContest = new BUS.BUS_MyContest(dao);
            BUS.BUS_Notification objNoti = new BUS.BUS_Notification(dao);
            BUS.BUS_MyNotification objMyNoti = new BUS.BUS_MyNotification(dao);
            try
            {
                long acceptBy = CGlobal.GetUserID();
                
                if (selectItemsID.Count <= 0)
                {
                    HELPER.Client.Alert(this, "Bạn chưa chọn đơn nào!");
                }
                else
                {
                    dao.BeginTransaction();
                    long idNoti = objNoti.Insert(acceptBy, "Đã phê duyệt đơn xin vào khóa học của bạn", 3);
                    foreach (object selectItemId in selectItemsID)
                    {
                        string[] re = selectItemId.ToString().Split('|');
                        long idMyContest = long.Parse(re[0]);
                        long userId = long.Parse(re[1]);
                        objMyContest.UpdateAcepted(idMyContest, acceptBy);
                        objMyNoti.Insert(idNoti, userId);
                    }
                    dao.EndTransaction();

                    Response.Redirect(Request.RawUrl, false);
                }
            }
            catch (Exception ex)
            {
                dao.RollBack();
                HELPER.Client.Alert(this, "Lỗi cập nhật CSDL! " + ex.Message);
            }
        }

    }
}
