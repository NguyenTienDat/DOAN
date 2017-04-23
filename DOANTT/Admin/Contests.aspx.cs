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
    public partial class Contests : System.Web.UI.Page
    {
        private HELPER.CGlobal.FunctionMode FMode;
        private BUS.BUS_Contests objContest = new BUS.BUS_Contests();
        private BUS.BUS_ProblemsInContest objProbInContest = new BUS.BUS_ProblemsInContest();
        private BUS.BUS_Problems objProb = new BUS.BUS_Problems();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initForm();
                Search();
                txtIsLimitTime_CheckedChanged(new object(), new EventArgs());
                chkHasPass_CheckedChanged(new object(), new EventArgs());
            }
        }
        private void initForm()
        {
            HELPER.CWebPage.PageSizeToVietnames(grvContests);
            HELPER.CWebPage.FormatPanel(pnEdit);
            CGlobal.SetSessionTitleAdmin("QUẢN TRỊ KHÓA HỌC");
        }

        private void Search()
        {
            grvContests.DataSource = objContest.LoadBySearch(cboFillter.SelectedIndex);
            grvContests.DataBind();
        }


        protected void grvContests_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            Search();
        }

        protected void grvContests_PageSizeChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void grvContests_PageIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void grvContests_ProcessColumnAutoFilter(object sender, DevExpress.Web.ASPxGridViewAutoFilterEventArgs e)
        {
            Search();
        }

        protected void grvContests_SearchPanelEditorCreate(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorCreateEventArgs e)
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
            objContest = new BUS.BUS_Contests(dao);
            objProbInContest = new BUS.BUS_ProblemsInContest(dao);

            try
            {
                dao.BeginTransaction();
                HELPER.CWebPage.BindProperty(objContest, pnEdit);
                try
                {
                    //objContest.StartTime = objContest.StartTime.Date.AddMinutes(txtStartTime.DateTime.TimeOfDay.TotalMinutes);
                    //objContest.EndTime = objContest.EndTime.Date.AddMinutes(txtEndTime.DateTime.TimeOfDay.TotalMinutes);

                    if (txtIsLimitTime.Checked)
                    {
                        objContest.StartTime = dteStartTime.Date.AddMinutes(txtStartTime.DateTime.TimeOfDay.TotalMinutes);
                        objContest.EndTime = dteEndTime.Date.AddMinutes(txtEndTime.DateTime.TimeOfDay.TotalMinutes);

                        if (objContest.StartTime > objContest.EndTime)
                        {
                            HELPER.Client.Alert(this, "Thời gian bắt đầu phải trước thời gian kết thúc!");
                            return;
                        }
                    }
                    else
                    {
                        objContest.StartTime = DateTime.MinValue;
                        objContest.EndTime = DateTime.MinValue;
                    }
                }
                catch (Exception)
                {
                    objContest.StartTime = DateTime.MinValue;
                    objContest.EndTime = DateTime.MinValue;
                }

                FMode = getMode();

                long id = 0;
                if (FMode == CGlobal.FunctionMode.AddMode)
                {
                    id = objContest.Insert();
                    setHdf(hdfID, id);
                    objProbInContest.ContestsId = id;
                }
                else if (FMode == CGlobal.FunctionMode.EditMode)
                {
                    id = getHdf(hdfID);
                    objContest.Id = id;
                    objProbInContest.ContestsId = id;

                    objContest.Update();
                    objProbInContest.DeleteByContest();
                }

                DataTable dtChecked = objProbInContest.LoadByContestID(id);
                List<DataRow> list = dtChecked.AsEnumerable().ToList();

                foreach (ListEditItem item in cblProblems.Items)
                {
                    if (item.Selected)
                    {
                        objProbInContest.ProblemsId = long.Parse(item.Value.ToString());
                        objProbInContest.Insert();
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
                    long id = getHdf(hdfID);
                    DataTable dt = objContest.LoadByID(id);

                    HELPER.CWebPage.BindPanel(pnEdit, dt);
                    try
                    {
                        if (!string.IsNullOrEmpty(CGlobal.getDataByColumn(id, "StartTime", "Contests")))
                        {
                            DateTime start = DateTime.Parse(CGlobal.getDataByColumn(id, "StartTime", "Contests"));
                            DateTime end = DateTime.Parse(CGlobal.getDataByColumn(id, "EndTime", "Contests"));
                            txtStartTime.Value = start;
                            dteStartTime.Value = start;
                            txtEndTime.Value = end;
                            dteEndTime.Value = end;
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                else //AddMode
                {
                    chkIsVisible.Checked = true;
                }
                objProb.LoadToCheckList(cblProblems);

            }
            else if (FMode == CGlobal.FunctionMode.CloseMode || FMode == CGlobal.FunctionMode.SearchMode)
            {
                pnMain.Visible = true;
                pnEdit.Visible = false;
                Response.Redirect(Request.RawUrl);
            }

        }

        protected void grvContests_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            long id = long.Parse(grvContests.GetRowValues(e.VisibleIndex, grvContests.KeyFieldName).ToString());
            if (e.ButtonID == "GridEdit")
            {
                setHdf(hdfID, id);
                setMode(CGlobal.FunctionMode.EditMode);
                if (!string.IsNullOrEmpty(CGlobal.getDataByColumn(id, "StartTime", "Contests")))
                {
                    txtIsLimitTime.Checked = true;
                    txtIsLimitTime_CheckedChanged(new object(), new EventArgs());
                }

                initFuncMode();
            }
            else if (e.ButtonID == "GridDelete")
            {
                try
                {
                    objContest.Delete(id);
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

        protected void cblProblems_PreRender(object sender, EventArgs e)
        {

            try
            {
                long p_id = long.Parse(txtId.Text.ToString());
                DataTable dtChecked = objProbInContest.LoadByContestID(p_id);
                List<DataRow> list = dtChecked.AsEnumerable().ToList();
                foreach (ListEditItem item in cblProblems.Items)
                {
                    long id = long.Parse(item.Value.ToString());
                    for (int i = 0; i < list.Count; i++)
                    {
                        long selected = long.Parse(list[i].ItemArray[0].ToString());
                        if (id == selected)
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void grvContests_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.FieldName == "Description")
            if (e.CellValue != null)
            {
                string toolTip = Environment.NewLine +
                    "Mô tả: " + grvContests.GetRowValues(e.VisibleIndex, "Description").ToString() + Environment.NewLine + Environment.NewLine +
                    "Mật khẩu: " + grvContests.GetRowValues(e.VisibleIndex, "ContestPassword").ToString() + Environment.NewLine + Environment.NewLine +
                    "Sửa gần nhất: " + DateTime.Parse(grvContests.GetRowValues(e.VisibleIndex, "ModifiedOn").ToString()).ToString("dd/MM/yyyy") + Environment.NewLine + Environment.NewLine +
                    "Tạo bởi: " + grvContests.GetRowValues(e.VisibleIndex, "FullName").ToString() + Environment.NewLine;
                //+ e.CellValue.ToString();


                if (grvContests.GetRowValues(e.VisibleIndex, "StartTime") != null)
                {
                    try
                    {
                        toolTip += "Bắt đầu: " + DateTime.Parse(grvContests.GetRowValues(e.VisibleIndex, "StartTime").ToString()).ToString("HH:mm, dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;
                    }
                    catch (Exception)
                    {

                    }
                }
                if (grvContests.GetRowValues(e.VisibleIndex, "EndTime") != null)
                {
                    try
                    {
                        toolTip += "Kết thúc: " + DateTime.Parse(grvContests.GetRowValues(e.VisibleIndex, "EndTime").ToString()).ToString("HH:mm, dd/MM/yyyy") + Environment.NewLine + Environment.NewLine;
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


        protected void cboFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void txtIsLimitTime_CheckedChanged(object sender, EventArgs e)
        {
            trStartTime.Visible = txtIsLimitTime.Checked;
            trEndTime.Visible = txtIsLimitTime.Checked;
        }

        protected void chkHasPass_CheckedChanged(object sender, EventArgs e)
        {
            trPass.Visible = chkHasPass.Checked;
        }




    }
}
